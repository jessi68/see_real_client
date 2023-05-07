using System;
using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Drawing;

public class Client : MonoBehaviour
{
    private Socket m_Client;
    public string m_Ip = "192.168.1.6";
    public int m_Port = 50001;
    public string m_SendPacket = "";
    public Image m_ReceivePacket;
    private IPEndPoint m_ServerIpEndPoint;
    private EndPoint m_RemoteEndPoint;

    void Start()
    {
        InitClient();
    }


    void Update()
    {
        Receive();
        // Send();
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_SendPacket = "김주하\n1,1,1,2,1,1,2,3\n3,320,400,80,400,740,210,650,470,120\n2,720,230,180,650,740,140";
            Debug.Log("Send");
            Send();
        }
    }

    void OnApplicationQuit()
    {
        CloseClient();
    }

    void InitClient()
    {
        // SendPacket에 배열이 있으면 선언 해 주어야 함.
        // m_SendPacket.m_IntArray = new int[2];

        m_ServerIpEndPoint = new IPEndPoint(IPAddress.Parse(m_Ip), m_Port);
        m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        m_Client.Connect(m_ServerIpEndPoint);
    }

    // void SetSendPacket()
    // {
    //     m_SendPacket.m_BoolVariable = true;
    //     m_SendPacket.m_IntVariable = 13;
    //     m_SendPacket.m_IntArray[0] = 7;
    //     m_SendPacket.m_IntArray[1] = 47;
    //     m_SendPacket.m_FloatlVariable = 2020;
    //     m_SendPacket.m_StringlVariable = "Coder Zero";
    // }

    void Send()
    {
        try
        {
            byte[] sendPacket = StringToByte(m_SendPacket);
            m_Client.Send(sendPacket, 0, sendPacket.Length, SocketFlags.None);
        }

        catch (Exception ex)
        {
            //Debug.Log(ex.ToString());
            return;
        }
    }

    void Receive()
    {
        int receive = 0;
        if (m_Client.Available != 0)
        {
            byte[] packet = new byte[1000000];

            try
            {
                receive = m_Client.Receive(packet);
            }

            catch (Exception ex)
            {
                //Debug.Log(ex.ToString());
                return;
            }

            m_ReceivePacket = ByteToPNG(packet);

            if (receive > 0)
            {
                Debug.Log("packet");
                for (int i = 0; i < 10; i++)
                {
                    Debug.Log(packet[i]);
                }
                DoReceivePacket(); // 받은 값 처리
            }
        }
    }

    void DoReceivePacket()
    {
        // Debug.LogFormat($"m_IntArray[0] = {m_ReceivePacket.m_IntArray[0]} " +
        //    $"m_IntArray[1] = {m_ReceivePacket.m_IntArray[1]} " +
        //    $"FloatlVariable = {m_ReceivePacket.m_FloatlVariable} " +
        //    $"StringlVariable = {m_ReceivePacket.m_StringlVariable}" +
        //    $"BoolVariable = {m_ReceivePacket.m_BoolVariable} " +
        //    $"IntlVariable = {m_ReceivePacket.m_IntVariable} ");
        //출력: m_IntArray[0] = 7 m_IntArray[1] = 47 FloatlVariable = 2020 StringlVariable = Coder ZeroBoolVariable = True IntlVariable = 13 
    }

    void CloseClient()
    {
        if (m_Client != null)
        {
            m_Client.Close();
            m_Client = null;
        }
    }

    private Image ByteToPNG(byte[] strByte)
    {
        using (MemoryStream memstr = new MemoryStream(strByte))
        {
            Image img = Image.FromStream(memstr);
            return img;
        }
    }
    // String을 바이트 배열로 변환 
    private byte[] StringToByte(string str)
    {
        byte[] StrByte = Encoding.UTF8.GetBytes(str);
        return StrByte;
    }
}