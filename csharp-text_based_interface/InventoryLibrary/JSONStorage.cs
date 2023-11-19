using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace InventoryLibrary
{
    public class JSONStorage
    {
        private Dictionary<string, object> objects = new Dictionary<string, object>();
        private string jsonFilePath = "storage/inventory_manager.json";

        public Dictionary<string, object> All()
        {
            return objects;
        }

        public void New(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            string key = $"{obj.GetType().Name}.{((BaseClass)obj).id}";
            objects[key] = obj;
        }

        public void Save()
        {
            string jsonString = JsonSerializer.Serialize(objects);
            File.WriteAllText(jsonFilePath, jsonString);
        }

        public void Load()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonString = File.ReadAllText(jsonFilePath);
                objects = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            }
        }
    }
}
