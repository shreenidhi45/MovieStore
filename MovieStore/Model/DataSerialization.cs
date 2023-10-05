using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MovieStore.Model
{
    internal class DataSerialization
    {
        private const string FileName = "C:\\Users\\shreenidhi\\source\\repos\\MovieStore\\data.txt";

        public void Serialize(List<Movie> movies)
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movies);
            }
            Console.WriteLine("Data serialized successfully.");
        }
        public List<Movie> Deserialize()
        {

            using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if (fileStream.Length > 0)
                {
                    return (List<Movie>)formatter.Deserialize(fileStream);
                }
                else
                {
                    return new List<Movie>();
                }
                }
            }
        }
    }



