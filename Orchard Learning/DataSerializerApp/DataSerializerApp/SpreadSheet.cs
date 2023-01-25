using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataSerializerApp
{
    class SpreadSheet
    {
        public static void ExportAsSpreadSheet(List<Person> people, string filePath)
        {
            try
            {
                ExcelMapper mapper = new ExcelMapper();
                mapper.Save(filePath, people, "People Sheet", true);
                Console.WriteLine("Exported successfully, File saved in {0}", filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                Console.WriteLine(ex.Message);
            }
        }
        public static List<Person> ImportFromSpreadSheet(string filePath)
        {
            List<Person> people = null;
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
                people = new ExcelMapper(filePath).Fetch<Person>().ToList<Person>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Heyy... Something went wrong, Lookout for the error message below");
                throw new Exception(ex.Message + " " + filePath);
            }
            return people;
        }
    }
}
