using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Script.System
{
    public class SerializationBinaryFormatter : MonoBehaviour
    {
        public static void SaveData(Serialization data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Application.persistentDataPath + "/PlayerData.data", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public static Serialization LoadData()
        {
            if (File.Exists(Application.persistentDataPath + "/PlayerData.data"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(Application.persistentDataPath + "/PlayerData.data",
                    FileMode.OpenOrCreate))
                {
                    Serialization newData = (Serialization) formatter.Deserialize(fs);
                    return newData;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
