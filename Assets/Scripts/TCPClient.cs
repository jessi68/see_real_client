using System;
using UnityEngine;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

public class TCPClient : MonoBehaviour
{

    private Socket m_Client;
    public string m_Ip = "192.168.1.228";
    public int m_Port = 60015;
    public string m_SendPacket = "";
    // public Image m_ReceivePacket;
    private IPEndPoint m_ServerIpEndPoint;
    private EndPoint m_RemoteEndPoint;
    [SerializeField]
    private GameObject ExhibitionManager;

    void Start()
    {
        InitClient();
        
    }


    void Update()
    {
        Receive();
        if (Input.GetKeyDown(KeyCode.S))
        {
            string m_SendPacket = "SMJ\n1,1,1,2,1,1,2,3\n3,320,400,80,400,740,210,650,470,120\n2,720,230,180,650,740,140";
            Debug.Log("Send");
            Send(m_SendPacket);
        }
    }

    // void OnApplicationQuit()
    // {
    //     CloseClient();
    // }

    void InitClient()
    {
        // SendPacket에 배열이 있으면 선언 해 주어야 함.
        // m_SendPacket.m_IntArray = new int[2];

        m_ServerIpEndPoint = new IPEndPoint(IPAddress.Parse(m_Ip), m_Port);
        m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try{
            m_Client.Connect(m_ServerIpEndPoint);
        }
        catch (Exception ex){
            Debug.Log(ex.ToString());
            Debug.Log("Unable to connect to remote end point");
        }

        // client = new TcpClient(ipAddress, Int32.Parse(port));
        // networkStream = client.GetStream();
        // streamWriter = new StreamWriter(networkStream);
    }

    // // void SetSendPacket()
    // // {
    // //     m_SendPacket.m_BoolVariable = true;
    // //     m_SendPacket.m_IntVariable = 13;
    // //     m_SendPacket.m_IntArray[0] = 7;
    // //     m_SendPacket.m_IntArray[1] = 47;
    // //     m_SendPacket.m_FloatlVariable = 2020;
    // //     m_SendPacket.m_StringlVariable = "Coder Zero";
    // // }

    public void Send(string m_SendPacket)
    {
        try
        {
            byte[] sendPacket = StringToByte(m_SendPacket);
            m_Client.Send(sendPacket, 0, sendPacket.Length, SocketFlags.None);
            Debug.Log("Send Finish");
        }

        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
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

            if (receive > 0)
            {
                int fileNameLen = packet[0];
                // Debug.Log(fileNameLen);
                byte[] fileName_b = new byte[100];
                // Debug.Log(fileName_b);
                Array.Copy(packet, 1, fileName_b, 0, fileNameLen);
                // Debug.Log(fileName_b);
                string fileName = Encoding.UTF8.GetString(fileName_b);
                Debug.Log(fileName);

                byte[] image_b = new byte[1000000];
                Array.Copy(packet, fileNameLen + 1, image_b, 0, 999998 - fileNameLen);
                Debug.Log(image_b);
                ByteArrayToImageAndSave(image_b, fileName);

                ExhibitionManager.GetComponent<ExhibitionManager>().finishGeneration();
                // DoReceivePacket(); // 받은 값 처리
            }
        }
    }

    // void DoReceivePacket()
    // {
    //     // Debug.LogFormat($"m_IntArray[0] = {m_ReceivePacket.m_IntArray[0]} " +
    //     //    $"m_IntArray[1] = {m_ReceivePacket.m_IntArray[1]} " +
    //     //    $"FloatlVariable = {m_ReceivePacket.m_FloatlVariable} " +
    //     //    $"StringlVariable = {m_ReceivePacket.m_StringlVariable}" +
    //     //    $"BoolVariable = {m_ReceivePacket.m_BoolVariable} " +
    //     //    $"IntlVariable = {m_ReceivePacket.m_IntVariable} ");
    //     //출력: m_IntArray[0] = 7 m_IntArray[1] = 47 FloatlVariable = 2020 StringlVariable = Coder ZeroBoolVariable = True IntlVariable = 13 
    // }

    // void CloseClient()
    // {
    //     if (streamWriter != null)
    //     {
    //         streamWriter.Close();
    //         streamWriter = null;
    //     }
    //     if (streamReader != null)
    //     {
    //         streamReader.Close();
    //         streamReader = null;
    //     }
    //     if (networkStream != null)
    //     {
    //         networkStream.Close();
    //         networkStream = null;
    //     }
    // }

    public void ByteArrayToImageAndSave(byte[] data, string fileName)
    {
        FileStream fs = new FileStream("./Assets/Resources/Textures/"+fileName+".png", FileMode.Create, FileAccess.Write);
        fs.Write(data, 0, data.Length);
    }
    // String을 바이트 배열로 변환 
    private byte[] StringToByte(string str)
    {
        byte[] StrByte = Encoding.UTF8.GetBytes(str);
        return StrByte;
    }
}