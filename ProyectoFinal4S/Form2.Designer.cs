namespace ProyectoFinal4S
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvData = new DataGridView();
            btnOpen = new Button();
            cmbClassFilter = new ComboBox();
            btnSave = new Button();
            cmbExportFormat = new ComboBox();
            btnFilterClass = new Button();
            btnExport = new Button();
            btnDelete = new Button();
            btnClearData = new Button();
            cmbDeleteType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(326, 82);
            dgvData.Margin = new Padding(4, 5, 4, 5);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(904, 477);
            dgvData.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(326, 569);
            btnOpen.Margin = new Padding(4, 5, 4, 5);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(141, 55);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // cmbClassFilter
            // 
            cmbClassFilter.FormattingEnabled = true;
            cmbClassFilter.Location = new Point(930, 33);
            cmbClassFilter.Name = "cmbClassFilter";
            cmbClassFilter.Size = new Size(182, 33);
            cmbClassFilter.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(475, 569);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(141, 55);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbExportFormat
            // 
            cmbExportFormat.FormattingEnabled = true;
            cmbExportFormat.Location = new Point(963, 602);
            cmbExportFormat.Name = "cmbExportFormat";
            cmbExportFormat.Size = new Size(144, 33);
            cmbExportFormat.TabIndex = 7;
            // 
            // btnFilterClass
            // 
            btnFilterClass.Location = new Point(1118, 31);
            btnFilterClass.Name = "btnFilterClass";
            btnFilterClass.Size = new Size(112, 34);
            btnFilterClass.TabIndex = 3;
            btnFilterClass.Text = "Filter";
            btnFilterClass.UseVisualStyleBackColor = true;
            btnFilterClass.Click += btnFilterClass_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(1118, 602);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 34);
            btnExport.TabIndex = 8;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(194, 120);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(194, 80);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(112, 34);
            btnClearData.TabIndex = 10;
            btnClearData.Text = "Clear Data";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // cmbDeleteType
            // 
            cmbDeleteType.FormattingEnabled = true;
            cmbDeleteType.Location = new Point(60, 118);
            cmbDeleteType.Name = "cmbDeleteType";
            cmbDeleteType.Size = new Size(116, 33);
            cmbDeleteType.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1243, 750);
            Controls.Add(cmbDeleteType);
            Controls.Add(btnClearData);
            Controls.Add(btnDelete);
            Controls.Add(btnExport);
            Controls.Add(cmbExportFormat);
            Controls.Add(btnSave);
            Controls.Add(btnFilterClass);
            Controls.Add(cmbClassFilter);
            Controls.Add(btnOpen);
            Controls.Add(dgvData);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private Button btnOpen;
        private ComboBox cmbClassFilter;
        private Button btnExport;
        private Button button2;
        private Button btnSave;
        private ComboBox cmbExportFormat;
        private Button btnFilterClass;
        private Button btnDelete;
        private Button btnClearData;
        private ComboBox cmbDeleteType;
    }
}