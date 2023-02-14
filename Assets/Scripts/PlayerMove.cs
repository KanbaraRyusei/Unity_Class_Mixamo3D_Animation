using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	GameObject _cameraGb;

	[SerializeField]
	float _speed = 10;

	[SerializeField]
	Attack _attack;

	Vector3 _right;
	Vector3 _left;
	bool _leftButton;
	bool _rightButton;

	Rigidbody _rb;
	Animator _anim;

    private void Start()
    {
		_rb = GetComponent<Rigidbody>();
		_anim = GetComponent<Animator>();
    }

    void Update()
	{
		var forward = this.transform.position - _cameraGb.transform.position;
		forward.y = 0;

		var right = Quaternion.LookRotation(forward) * Quaternion.Euler(0, 90, 0);
		var left = Quaternion.LookRotation(forward) * Quaternion.Euler(0, -90, 0);

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (v >= 0.1f)
		{
			_rb.velocity = forward.normalized * _speed;
			this.transform.LookAt(this.transform.position + forward);
		}

		if (v <= -0.1f)
		{

			_rb.velocity = -forward.normalized * _speed;
			this.transform.LookAt(this.transform.position - forward);
			_rightButton = true;
		}

		if (h >= 0.1f)
		{

			this.transform.rotation = right;
			_rb.velocity = this.transform.forward * _speed;
		}

		if (h <= -0.1f)
		{
			this.transform.rotation = left;
			_rb.velocity = this.transform.forward * _speed;
		}

		if(Input.GetKeyDown(KeyCode.Space))
        {
			_anim.SetBool("IsAttack", true);
			_ = _attack.PlayerAttack();
			_ = Delay();
        }
	}

	private async Task Delay()
    {
		await Task.Delay(4150);
		_anim.SetBool("IsAttack", false);
	}
}
