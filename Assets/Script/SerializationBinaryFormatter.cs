using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Script
{
    public class SerializationBinaryFormatter : MonoBehaviour
    {
        public void SaveData(Serialization data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Application.persistentDataPath + "/PlayerData.data", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public Serialization LoadData()
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
