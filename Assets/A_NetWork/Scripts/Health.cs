using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Sam
{

    public class Health : NetworkBehaviour
    {
        float _healthMax = 100;
        public int _healthValue = 5;
        Slider _slider;

        private void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
            _slider.maxValue = _healthMax;
            _slider.value = _healthMax;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Hand"))
            {
                CmdAttack();
            }
        }

        [Command]
        private void CmdAttack()
        {
            _healthMax -= _healthValue;
            _slider.value = _healthMax;
        }

        private void Update()
        {
            if (_slider.value <= 0) 
            {
                SendMessage("Dead");
            }
        } 

    }
}
