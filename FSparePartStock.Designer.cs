
namespace AutoPartsStore
{
    partial class FSparePartStock
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
            this.dGSparePartStock = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSparePart = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbCell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGSparePartStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 290);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(119, 34);
            this.btnDel.TabIndex = 15;
            this.btnDel.Text = "Удалить запись";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dGSparePartStock
            // 
            this.dGSparePartStock.AllowUserToDeleteRows = false;
            this.dGSparePartStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGSparePartStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGSparePartStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.cmbSparePart,
            this.cmbCell,
            this.Column1});
            this.dGSparePartStock.Location = new System.Drawing.Point(12, 12);
            this.dGSparePartStock.Name = "dGSparePartStock";
            this.dGSparePartStock.RowTemplate.Height = 25;
            this.dGSparePartStock.Size = new System.Drawing.Size(776, 272);
            this.dGSparePartStock.TabIndex = 14;
            this.dGSparePartStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSparePartStock_CellClick);
            this.dGSparePartStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSparePartStock_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 119;
            // 
            // cmbSparePart
            // 
            this.cmbSparePart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbSparePart.HeaderText = "Деталь (артикул)";
            this.cmbSparePart.Name = "cmbSparePart";
            this.cmbSparePart.Width = 96;
            // 
            // cmbCell
            // 
            this.cmbCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbCell.HeaderText = "Место хранения";
            this.cmbCell.Name = "cmbCell";
            this.cmbCell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmbCell.Width = 112;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Кол-во";
            this.Column1.Name = "Column1";
            // 
            // FSparePartStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 336);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dGSparePartStock);
            this.Name = "FSparePartStock";
            this.Text = "Запчасти на складе";
            ((System.ComponentModel.ISupportInitialize)(this.dGSparePartStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dGSparePartStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbSparePart;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}