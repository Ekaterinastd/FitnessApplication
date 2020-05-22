using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class  ControllerBase
    {
        /// <summary>
        /// Сохранение объекта в файл.
        /// </summary>
        /// <param name="fileName">Имя файла.</param>
        /// <param name="item">Объект.</param>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        /// <summary>
        /// Загрузка объекта из файла.
        /// </summary>
        /// <typeparam name="T">Тип загружаемых объектов.</typeparam>
        /// <param name="fileName">Название файла.</param>
        /// <returns>Объект.</returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default;
                }

            }
        }
    }
}
