using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Sam
{

    public class AnimatorControl : NetworkBehaviour
    {
        /// <summary> 动画组件 </summary>
        Animator _animator;
        /// <summary> 播放速度 </summary>
        public float _playSpeed = 1.2f;
        /// <summary> 移动动画播放速率 </summary>
        public float _MoveRate = 0.1f;
        /// <summary> 移动动画播放时间 </summary>
        public float _MoveTime = 0.0f;
        bool _isReceive = false;

        void Start()
        {
            _animator = GetComponent<Animator>();
            int layer = _animator.layerCount; print(layer);
        }

        void Update()
        {
            MoveControl();
        }

        private void Dead()
        {
            if (!_isReceive)
            {
                print("接受消息");     _isReceive = true;
                _animator.SetBool("IsDead", true);
                SendMessage("CmdGoDie");
            }
        }

        /// <summary> 移动控制方法组 </summary>
        private void MoveControl()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            _animator.SetBool("IsDead", false);
            _animator.SetBool("IsRun", false);
            _animator.SetBool("IsJump", false);
            _animator.SetBool("IsAttack", false);
            _animator.SetBool("IsWalkAttack", false);
            _animator.speed = _playSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetBool("IsJump", true);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                _animator.SetBool("IsAttack", true);
            }
            if (Input.GetKey(KeyCode.W) && Time.time > _MoveTime)
            {
                _MoveTime = _MoveRate + Time.time;
                _animator.SetBool("IsRun", true);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.J))
            {
                _animator.SetBool("IsWalkAttack", true);
            }

        }

    }
}
