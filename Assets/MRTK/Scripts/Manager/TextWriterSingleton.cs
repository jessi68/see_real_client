using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class TextWriterSingleton 
{
    static string total = "SMJ\n1,";
    static string m_sendPacket = "SMJ\n1,1,1,2,1,1,2,3\n3,320,400,80,400,740,210,650,470,120\n2,720,230,180,650,740,140";

    public static void WriteTxt(string filePath)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream, System.Text.Encoding.Unicode);

        writer.WriteLine(total);
        writer.Close();
    }

    public static void addValue(string value)
    {
        total += value;
        total += ",";
    }

    public static void finalValue(string value)
    {
        total += value;
        m_sendPacket = total;
        Debug.Log(total);
    }

    public static string GetSendPacketData()
    {
        return m_sendPacket;
    }

    public static void SetSendPacketData(string sendPacket)
    {
        m_sendPacket = sendPacket;
    }


}
