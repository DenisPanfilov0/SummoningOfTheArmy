using UnityEngine;

public class SaveManager
{
    public static void SaveData<T>(T data, string saveKey)
    {
        // Создаем строку JSON из переданных данных
        string jsonData = JsonUtility.ToJson(data);

        // Сохраняем JSON-строку в PlayerPrefs с указанным ключом
        PlayerPrefs.SetString(saveKey, jsonData);
        PlayerPrefs.Save(); // Обязательно вызываем Save(), чтобы сохранить изменения
    }

    public static void LoadData<T>(T data, string saveKey)
    {
        // Проверяем, есть ли сохраненные данные с указанным ключом
        if (PlayerPrefs.HasKey(saveKey))
        {
            // Загружаем JSON-строку из PlayerPrefs с указанным ключом
            string jsonData = PlayerPrefs.GetString(saveKey);

            // Десериализуем JSON-строку в объект указанного типа данных
            JsonUtility.FromJsonOverwrite(jsonData, data);
        }
    }
}