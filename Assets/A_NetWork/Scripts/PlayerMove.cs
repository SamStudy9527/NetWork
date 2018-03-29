using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Sam
{

    public class PlayerMove : NetworkBehaviour
    {
        /// <summary> 移动速度 </summary>
        public float _speed;
        /// <summary> 旋转角度 </summary>
        public float _rotate;
       

        public override void OnStartLocalPlayer()
        {
            Material material = GetComponentInChildren<SkinnedMeshRenderer>().material;
            material.color = Color.black;
        }

        private void OnGUI()
        {
            GUILayout.Button("本地IP：" + Network.player.ipAddress);
        }

        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            float yAxis = Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, yAxis * _rotate, 0));
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, _speed));
            }
        }


    }
}
