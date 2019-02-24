﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GeneracionProgramadaRealTime
{
    public partial class Form1 : Form
    {
        string[] Data;
        string[] Names = new string[10];
        double[,] Gen = new double[10,24];
        public Form1()
        {
            InitializeComponent();
            populateNames();
            resetGen();
            getData();


        }
        
        private void resetGen()
        {
            //Console.WriteLine(Gen.Length);
            for(int i=0;i<10;i++)
            {
                for(int j = 0; j < 24; j++)
                {
                    Gen[i, j] = 0;
                }
            }
        }

        private void CheckedBoxCentrales_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainPanel.Items.Clear();
            int hora = DateTime.Now.Hour;
            for (int i = 0; i < CheckedBoxCentrales.Items.Count; i++)
            {
                if (CheckedBoxCentrales.GetItemChecked(i))
                {
                    if (Names[i] == null) break;
                    ListViewItem item = new ListViewItem();
                    item.Text = (string)CheckedBoxCentrales.Items[i];
                    item.SubItems.Add(Gen[i,hora].ToString());
                    MainPanel.Items.Add(item);
                }


            }
        }

        private void populateNames()
        {
            for (int i = 0; i < CheckedBoxCentrales.Items.Count; i++)
            {
                Names[i] = CheckedBoxCentrales.Items[i].ToString().ToLower();
            }
        }

        public void getData()
        {
            string name = "PRG" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + ".xlsx";
            string path = @"C:\Users\ignac\source\repos\GeneracionProgramadaRealTime\GeneracionProgramadaRealTime\bin\Debug\";
            string filename = path + name;
            using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(filename)))
            {
                resetGen();
                var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                var sb = new StringBuilder(); //this is your your data
                for (int rowNum = 1; rowNum <= totalRows; rowNum++) //selet starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    sb.AppendLine(string.Join(",", row));
                }
                Data = sb.ToString().ToLower().Split();
                //Console.WriteLine(Data[100]);

                for (int i = 0; i < Names.Length; i++)
                {
                    if (Names[i] == null) break;

                    string central = Names[i];

                    for (int j = 0; j < Data.Length; j++)
                    {

                        string[] linea = Data[j].Split(',');


                        if (Data[j].Contains("trayectoria"))
                        {
                            break;
                        }
                        if (linea[0].Contains(central))
                        {
                            for (int h = 0; h < 24; h++)
                            {
                                //suma = suma + Double.Parse(linea[2]);
                                Gen[i, h] = Gen[i, h] + Double.Parse(linea[h + 2]);
                            }

                        }
                    }
                }
                fillDataMainPanel();
            }
        }

        public void fillDataMainPanel()
        {
            int hora = DateTime.Now.Hour;
            for (int i = 0; i < Names.Length; i++)
            {   
                if (Names[i] == null) break;
                ListViewItem item = new ListViewItem();
                item.Text = (string)CheckedBoxCentrales.Items[i];
                item.SubItems.Add(Gen[i, hora].ToString());
                MainPanel.Items.Add(item);
            }
        }

    }
}
