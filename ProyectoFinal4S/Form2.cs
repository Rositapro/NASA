using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal4S
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "csv files |*.csv";
            openFileDialog.Title = "Open csv file";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string filePath = openFileDialog.FileName;
            try
            {
                var lines = File.ReadAllLines(filePath);

                dgvData.Rows.Clear();
                dgvData.Columns.Clear();

                if (lines.Length > 0)
                {
                    var headers = lines[0].Split(',');

                    foreach (var header in headers)
                    {
                        dgvData.Columns.Add(header, header);
                    }


                    for (int i = 1; i < lines.Length; i++)
                    {
                        var row = lines[i].Split(',');
                        dgvData.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data");
            }
        }
    }
}
