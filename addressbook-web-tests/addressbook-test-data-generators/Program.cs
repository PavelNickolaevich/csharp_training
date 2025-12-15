using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebAddressBookTests;
using Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter streamWriter = new StreamWriter(args[1]);
            string format = args[2];
            string dataType = args[3];

            switch (dataType.ToLower())
            {
                case "groups":
                     GenerateGroupsData(count, format, streamWriter, args[1]);
                     break;
                case "contacts":
                    GenerateContactsData(count, format, streamWriter);
                    break;
                default:
                    throw new Exception("Unknown data type: " + dataType);
            }
                streamWriter.Close();
        }


        private static void GenerateGroupsData(int count, string format, StreamWriter streamWriter, string filename)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
                {
                    Header = BaseTest.GenerateRandomString(10),
                    Footer = BaseTest.GenerateRandomString(10)
                });
            }
            switch (format.ToLower())
            {
                case "csv":
                    WriteGroupsToCsvFile(groups, streamWriter);
                    break;
                case "xml":
                    WriteToXmlFile(groups, streamWriter);
                    break;
                case "json":
                    WriteToJsonFile(groups, streamWriter);
                    break;
                case "excel":
                    WriteGroupsToExcelFile(groups, filename);
                    break;
                default:
                    throw new Exception("Unknown format file: " + format);
            }
        }
        private static void GenerateContactsData(int count, string format, StreamWriter writer)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                ContactData.DateInfo dateInfo = BaseTest.GenerateDate();

                contacts.Add(
                        new ContactData(
                           BaseTest.GenerateName(5),
                           BaseTest.GenerateName(5),
                           BaseTest.GenerateName(5),
                           BaseTest.GenerateName(5),
                             new ContactData.DateInfo(dateInfo.Day, dateInfo.Month, dateInfo.Year)));
            }

            WriteToFile(contacts, format, writer);
        }
         static void WriteGroupsToCsvFile(List<GroupData> groupData, StreamWriter writer)
        {
            foreach (GroupData data in groupData)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                 data.Name,
                 data.Header,
                 data.Footer
               ));
            }
        }

        static void WriteToFile<T>(List<T> data, string format, StreamWriter writer)
        {
            switch (format.ToLower())
            {
                case "xml":
                    WriteToXmlFile(data, writer);
                    break;
                case "json":
                    WriteToJsonFile(data, writer);
                    break;
                default:
                    throw new Exception("Unknown format file: " + format);
            }
        }

        static void WriteToXmlFile<T>(List<T> data, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<T>)).Serialize(writer, data);
        }

        static void WriteToJsonFile<T>(List<T> data, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented));
        }

        private static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = new Excel.Workbook();
            Excel.Worksheet worksheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                worksheet.Cells[row, 1] = group.Name;
                worksheet.Cells[row, 2] = group.Header;
                worksheet.Cells[row, 3] = group.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
        }
    }
}
