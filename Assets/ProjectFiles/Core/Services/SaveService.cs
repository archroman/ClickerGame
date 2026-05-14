using System.IO;
using UnityEngine;
using ProjectFiles.Data;

namespace ProjectFiles.Core.Services
{
    internal sealed class SaveService
    {
        private readonly string _path = Path.Combine(Application.persistentDataPath, "save.json");

        public void Save(SaveData data)
        {
            try
            {
                string json = JsonUtility.ToJson(data, true); 
                File.WriteAllText(_path, json);
                Debug.Log($"[SaveService] Игра сохранена в: {_path}");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[SaveService] Ошибка при сохранении: {e.Message}");
            }
        }

        public SaveData Load()
        {
            if (!File.Exists(_path)) 
            {
                return null;
            }

            try
            {
                string json = File.ReadAllText(_path);
                return JsonUtility.FromJson<SaveData>(json);
            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        public void ClearSave()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
        }
    }
}