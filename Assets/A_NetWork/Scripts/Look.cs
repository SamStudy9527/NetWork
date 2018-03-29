using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sam
{

    public class Look : MonoBehaviour
    {

        string IP = "192.168.5.101";
        int Port = 10100;

        int moveSpeed = 16;

        GameObject cube01 = null;


        GameObject myself = null;


        // Use this for initialization  
        void Start()
        {
            cube01 = GameObject.Find("Cube");print(cube01.transform.position);

        }

        //OnGUI方法，所有GUI的绘制都需要在这个方法中实现  
        void OnGUI()
        {
            //Network.peerType是端类型的状态:  
            //即disconnected, connecting, server 或 client四种  
            switch (Network.peerType)
            {
                //禁止客户端连接运行, 服务器未初始化  
                case NetworkPeerType.Disconnected:
                    StartServer();
                    break;
                //运行于服务器端  
                case NetworkPeerType.Server:
                    OnServer();
                    break;
                //运行于客户端  
                case NetworkPeerType.Client:
                    break;
                //正在尝试连接到服务器  
                case NetworkPeerType.Connecting:
                    break;
            }
        }

        void StartServer()
        {
            GUILayout.Label("同步测试:");
            //当用户点击按钮的时候为true  
            if (GUILayout.Button("创建服务器"))
            {
                //初始化本机服务器端口，第一个参数就是本机接收多少连接  
                NetworkConnectionError error = Network.InitializeServer(12, Port, false);
                //连接状态  
                switch (error)
                {
                    case NetworkConnectionError.NoError:
                        break;
                    default:
                        Debug.Log("服务端错误" + error);
                        break;
                }
            }
            if (GUILayout.Button("连接服务器"))
            {
                NetworkConnectionError error = Network.Connect(IP, Port);
                //连接状态  
                switch (error)
                {
                    case NetworkConnectionError.NoError:
                        print("连接上了");   break;
                    default:
                        Debug.Log("客户端错误" + error);
                        break;
                }
            }
        }

        void OnServer()
        {
            GUILayout.Label("服务端已经运行,等待客户端连接");
            //Network.connections是所有连接的玩家, 数组[]  
            //取客户端连接数.   
            int length = Network.connections.Length;
            //按数组下标输出每个客户端的IP,Port  
            for (int i = 0; i < length; i++)
            {
                GUILayout.Label("客户端" + i);
                GUILayout.Label("客户端ip" + Network.connections[i].ipAddress);
                GUILayout.Label("客户端端口" + Network.connections[i].port);
                GUILayout.Label("-------------------------------");
            }
            //当用户点击按钮的时候为true  
            if (GUILayout.Button("断开服务器"))
            {
                Network.Disconnect();
            }
        }

        //接收请求的方法. 注意要在上面添加[RPC]  
        [RPC]
        void ProcessMove(string msg, NetworkMessageInfo info)
        {
            //刚从网络接收的数据的相关信息,会被保存到NetworkMessageInfo这个结构中  
            string sender = info.sender.ToString();
            Debug.Log(sender);
            //看脚本运行在什么状态下  
            NetworkPeerType status = Network.peerType;
            if (status == NetworkPeerType.Server)
            {
                myself = cube01;  //假如运行在server状态下, 那么自己就是cube1  


            }
            else
            {
                myself = cube01;  //假如运行在client状态下, 那么自己就是cube2  

            }
            //假如是自己发送的信息  
            if (sender == "-1")
            {
                if (msg == "W")
                {
                    myself.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                if (msg == "S")
                {
                    myself.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                if (msg == "A")
                {
                    myself.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
                if (msg == "D")
                {
                    myself.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }

            }
            //假如是别人发送的信息  
            else
            {
                if (msg == "W")
                {
                    myself.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                if (msg == "S")
                {
                    myself.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                if (msg == "A")
                {
                    myself.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
                if (msg == "D")
                {
                    myself.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
            }
        }

        // Update is called once per frame  
        void Update()
        {
            #region 弃用的方法
            /*
            //前移  
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("wwwwwwwww|");  
                networkView.RPC("ProcessMove", RPCMode.All, "W");
            }
            if (Input.GetKey(KeyCode.W))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "W");
            }
            //后退  
            if (Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log("sssssssss!");  
                networkView.RPC("ProcessMove", RPCMode.All, "S");
            }
            if (Input.GetKey(KeyCode.S))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "S");
            }
            //向左移动  
            if (Input.GetKeyDown(KeyCode.A))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "A");
            }
            if (Input.GetKey(KeyCode.A))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "A");
            }
            //向右移动  
            if (Input.GetKeyDown(KeyCode.D))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "D");
            }
            if (Input.GetKey(KeyCode.D))
            {
                networkView.RPC("ProcessMove", RPCMode.All, "D");
            }
            //*/
            #endregion
        }
    }
}
