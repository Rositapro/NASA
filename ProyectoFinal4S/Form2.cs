﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics;

namespace ProyectoFinal4S
{
    public partial class Form2 : Form
    {
        // Lista para guardar todas las filas leídas del CSV
        private List<string[]> allRows = new List<string[]>();
        public Form2()
        {
            InitializeComponent();
            //// Asociar eventos
            this.Load += Form2_Load;
            btnFilterClass.Click += btnFilterClass_Click;
            //btnOpen.Click += btnOpen_Click;
            //btnSave.Click += btnSave_Click;
            //btnExport.Click += btnExport_Click;
        }
        // Evento Load: llenar ComboBox con opciones de clase
        private void Form2_Load(object sender, EventArgs e)
        {
            cmbClassFilter.Items.Clear();
            cmbClassFilter.Items.AddRange(new string[] { "TODOS", "STAR", "GALAXY", "QSO" });
            cmbClassFilter.SelectedIndex = 0; // Por defecto "TODOS"

            cmbExportFormat.Items.Clear();
            cmbExportFormat.Items.AddRange(new string[] { "CSV", "TXT", "JSON", "XML" });
            cmbExportFormat.SelectedIndex = 0;

            cmbDeleteType.Items.Clear();
            cmbDeleteType.Items.AddRange(new string[] { "Fila", "Columna" });
            cmbDeleteType.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV and TXT files (*.csv;*.txt)|*.csv;*.txt";
            openFileDialog.Title = "Open file";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            try
            {
                var lines = File.ReadAllLines(filePath);

                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                allRows.Clear();

                if (lines.Length > 0)
                {
                    char delimiter = ',';

                    var headers = lines[0].Split(delimiter);
                    foreach (var header in headers)
                    {
                        dgvData.Columns.Add(header, header);
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        var row = lines[i].Split(delimiter);
                        allRows.Add(row);
                    }

                    DisplayRows(allRows);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }


        }
        // Función para mostrar filas en DataGridView
        private void DisplayRows(List<string[]> rows)
        {
            dgvData.Rows.Clear();
            foreach (var row in rows)
            {
                dgvData.Rows.Add(row);
            }
        }

        private void btnFilterClass_Click(object sender, EventArgs e)
        {
            string filtroSeleccionado = cmbClassFilter.SelectedItem.ToString();

            // Buscar índice de la columna "class"
            int indexClass = -1;
            foreach (DataGridViewColumn col in dgvData.Columns)
            {
                if (col.HeaderText.Equals("class", StringComparison.OrdinalIgnoreCase))
                {
                    indexClass = col.Index;
                    break;
                }
            }

            if (indexClass == -1)
            {
                MessageBox.Show("No se encontró la columna 'class'.");
                return;
            }

            // Mostrar todas las filas si seleccionó "TODOS"
            if (filtroSeleccionado.Equals("TODOS", StringComparison.OrdinalIgnoreCase))
            {
                DisplayRows(allRows);
                return;
            }

            // Filtrar filas que coincidan exactamente con el filtro seleccionado (insensible a mayúsculas)
            var filasFiltradas = allRows.Where(row =>
                row.Length > indexClass &&
                row[indexClass].Equals(filtroSeleccionado, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            DisplayRows(filasFiltradas);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cmbExportFormat.SelectedItem == null)
                return;

            string formato = cmbExportFormat.SelectedItem.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            switch (formato)
            {
                case "CSV":
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog.Title = "Exportar a CSV";
                    break;
                case "TXT":
                    saveFileDialog.Filter = "TXT files (*.txt)|*.txt";
                    saveFileDialog.Title = "Exportar a TXT";
                    break;
                case "JSON":
                    saveFileDialog.Filter = "JSON files (*.json)|*.json";
                    saveFileDialog.Title = "Exportar a JSON";
                    break;
                case "XML":
                    saveFileDialog.Filter = "XML files (*.xml)|*.xml";
                    saveFileDialog.Title = "Exportar a XML";
                    break;
            }

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string ruta = saveFileDialog.FileName;

            try
            {
                switch (formato)
                {
                    case "CSV":
                        GuardarArchivoCSV(ruta);
                        break;
                    case "TXT":
                        GuardarArchivoTXT(ruta);
                        break;
                    case "JSON":
                        ExportarAJSON(ruta);
                        break;
                    case "XML":
                        ExportarAXML(ruta);
                        break;
                }
                MessageBox.Show($"Archivo exportado correctamente en formato {formato}.");

                // Abrir el archivo con la aplicación predeterminada
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exportando archivo: " + ex.Message);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|TXT files (*.txt)|*.txt";
            saveFileDialog.Title = "Save file";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string ruta = saveFileDialog.FileName;
            string ext = Path.GetExtension(ruta).ToLower();

            try
            {
                if (ext == ".txt")
                    GuardarArchivoTXT(ruta);
                else
                    GuardarArchivoCSV(ruta);

                MessageBox.Show("Archivo guardado correctamente.");

                // Abrir el archivo guardado automáticamente
                Process.Start(new ProcessStartInfo()
                {
                    FileName = ruta,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando archivo: " + ex.Message);
            }
        }

        public void GuardarArchivoCSV(string ruta)
        {
            var lines = new List<string>();

            var headers = dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
            lines.Add(string.Join(",", headers));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => EscapeForCsv(cell.Value?.ToString() ?? ""));
                    lines.Add(string.Join(",", cells));
                }
            }

            File.WriteAllLines(ruta, lines);
        }

        private string EscapeForCsv(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }

        public void GuardarArchivoTXT(string ruta)
        {
            var lines = new List<string>();

            var headers = dgvData.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
            lines.Add(string.Join("\t", headers));

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString() ?? "");
                    lines.Add(string.Join("\t", cells));
                }
            }

