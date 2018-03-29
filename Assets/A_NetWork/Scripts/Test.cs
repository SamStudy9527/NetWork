using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sam
{

    public class Test : MonoBehaviour
    {

        private void Start()
        {
            GameObject.Find("Text").GetComponent<Text>().text = "本地IP：" + Network.player.ipAddress;
        }
                

    }
}
