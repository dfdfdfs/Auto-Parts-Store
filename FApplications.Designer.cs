
namespace AutoPartsStore
{
    partial class FApplications
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
            this.btnDel = new System.Windows.Forms.Button();
            this.dGApp = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbClients = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbSparePart = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGApp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 331);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(119, 34);
            this.btnDel.TabIndex = 19;
            this.btnDel.Text = "Удалить запись";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dGApp
            // 
            this.dGApp.AllowUserToDeleteRows = false;
            this.dGApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.cmbClients,
            this.cmbSparePart});
            this.dGApp.Location = new System.Drawing.Point(12, 12);
            this.dGApp.Name = "dGApp";
            this.dGApp.RowTemplate.Height = 25;
            this.dGApp.Size = new System.Drawing.Size(669, 313);
            this.dGApp.TabIndex = 18;
            this.dGApp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGApp_CellClick);
            this.dGApp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGApp_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 119;
            // 
            // cmbClients
            // 
            this.cmbClients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbClients.HeaderText = "Клиент";
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbClients.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmbClients.Width = 71;
            // 
            // cmbSparePart
            // 
            this.cmbSparePart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmbSparePart.HeaderText = "Деталь (артикул)";
            this.cmbSparePart.Name = "cmbSparePart";
            // 
            // FApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 374);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dGApp);
            this.Name = "FApplications";
            this.Text = "Заявки на детали";
            ((System.ComponentModel.ISupportInitialize)(this.dGApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dGApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbClients;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbSparePart;
    }
}