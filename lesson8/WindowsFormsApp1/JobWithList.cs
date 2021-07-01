using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace TrueFalseEditor
{
    /// <summary>
    /// класс для сериализации класса List<Question>
    /// </summary>
    class JWL
    {
        /// <summary>
        /// считывает из xml файла класс
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <returns>экземпляр класса List</returns>
        static public List<Question> Load(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return (List<Question>)xmlSerializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// создает или перезаписывает xml файл
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="list">записываемый экземпляр</param>
        static public void Save(string fileName, List<Question> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Question>));
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, list);
            }
        }
    }
}
