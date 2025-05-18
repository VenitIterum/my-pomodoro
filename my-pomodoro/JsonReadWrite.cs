using System.IO;
using System.Text.Json;

namespace my_pomodoro
{
    /// <summary>
    /// My class for simple Serialize and Deserialize
    /// </summary>
    public static class JsonReadWrite
    {
        /// <summary>
        /// The Serializer is used to write values to a json file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="value"></param>
        public static void Serializer<T>(string path, T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.SerializeAsync<T>(file, value, options);
            }
        }

        /// <summary>
        /// The Deserializer is used to read values from a json file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Deserializer<T>(string path)
        {
            if (!File.Exists(path) || string.IsNullOrWhiteSpace(File.ReadAllText(path)))
                return default(T);

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<T>(file);
            }
        }
    }
}
