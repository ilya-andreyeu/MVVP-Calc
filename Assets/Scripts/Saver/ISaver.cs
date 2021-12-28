namespace Saver
{
    public interface ISaver
    {
        void Save<T>(T data, string key);

        T Load<T>(string key);
    }
}