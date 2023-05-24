using System;
using UnityEngine;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

public class TCPClient : MonoBehaviour
{
    private Socket m_Client;
    private string m_Ip = "172.30.1.7";
    private int m_Port = 50001;
    private string m_SendPacket = "";
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            string m_SendPacket = "1,1,1,2,1,1\n2,3\n3,2\n320,400,80,400,740,210,650,470,120\n720,230,180,650,740,140";
            Debug.Log("Send");
            Send(m_SendPacket);
        }
    }
    void InitClient()
    {

        m_ServerIpEndPoint = new IPEndPoint(IPAddress.Parse(m_Ip), m_Port);
        m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            m_Client.Connect(m_ServerIpEndPoint);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            Debug.Log("Unable to connect to remote end point");
        }
    }

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
                Debug.Log(ex.ToString());
                return;
            }

            if (receive > 0)
            {
                int fileNameLen = packet[0];
                byte[] fileName_b = new byte[fileNameLen];
                Array.Copy(packet, 1, fileName_b, 0, fileNameLen);
                string fileName = Encoding.UTF8.GetString(fileName_b);

                byte[] image_b = new byte[1000000];
                Debug.Log(packet[999997]);
                Debug.Log(packet[999998]);
                Debug.Log(packet[999999]);
                Array.Copy(packet, fileNameLen + 1, image_b, 0, 999998 - fileNameLen);
                ByteArrayToImageAndSave(image_b, fileName);

                Thread.Sleep(3000);
                ExhibitionManager.GetComponent<ExhibitionManager>().finishGeneration(fileName);
            }
        }
    }

    public async void ByteArrayToImageAndSave(byte[] data, string fileName)
    {
        string fileDir = Path.Combine("./Assets/Resources/Textures/", fileName);
        Debug.Log(fileDir);
        FileStream fs = new FileStream(fileDir, FileMode.Create, FileAccess.Write);
        try
        {
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
        catch
        {
            fs.Close();
        }
    }
    // String을 바이트 배열로 변환 
    private byte[] StringToByte(string str)
    {
        byte[] StrByte = Encoding.UTF8.GetBytes(str);
        return StrByte;
    }
}