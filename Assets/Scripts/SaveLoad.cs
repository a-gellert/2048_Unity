using UnityEngine;
using System.IO;
using System;
public class SaveLoad : MonoBehaviour
{
    private static string fileName = "Data";
    private static int saveCount;
    private static int loadCount;
    private static bool isCrypt = true;

    public static void SaveFile()
    {
        saveCount = StateManager.recordCount;
        StreamWriter sw = new StreamWriter(Application.dataPath + "/" + fileName + ".ces");
        string sp = " ";
        sw.WriteLine(Crypt("key_int" + sp + saveCount));

        sw.Close();
    }

    public static void LoadFile()
    {
        if (File.Exists(Application.dataPath + "/" + fileName + ".ces"))
        {
            string[] rows = File.ReadAllLines(Application.dataPath + "/" + fileName + ".ces");

            int _i;
            if (int.TryParse(GetValue(rows, "key_int"), out _i))
            {
                loadCount = _i;
            }
            StateManager.recordCount = loadCount;
            rows = new string[0];
        }
    }


    private static string Crypt(string text)
    {
        if (!isCrypt) return text;

        string result = string.Empty;
        foreach (char j in text)
        {
            result += (char)((int)j ^ 49);
        }

        return result;
    }

    private static string GetValue(string[] line, string pattern)
    {
        string result = "";
        foreach (string key in line)
        {
            if (key.Trim() != string.Empty)
            {
                string value = "";
                if (isCrypt) value = Crypt(key); else value = key;

                if (pattern == value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    result = value.Remove(0, value.IndexOf(' ') + 1);
                }
            }
        }
        return result;
    }
}
