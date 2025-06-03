namespace ProyectoFinal4S
{
    partial class Form3
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            btnAPI = new Button();
            btnDataSet = new Button();
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // btnAPI
            // 
            btnAPI.Font = new Font("Yu Gothic", 11.25F);
            btnAPI.Location = new Point(544, 347);
            btnAPI.Margin = new Padding(4, 5, 4, 5);
            btnAPI.Name = "btnAPI";
            btnAPI.Size = new Size(177, 68);
            btnAPI.TabIndex = 0;
            btnAPI.Text = "NASA API";
            btnAPI.UseVisualStyleBackColor = true;
            btnAPI.Click += btnAPI_Click;
            // 
            // btnDataSet
            // 
            btnDataSet.Font = new Font("Yu Gothic", 11.25F);
            btnDataSet.Location = new Point(544, 444);
            btnDataSet.Margin = new Padding(4, 5, 4, 5);
            btnDataSet.Name = "btnDataSet";
            btnDataSet.Size = new Size(177, 60);
            btnDataSet.TabIndex = 1;
            btnDataSet.Text = "DATA SET";
            btnDataSet.UseVisualStyleBackColor = true;
            btnDataSet.Click += btnDataSet_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1174, 792);
            Controls.Add(btnDataSet);
            Controls.Add(btnAPI);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAPI;
        private Button btnDataSet;
        private NotifyIcon notifyIcon1;
    }
}