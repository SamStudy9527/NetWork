using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sam
{

    public class LookCamer : MonoBehaviour
    {
        private Transform _camera;

        private void Start()
        {
            _camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        } 

        private void LateUpdate()
        {
            gameObject.transform.LookAt(_camera);
        } 

    }
}