            File.WriteAllLines(ruta, lines);
        }

        public void ExportarAJSON(string ruta)
        {
            var listaObjetos = new List<Dictionary<string, string>>();

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var dict = new Dictionary<string, string>();
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? "";
                        dict[col.HeaderText] = valor;
                    }
                    listaObjetos.Add(dict);
                }
            }

            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(listaObjetos, opciones);

            File.WriteAllText(ruta, jsonString);
        }

        public void ExportarAXML(string ruta)
        {
            var root = new XElement("Registros");

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (!row.IsNewRow)
                {
                    var registro = new XElement("Registro");
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        var valor = row.Cells[col.Index].Value?.ToString() ?? "";
                        registro.Add(new XElement(col.HeaderText, valor));
                    }
                    root.Add(registro);
                }
            }

            var doc = new XDocument(root);
            doc.Save(ruta);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentCell == null)
            {
                MessageBox.Show("Selecciona una celda para eliminar la fila o columna correspondiente.");
                return;
            }

            string opcion = cmbDeleteType.SelectedItem.ToString();

            if (opcion == "Fila")
            {
                int rowIndex = dgvData.CurrentCell.RowIndex;

                var confirm = MessageBox.Show($"¿Eliminar fila {rowIndex + 1}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dgvData.Rows.RemoveAt(rowIndex);
                    if (rowIndex < allRows.Count)
                        allRows.RemoveAt(rowIndex);
                }
            }
            else if (opcion == "Columna")
            {
                int colIndex = dgvData.CurrentCell.ColumnIndex;
                string colName = dgvData.Columns[colIndex].HeaderText;

                var confirm = MessageBox.Show($"¿Eliminar columna '{colName}'?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    dgvData.Columns.RemoveAt(colIndex);

                    // Actualizar allRows para eliminar esa columna
                    for (int i = 0; i < allRows.Count; i++)
                    {
                        var listRow = allRows[i].ToList();
                        if (colIndex < listRow.Count)
                            listRow.RemoveAt(colIndex);
                        allRows[i] = listRow.ToArray();
                    }
                }
            }

            //if (dgvData.CurrentRow == null)
            //{
            //    MessageBox.Show("Selecciona una fila para eliminar.");
            //    return;
            //}

            //int rowIndex = dgvData.CurrentRow.Index;

            //var confirmResult = MessageBox.Show($"¿Seguro que quieres eliminar la fila {rowIndex + 1}?",
            //                                    "Confirmar eliminación",
            //                                    MessageBoxButtons.YesNo);

            //if (confirmResult == DialogResult.Yes)
            //{
            //    // Eliminar fila del DataGridView
            //    dgvData.Rows.RemoveAt(rowIndex);

            //    // Eliminar fila de la lista interna allRows
            //    if (rowIndex < allRows.Count)
            //    {
            //        allRows.RemoveAt(rowIndex);
            //    }
            //}
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que quieres limpiar toda la tabla?",
                                        "Confirmar limpieza",
                                        MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                dgvData.Rows.Clear();
                dgvData.Columns.Clear();
                allRows.Clear();
            }
        }
    }
}
