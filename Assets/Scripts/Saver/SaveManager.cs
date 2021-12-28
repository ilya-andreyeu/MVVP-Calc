namespace Saver
{
    public class SaveManager
    {
        private static ISaver saver;

        private static void InitializeSaver()
        {
            if (saver == null)
            {
                saver = new PlayerPrefsSaver();
            }
        }

        public static void SaveData<T>(T data, string key)
        {
            InitializeSaver();
            saver.Save(data, key);
        }

        public static T LoadData<T>(string key)
        {
            InitializeSaver();
            return saver.Load<T>(key);
        }
    }
}