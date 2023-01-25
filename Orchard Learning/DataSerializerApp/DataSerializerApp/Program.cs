using Ganss.Excel;
using System;
using System.Collections.Generic;

namespace DataSerializerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("######### DATA SERIALZER APP #########");
                bool exitApp = false;
                List<Person> people = new List<Person>();
                people.Add(new Person("Bhuvanesh", 25, 1));
                people.Add(new Person("Shashi", 52, 2));
                people.Add(new Person("Savitha", 49, 3));
                do
                {
                    Console.WriteLine("1. Add person");
                    Console.WriteLine("2. Binary Serialization");
                    Console.WriteLine("3. Xml Serialize");
                    Console.WriteLine("4. Json serialization");
                    Console.WriteLine("5. List people");
                    Console.WriteLine("6. SpreadSheet Export/Import");
                    Console.WriteLine("7. Sorting");
                    Console.WriteLine("8. Exit");

                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter mobile number");
                            long mobileNumber = Convert.ToInt64(Console.ReadLine());
                            people.Add(new Person(name, age, mobileNumber));
                            break;
                        case 2:
                            bool exitBinarySerialize = false;
                            string binarySerialzedFilePath = @"E:\Bhuvanesh N S\Binary_Serialized_File.txt";
                            do
                            {
                                Console.WriteLine("1. Serialize");
                                Console.WriteLine("2. Deserilaize");
                                Console.WriteLine("3. Cancel");

                                Console.WriteLine("Enter your choice");
                                int binarySerializeChoice = Convert.ToInt32(Console.ReadLine());

                                switch (binarySerializeChoice)
                                {
                                    case 1:
                                        DataSerializer.BinarySerialize(people, binarySerialzedFilePath);
                                        break;
                                    case 2:
                                        List<Person> binaryDeserializedPeople = DataSerializer.BinaryDeserialize(binarySerialzedFilePath);
                                        Console.WriteLine("\nBinary desrialzed people details");
                                        Person.Display(binaryDeserializedPeople);
                                        break;
                                    case 3:
                                        exitBinarySerialize = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            } while (!exitBinarySerialize);
                            break;
                        case 3:
                            bool exitXmlSerialize = false;
                            string xmlSerialzedFilePath = @"E:\Bhuvanesh N S\Xml_Serialized_File.xml";
                            do
                            {
                                Console.WriteLine("1. Serialize");
                                Console.WriteLine("2. Deserilaize");
                                Console.WriteLine("3. Cancel");

                                Console.WriteLine("Enter your choice");
                                int xmlSerializeChoice = Convert.ToInt32(Console.ReadLine());

                                switch (xmlSerializeChoice)
                                {
                                    case 1:
                                        DataSerializer.XmlSerialize(typeof(List<Person>), people, xmlSerialzedFilePath);
                                        break;
                                    case 2:
                                        List<Person> xmlDeserializedPeople = DataSerializer.XmlDeserialize(typeof(List<Person>), xmlSerialzedFilePath);
                                        Console.WriteLine("\nXml desrialzed people details");
                                        Person.Display(xmlDeserializedPeople);
                                        break;
                                    case 3:
                                        exitXmlSerialize = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            } while (!exitXmlSerialize);
                            break;
                        case 4:
                            bool exitJsonSerialize = false;
                            string jsonSerialzedFilePath = @"E:\Bhuvanesh N S\Json_Serialized_File.json";
                            do
                            {
                                Console.WriteLine("1. Serialize");
                                Console.WriteLine("2. Deserilaize");
                                Console.WriteLine("3. Cancel");

                                Console.WriteLine("Enter your choice");
                                int jsonSerializeChoice = Convert.ToInt32(Console.ReadLine());

                                switch (jsonSerializeChoice)
                                {
                                    case 1:
                                        DataSerializer.JsonSerialize(people, jsonSerialzedFilePath);
                                        break;
                                    case 2:
                                        List<Person> jsonDeserializedPeople = DataSerializer.JsonDeserialize(jsonSerialzedFilePath);
                                        Console.WriteLine("\nJson desrialzed people details");
                                        Person.Display(jsonDeserializedPeople);
                                        break;
                                    case 3:
                                        exitJsonSerialize = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            } while (!exitJsonSerialize);
                            break;
                        case 6:
                            bool exitSpreadSheetOperation = false;
                            string spreadSheetPath = @"E:\Bhuvanesh N S\People_SpreadSheee1t.xlsx";

                            do
                            {
                                Console.WriteLine("1. Export to spread sheet");
                                Console.WriteLine("2. Import from spread sheet");
                                Console.WriteLine("3. Cancel");

                                Console.WriteLine("Enter your choice");
                                int spreadSheetChoice = Convert.ToInt32(Console.ReadLine());

                                switch (spreadSheetChoice)
                                {
                                    case 1:
                                        SpreadSheet.ExportAsSpreadSheet(people, spreadSheetPath);
                                        break;
                                    case 2:
                                        try
                                        {
                                            List<Person> fetchedPeople = SpreadSheet.ImportFromSpreadSheet(spreadSheetPath);
                                            Console.WriteLine("Imported people details are");
                                            Person.Display(fetchedPeople);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 3:
                                        exitSpreadSheetOperation = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            } while (!exitSpreadSheetOperation);
                            break;
                        case 5:
                            Person.Display(people);
                            break;
                        case 7:
                            bool exitSort = false;

                            do
                            {
                                Console.WriteLine("1. Sort by name");
                                Console.WriteLine("2. Sort by age");
                                Console.WriteLine("3. Sort by mobile number");
                                Console.WriteLine("4. Cancel");

                                Console.WriteLine("Enter your choice");
                                int sortKeyCoice = Convert.ToInt32(Console.ReadLine());

                                switch (sortKeyCoice)
                                {
                                    case 1:
                                        Console.WriteLine("List before sorting");
                                        Person.Display(people);
                                        //Default sort on Name prop, implemented using IComparable<T> interface
                                        people.Sort();
                                        Console.WriteLine("List after sorting");
                                        Person.Display(people);

                                        break;
                                    case 2:
                                        Console.WriteLine("List before sorting");
                                        Person.Display(people);
                                        //sort by age prop, implemented using IComparer<T> interface
                                        SortByAge sortByAge = new SortByAge();
                                        people.Sort(sortByAge);
                                        Console.WriteLine("List after sorting");
                                        Person.Display(people);
                                        break;
                                    case 3:
                                        Console.WriteLine("List before sorting");
                                        Person.Display(people);
                                        //Sort by mobile number using lambda expression
                                        people.Sort((x, y) => { return x.MobileNumber.CompareTo(y.MobileNumber); });
                                        Console.WriteLine("List after sorting");
                                        Person.Display(people);
                                        break;
                                    case 4:
                                        exitSort = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice");
                                        break;
                                }
                            } while (!exitSort);
                            break;
                        case 8:
                            exitApp = true;
                            break;
                        default:
                            Console.WriteLine("Enter valid choice");
                            break;
                    }

                } while (!exitApp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }

        }
    }
}
