using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleUI.Classes
{
    public class ReadData
    {
        public static DataTable Source(string [] lines)
        {
            try
            {
                

                //Obtaining column headers
                string headerLine = lines[0];
                string[] headerLabels = headerLine.Split(',');

                //Creating table 
                DataTable table = new DataTable();
                table.Clear();

                //Creating columns
                foreach (string headerlabel in headerLabels)
                {
                    table.Columns.Add(headerlabel);
                }

                //Iterating through rows
                for (int i = 1; i < lines.Length; i++)
                {
                    //Creating 
                    DataRow row = table.NewRow();

                    //Obtaining string in cells of the CSV file
                    string[] dataWords = lines[i].Split(',');

                    //Populating row data  
                    int wordCounter = 0;
                    foreach (string headerlabel in headerLabels)
                    {
                        row[headerlabel] = dataWords[wordCounter++].Trim();
                    }
                    table.Rows.Add(row);
                }

                return table; 


            }
            catch (Exception)
            {

                throw;
            }
        }
           
    }
}
