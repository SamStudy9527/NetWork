using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Sam
{

    public class GameManager : NetworkBehaviour
    {
        PlayerMove _playerMove;
        AnimatorControl _animatorControl;
        Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animatorControl = GetComponent<AnimatorControl>();
            _playerMove = GetComponent<PlayerMove>();
        }

        [Command]
        void  CmdGoDie()
        {
            _animator.enabled = false;
            _playerMove.enabled = false;
            _animatorControl.enabled = false;
        }

    }
}
