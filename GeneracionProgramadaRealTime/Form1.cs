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
        string[] Names = new string[20];
        double[,] Gen = new double[20, 24];
        string path;
        public System.Windows.Forms.Timer timer;
        public string dia1, dia2;

        public Form1()
        {
            InitializeComponent();
            path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\";
            //path = "\";
            populateNames();
            setAllTrue();
            resetGen();
            getData();

            this.TopMost = true;
            dia1 = DateTime.Now.ToLocalTime().ToLongDateString();



            timer = new System.Windows.Forms.Timer();
            timer.Interval = (1000 * 60 * 3);
            timer.Tick += new EventHandler(updateValues);
            timer.Start();





        }

        private void updateValues(object sender, EventArgs e)
        {
            dia2 = DateTime.Now.ToLocalTime().ToLongDateString();
            if (dia1 != dia2)
            {
                dia1 = dia2;
                resetGen();
                getData();
            }
            else
            {
                fillDataMainPanel();
            }
        }

        private void resetGen()
        {
            //Console.WriteLine(Gen.Length);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    Gen[i, j] = 0;
                }
            }
        }

        private void CheckedBoxCentrales_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainPanel.Items.Clear();
            int hora = DateTime.Now.Hour;
            for (int i = 0; i < Lista1.Items.Count; i++)
            {
                if (Lista1.GetItemChecked(i))
                {
                    if (Names[i] == null) break;
                    ListViewItem item = new ListViewItem();
                    item.Text = (string)Lista1.Items[i];
                    item.SubItems.Add(Gen[i, hora].ToString());
                    MainPanel.Items.Add(item);
                }


            }
        }

        private void populateNames()
        {
            for (int i = 0; i < Lista1.Items.Count; i++)
            {
                Names[i] = Lista1.Items[i].ToString().ToLower();
            }
        }

        public void getData()
        {
            string name = "PRG" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + ".xlsx";
            string filename = path + name;
            
            if (!File.Exists(filename))
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    MessageBox.Show("Seleccione Carpeta con Programas");
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {

                        path = fbd.SelectedPath + @"\";
                        getData();
                        return;
                        //filename = path + name;
                        //if (!File.Exists(filename))
                        //{
                        //    getData();
                        //    return;
                        //}
                    }
                }
            }
            FileInfo fi = new FileInfo(filename);
            using (ExcelPackage xlPackage = new ExcelPackage(fi))
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

                    for (int j = 100; j < Data.Length; j++)
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
                //Application.OpenForms["Form1"].BringToFront();
            }
        }

        public void fillDataMainPanel()
        {
            MainPanel.Items.Clear();
            int hora = DateTime.Now.ToLocalTime().Hour;
            for (int i = 0; i < Lista1.Items.Count; i++)
            {
                if (Lista1.GetItemChecked(i))
                {
                    if (Names[i] == null) break;
                    ListViewItem item = new ListViewItem();
                    item.Text = (string)Lista1.Items[i];
                    item.SubItems.Add(Gen[i, hora].ToString());
                    MainPanel.Items.Add(item);
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(207, 322);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(592, 322);
        }

        public void setAllTrue()
        {
            for (int i = 0; i < Lista1.Items.Count; i++)
            {
                Lista1.SetItemChecked(i, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    //string[] files = Directory.GetFiles(fbd.SelectedPath);

                    //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    //MessageBox.Show(fbd.SelectedPath);
                    path = fbd.SelectedPath + @"\";
                }
            }
            //this.TopMost = true;
            getData();
            this.BringToFront();
           
            //Application.OpenForms["Form1"].BringToFront();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.TopMost = !this.TopMost;
        }
    }
}
