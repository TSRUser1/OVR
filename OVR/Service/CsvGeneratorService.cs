using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CsvHelper;
using OVR.Core;

namespace OVR.Service
{
    public class CsvGeneratorService
    {
        public object ReadCsvFile<type>(string filePath)
        {

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var readObject = csv.GetRecords<type>();
                return readObject;
            }
        }

        public void WriteCsvFile(string fileName, IEnumerable writeObject)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dirName = $@"{docPath}\"+fileName+".csv";
            using (var writer = new StreamWriter(dirName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(writeObject);
            }

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
  .Single(str => str.EndsWith("Testing.rpt"));

            var something = assembly.GetManifestResourceInfo(resourceName);

            ReportDocument Cr = new ReportDocument();
            Cr.Load(@"C:\ABODGit\OVR\OVR\Reports\Testing.rpt");
            Cr.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\diu\shitty.pdf");
        }

        //public static DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection properties =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    foreach (PropertyDescriptor prop in properties)
        //        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        //    foreach (T item in data)
        //    {
        //        DataRow row = table.NewRow();
        //        foreach (PropertyDescriptor prop in properties)
        //            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //        table.Rows.Add(row);
        //    }
        //    return table;
        //}
    }
}
