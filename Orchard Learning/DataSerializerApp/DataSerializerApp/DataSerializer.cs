using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataSerializerApp
{
    class DataSerializer
    {
        //Binary Serializer methods
        public static void BinarySerialize(List<Person> people, string filePath)
        {
            FileStream fileStream = null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                fileStream = File.Create(filePath);
                binaryFormatter.Serialize(fileStream, people);
                Console.WriteLine("Binary serialization successful, File saved in {0}", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static List<Person> BinaryDeserialize(string filePath)
        {
            List<Person> people = null;
            FileStream fileStream = null;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

                fileStream = File.OpenRead(filePath);
                people = (List<Person>)binaryFormatter.Deserialize(fileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream.Close();
            }
            return people;
        }

        //Xml Serializer methods
        //this is for single person object
        public static void XmlSerialize(Type dataType, Person person, string filePath)
        {
            TextWriter textWriter = null;
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                textWriter = new StreamWriter(filePath);
                XmlSerializer xmlSerializer = new XmlSerializer(dataType);
                xmlSerializer.Serialize(textWriter, person);
                Console.WriteLine("Xml serialization successful, File save in {0}", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                textWriter.Close();
            }
        }
        //this is for list of  person object

        public static void XmlSerialize(Type dataType, List<Person> people, string filePath)
        {
            TextWriter textWriter = null;
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                textWriter = new StreamWriter(filePath);
                XmlSerializer xmlSerializer = new XmlSerializer(dataType);
                xmlSerializer.Serialize(textWriter, people);
                Console.WriteLine("Xml serialization successful, File saved in {0}", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                textWriter.Close();
            }
        }

        public static List<Person> XmlDeserialize(Type dataType, string filePath)
        {
            List<Person> people = null;
            TextReader textReader = null;
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
                XmlSerializer xmlSerializer = new XmlSerializer(dataType);
                textReader = new StreamReader(filePath);
                people = (List<Person>)xmlSerializer.Deserialize(textReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                textReader.Close();
            }
            return people;
        }

        //JSON serialization methods
        public static void JsonSerialize(List<Person> people, string filePath)
        {
            StreamWriter streamWriter = null;
            JsonWriter jsonWriter = null;
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                streamWriter = new StreamWriter(filePath);
                jsonWriter = new JsonTextWriter(streamWriter);
                jsonSerializer.Serialize(jsonWriter, people);
                Console.WriteLine("Json serialization successful, File saved in {0}", filePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                streamWriter.Close();
                jsonWriter.Close();
            }
        }
        public static List<Person> JsonDeserialize(string filePath)
        {
            List<Person> people = null;
            StreamReader streamReader = null;
            JsonReader jsonReader = null;
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

                streamReader = new StreamReader(filePath);
                jsonReader = new JsonTextReader(streamReader);
                people = jsonSerializer.Deserialize<List<Person>>(jsonReader);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                streamReader.Close();
                jsonReader.Close();
            }
            return people;
        }

    }
}
