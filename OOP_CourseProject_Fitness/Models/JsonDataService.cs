using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_CourseProject_Fitness.Models
{
    public class JsonDataService
    {
        private string userFilePath = "C:\\Users\\byzil\\source\\repos\\OOP_CourseProject_Fitness\\OOP_CourseProject_Fitness\\Json\\data.json";      
        private string clientFilePath = "C:\\Users\\byzil\\source\\repos\\OOP_CourseProject_Fitness\\OOP_CourseProject_Fitness\\Json\\dataClient.json"; 

        
        public void SaveData<T>(List<T> data, bool isClientData = false)
        {
            try
            {
               
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                string filePath = isClientData ? clientFilePath : userFilePath;  

                File.WriteAllText(filePath, json);  
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        
        public List<T> LoadData<T>(bool isClientData = false)
        {
            try
            {
                string filePath = isClientData ? clientFilePath : userFilePath;

                
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return new List<T>();  
                    }

                   
                    return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
                }
                else
                {
                    
                    SaveData(new List<T>(), isClientData);
                    return new List<T>(); 
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                return new List<T>(); 
            }
        }
    }
}
