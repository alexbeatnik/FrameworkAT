using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ATFramework.Helpers
{
    public class ExelHelpers
    {
        private static List<Datacollection> _dataCol = new List<Datacollection>();

        public static void PopulateCollection(string fileName)
        {
            DataTable table = ExelDataTable(fileName);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection datacol = new Datacollection()
                    {
                        rowNumber = row,
                        columnName = table.Columns[col].ColumnName,
                        columnValue = table.Rows[row - 1][col].ToString()
                    };
                    _dataCol.Add(datacol);
                }
            }
        }

        private static DataTable ExelDataTable(string fileName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader exelReader = ExcelReaderFactory.CreateReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            DataSet dataSet = exelReader.AsDataSet(conf);
            DataTable dataTable = dataSet.Tables[0];
            return dataTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in _dataCol
                    where colData.columnName == columnName && colData.rowNumber == rowNumber
                    select colData.columnValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string columnName { get; set; }
            public string columnValue { get; set; }
        }
    }
}