
namespace AutoPartsStore
{
    partial class FSales
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
            this.dGSales = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSparePart = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbClients = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGSales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 331);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(119, 34);
            this.btnDel.TabIndex = 17;
            this.btnDel.Text = "Удалить запись";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dGSales
            // 
            this.dGSales.AllowUserToDeleteRows = false;
            this.dGSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.cmbSparePart,
            this.cmbClients,
            this.Column1,
            this.Column3});
            this.dGSales.Location = new System.Drawing.Point(12, 12);
            this.dGSales.Name = "dGSales";
            this.dGSales.RowTemplate.Height = 25;
            this.dGSales.Size = new System.Drawing.Size(776, 313);
            this.dGSales.TabIndex = 16;
            this.dGSales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSales_CellClick);
            this.dGSales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSales_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 119;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Дата продажи";
            this.Column2.Name = "Column2";
            this.Column2.Width = 109;
            // 
            // cmbSparePart
            // 
            this.cmbSparePart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbSparePart.HeaderText = "Деталь (артикул)";
            this.cmbSparePart.Name = "cmbSparePart";
            this.cmbSparePart.Width = 96;
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
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Кол-во";
            this.Column1.Name = "Column1";
            this.Column1.Width = 71;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Стоимость";
            this.Column3.Name = "Column3";
            // 
            // FSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dGSales);
            this.Name = "FSales";
            this.Text = "Продажи";
            ((System.ComponentModel.ISupportInitialize)(this.dGSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dGSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbSparePart;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}