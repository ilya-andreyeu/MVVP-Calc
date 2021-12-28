using UnityEngine;

namespace Saver
{
    public class PlayerPrefsSaver : ISaver
    {
        public void Save<T>(T data, string key)
        {
            string json = ToJson(data);
            if (PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
            }

            PlayerPrefs.SetString(key, json);
        }

        public T Load<T>(string key)
        {
            T result = default(T);
            if (PlayerPrefs.HasKey(key))
            {
                var json = PlayerPrefs.GetString(key);
                result = FromJson<T>(json);
            }

            return result;
        }

        private string ToJson<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }

        private T FromJson<T>(string json)
        {
            T result;
            result = JsonUtility.FromJson<T>(json);
            return result;
        }
    }
}