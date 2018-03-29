using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sam
{

    public class Shoot : MonoBehaviour
    {
        /// <summary> 子弹预制体 </summary>
        public GameObject _preBullet;
        /// <summary> 开火速率 </summary>
        public float fireRate = 0.1f;
        /// <summary> 开火时间 </summary>
        public float fireTime = 0.0f;


        void Update()
        {
          
            if (Input.GetMouseButton(0) && Time.time > fireTime)
            {
                //根据开火速率调整开火时间
                fireTime = fireRate + Time.time;
                GameObject bullet = Instantiate(_preBullet, transform.position, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 100);
            }
         
        }

    }
}
