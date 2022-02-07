using System;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATFramework.Helpers
{
    public class HtmlTableHelper
    {
        private static List<TableDatacollection> _tableDatacollections;

        public static void ReadTable(IWebElement table)
        {
            _tableDatacollections = new List<TableDatacollection>();
            var colums = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));
                if (colDatas.Count != null)
                {
                    foreach (var colValue in colDatas)
                    {
                        _tableDatacollections.Add(new TableDatacollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = colums[colIndex].Text != string.Empty
                                ? colums[colIndex].Text
                                : colIndex.ToString(),
                            ColumnValue = colValue.Text,
                            ColumnSpecialValues = GetControl(colValue)
                        });
                        colIndex++;
                    }

                    rowIndex++;
                }
            }
        }

        private static ColumnSrecialValue GetControl(IWebElement columnValue)
        {
            ColumnSrecialValue columnSrecialValue = null;
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSrecialValue = new ColumnSrecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            }

            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSrecialValue = new ColumnSrecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }

            return columnSrecialValue;
        }

        private static IEnumerable GetDynamicRowData(string columnName, string columnValue)
        {
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table;
            }
        }

        public static void PerformActionOnCell(string columnIndex, string refColumnName, string refColumnValue,
            string controlToOperate = null)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var rowNumber = GetDynamicRowData(refColumnName, refColumnValue).
                ToString().Replace("ATFramework.Helpers.HtmlTableHelper+<GetDynamicRowData>d__", "");
                
            var cell = (from e in _tableDatacollections
                where e.ColumnName == columnIndex && e.RowNumber == Int32.Parse(rowNumber)
                select e.ColumnSpecialValues).SingleOrDefault();
            if (cell != null && cell != null)
            {
                if (cell.ControlType == "hyperLink")
                {
                    var returnedControl = (from c in cell.ElementCollection
                        where c.Text == controlToOperate
                        select c).SingleOrDefault();
                    returnedControl?.Click();
                }

                else if (cell.ControlType == "input")
                {
                    var returnedControl = (from c in cell.ElementCollection
                        where c.GetAttribute("value") == controlToOperate
                        select c).SingleOrDefault();
                    returnedControl?.Click();
                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }
    }

    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public ColumnSrecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSrecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }
}