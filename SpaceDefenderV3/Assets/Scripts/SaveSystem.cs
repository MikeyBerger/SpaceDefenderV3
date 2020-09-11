using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveTime(TimerScript TS)
    {
        BinaryFormatter BF = new BinaryFormatter();
        string Path = Application.persistentDataPath + "/TimerScript.cs";
        FileStream Stream = new FileStream(Path, FileMode.Create);


        TimerData Data = new TimerData(TS);

        BF.Serialize(Stream, Data);
        Stream.Close();
    }

    public static TimerData LoadTimer()
    {
        string Path = Application.persistentDataPath + "/TimerScript.cs";

        if (File.Exists(Path))
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            FileStream NewStream = new FileStream(Path, FileMode.Open);

            TimerData NewData = Formatter.Deserialize(NewStream) as TimerData;
            NewStream.Close();

            return NewData;
        }
        else
        {
            Debug.LogError("Save file " + Path + " not found");
            return null;
        }
    }

}
