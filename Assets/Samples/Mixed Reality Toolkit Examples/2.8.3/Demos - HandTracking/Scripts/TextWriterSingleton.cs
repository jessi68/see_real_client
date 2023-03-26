using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextWriterSingleton 
{
    static string total = "";

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


}
