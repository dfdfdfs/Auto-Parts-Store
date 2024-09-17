using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AutoPartsStore.Models.DB;

namespace AutoPartsStore
{
    public partial class FBrands : Form
    {
        private readonly DataDB data = new DataDB();
        int IdBrand = 0;

        public FBrands()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGBrands.Rows.Clear();
            List<Brands> brands = data.GetBrands();
            dGBrands.AutoGenerateColumns = false;
            foreach (Brands b in brands)
            {
                dGBrands.Rows.Add(b.IdBrand, b.Name);
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

        private void dGBrands_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGBrands.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddBrand(new Brands
                        {
                            Name = row.Cells[1].Value.ToString()
                        });
                        Init();
                        IdBrand = 0;
                    }
                    else
                    {
                        data.EditBrand(new Brands
                        {
                            IdBrand = Convert.ToInt32(row.Cells[0].Value),
                            Name = row.Cells[1].Value.ToString()
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdBrand > 0)
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
                    data.DelBrand(IdBrand);
                    Init();
                }
            }
        }

        private void dGBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGBrands.Rows[e.RowIndex];
                IdBrand = Convert.ToInt32(row.Cells[0].Value);
            }
        }
    }
}
