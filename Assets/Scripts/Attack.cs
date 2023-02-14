using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private int[] _delayTime;

    private bool _isAttack = false;

    public async Task PlayerAttack()
    {
        await Task.Delay(_delayTime[0]);
        _isAttack = true;
        await Task.Delay(_delayTime[1]);
        _isAttack = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_isAttack && other.tag == "Finish")
        {
            other.gameObject.SetActive(false);
        }
    }
}
