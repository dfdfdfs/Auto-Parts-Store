using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AutoPartsStore.Models.DB;
using AutoPartsStore.Models;

namespace AutoPartsStore
{
    public partial class FSpareParts : Form
    {
        private readonly DataDB data = new DataDB();
        int IdProd = 0;
        int IdCell = 0;

        public FSpareParts()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGProducts.Rows.Clear();
            List<Products> pr = data.GetProducts();
            dGProducts.AutoGenerateColumns = false;
            foreach (var p in pr)
            {
                dGProducts.Rows.Add(p.IdProduct, p.Name);
            }
        }

        public bool Valid(DataGridViewRow row)
        {
            for (int i = 1; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Value == null)
                    return false;
            }
            return true;
        }

        private void dGProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGProducts.Rows[e.RowIndex];
                IdProd = Convert.ToInt32(row.Cells[0].Value);

                InitCmb();
                InitCell(IdProd);
            }
        }

        private void dGProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGProducts.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddProduct(new Products
                        {
                            Name = row.Cells[1].Value.ToString()
                        });
                        Init();
                        IdProd = 0;
                    }
                    else
                    {
                        data.EditProduct(new Products
                        {
                            IdProduct = Convert.ToInt32(row.Cells[0].Value),
                            Name = row.Cells[1].Value.ToString()
                        });
                    }
                }

            }
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if (IdProd > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Удалить запись?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    data.DelProduct(IdProd);
                    Init();
                }
            }
        }

        public void InitCmb()
        {
            List<Categories> cat = data.GetCategories();
            List<Categories> cC = new List<Categories>();

            foreach (var c in cat)
                cC.Add(new Categories { IdCategory = c.IdCategory, Name = c.Name });

            cmbCategory.DataSource = cC;
            cmbCategory.ValueMember = "IdCategory";
            cmbCategory.DisplayMember = "Name";

            List<Manufacturers> man = data.GetManuf();
            List<Manufacturers> cM = new List<Manufacturers>();

            foreach (var m in man)
                cM.Add(new Manufacturers { IdManufacturer = m.IdManufacturer, Name = m.Name });

            cmbManuf.DataSource = cM;
            cmbManuf.ValueMember = "IdManufacturer";
            cmbManuf.DisplayMember = "Name";

            List<Auto> auto = data.GetAuto();
            List<Auto> cA = new List<Auto>();

            foreach (var a in auto)
                cA.Add(new Auto { IdModel = a.IdModel, ModelBrand = a.ModelBrand });

            cmbModel.DataSource = cA;
            cmbModel.ValueMember = "IdModel";
            cmbModel.DisplayMember = "ModelBrand";
        }

        public void InitCell(int id)
        {
            dGSpareParts.Rows.Clear();
            List<SpareParts> sp = data.GetSpareParts(id);
            dGSpareParts.AutoGenerateColumns = false;
            foreach (var p in sp)
            {
                dGSpareParts.Rows.Add(p.IdSparePart, p.Code, p.FkIdCategory, p.FkIdManuf, p.FkIdModel, p.Price);
            }
        }

        private void dGSpareParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSpareParts.Rows[e.RowIndex];
                IdCell = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGSpareParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSpareParts.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddSparePart(new SpareParts
                        {
                            Code = row.Cells[1].Value.ToString(),
                            FkIdCategory = Convert.ToInt32(row.Cells[2].Value),
                            FkIdManuf = Convert.ToInt32(row.Cells[3].Value),
                            FkIdModel = Convert.ToInt32(row.Cells[4].Value),
                            FkIdProduct = IdProd,
                            Price = Convert.ToDecimal(row.Cells[5].Value)
                        });
                        InitCell(IdProd);
                        IdCell = 0;
                    }
                    else
                    {
                        data.EditSparePart(new SpareParts
                        {
                            IdSparePart = Convert.ToInt32(row.Cells[0].Value),
                            Code = row.Cells[1].Value.ToString(),
                            FkIdCategory = Convert.ToInt32(row.Cells[2].Value),
                            FkIdManuf = Convert.ToInt32(row.Cells[2].Value),
                            FkIdModel = Convert.ToInt32(row.Cells[4].Value),
                            Price = Convert.ToDecimal(row.Cells[5].Value)
                        });
                    }
                }

            }
        }

        private void btnDelSparePart_Click(object sender, EventArgs e)
        {
            if (IdCell > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Удалить запись?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    data.DelSparePart(IdCell);
                    Init();
                }
            }
        }
    }
}
