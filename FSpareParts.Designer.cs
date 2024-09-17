
namespace AutoPartsStore
{
    partial class FSpareParts
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
            this.btnDelProduct = new System.Windows.Forms.Button();
            this.dGProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dGSpareParts = new System.Windows.Forms.DataGridView();
            this.btnDelSparePart = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbManuf = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGSpareParts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelProduct
            // 
            this.btnDelProduct.Location = new System.Drawing.Point(12, 178);
            this.btnDelProduct.Name = "btnDelProduct";
            this.btnDelProduct.Size = new System.Drawing.Size(119, 34);
            this.btnDelProduct.TabIndex = 8;
            this.btnDelProduct.Text = "Удалить запись";
            this.btnDelProduct.UseVisualStyleBackColor = true;
            this.btnDelProduct.Click += new System.EventHandler(this.btnDelProduct_Click);
            // 
            // dGProducts
            // 
            this.dGProducts.AllowUserToDeleteRows = false;
            this.dGProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dGProducts.Location = new System.Drawing.Point(12, 12);
            this.dGProducts.Name = "dGProducts";
            this.dGProducts.RowTemplate.Height = 25;
            this.dGProducts.Size = new System.Drawing.Size(830, 160);
            this.dGProducts.TabIndex = 7;
            this.dGProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGProducts_CellClick);
            this.dGProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGProducts_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Идентификатор";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 119;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Наименование";
            this.Column2.Name = "Column2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Информация";
            // 
            // dGSpareParts
            // 
            this.dGSpareParts.AllowUserToDeleteRows = false;
            this.dGSpareParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGSpareParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGSpareParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.cmbCategory,
            this.cmbManuf,
            this.cmbModel,
            this.Column4});
            this.dGSpareParts.Location = new System.Drawing.Point(12, 264);
            this.dGSpareParts.Name = "dGSpareParts";
            this.dGSpareParts.RowTemplate.Height = 25;
            this.dGSpareParts.Size = new System.Drawing.Size(830, 131);
            this.dGSpareParts.TabIndex = 10;
            this.dGSpareParts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSpareParts_CellClick);
            this.dGSpareParts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGSpareParts_CellEndEdit);
            // 
            // btnDelSparePart
            // 
            this.btnDelSparePart.Location = new System.Drawing.Point(12, 401);
            this.btnDelSparePart.Name = "btnDelSparePart";
            this.btnDelSparePart.Size = new System.Drawing.Size(119, 34);
            this.btnDelSparePart.TabIndex = 11;
            this.btnDelSparePart.Text = "Удалить запись";
            this.btnDelSparePart.UseVisualStyleBackColor = true;
            this.btnDelSparePart.Click += new System.EventHandler(this.btnDelSparePart_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Идентификатор";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 119;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Артикул";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // cmbCategory
            // 
            this.cmbCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbCategory.HeaderText = "Категория";
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Width = 69;
            // 
            // cmbManuf
            // 
            this.cmbManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbManuf.HeaderText = "Поставщик";
            this.cmbManuf.Name = "cmbManuf";
            this.cmbManuf.Width = 76;
            // 
            // cmbModel
            // 
            this.cmbModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cmbModel.HeaderText = "Авто";
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Width = 39;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Стоимость";
            this.Column4.Name = "Column4";
            // 
            // FSpareParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 444);
            this.Controls.Add(this.btnDelSparePart);
            this.Controls.Add(this.dGSpareParts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelProduct);
            this.Controls.Add(this.dGProducts);
            this.Name = "FSpareParts";
            this.Text = "Запчасти";
            ((System.ComponentModel.ISupportInitialize)(this.dGProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGSpareParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelProduct;
        private System.Windows.Forms.DataGridView dGProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGSpareParts;
        private System.Windows.Forms.Button btnDelSparePart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbManuf;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}