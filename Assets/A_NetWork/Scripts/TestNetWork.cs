using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sam
{

    public class TestNetWork : MonoBehaviour
    {

        public int connections = 10;
        public int listenPort = 8899;
        public bool useNat = false;
        public string ip = "127.0.0.1";
        public GameObject playerPrefab;
        
        
        void OnGUI()
        {
            if (Network.peerType == NetworkPeerType.Disconnected)
            {
                if (GUILayout.Button("创建服务器"))
                {
                    NetworkConnectionError error = Network.InitializeServer(connections, listenPort, useNat);
                }
                if (GUILayout.Button("连接服务器"))
                {
                    NetworkConnectionError error = Network.Connect(ip, listenPort);
                }
            }
            else if (Network.peerType == NetworkPeerType.Server)
            {
                GUILayout.Label("服务器创建完成");
            }
            else if (Network.peerType == NetworkPeerType.Client)
            {
                GUILayout.Label("客户端已接入");
            }
        }


        void OnServerInitialized()
        {
            print("服务器完成初始化");
            int group = int.Parse(Network.player + "");
            Network.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity, group);
        }


        void OnPlayerConnected(NetworkPlayer player)
        {
            print("一个客户端连接过来,Index:" + player);
        }


        void OnConnectedToServer()
        {
            print("我成功连接到服务器");
            int group = int.Parse(Network.player + "");
            Network.Instantiate(playerPrefab, new Vector3(0, 2, 0), Quaternion.identity, group);
        }

    }
}
