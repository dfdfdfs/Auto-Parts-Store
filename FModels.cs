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
    public partial class FModels : Form
    {
        private readonly DataDB data = new DataDB();
        int IdModel = 0;

        public FModels()
        {
            InitializeComponent();

            List<Brands> brands = data.GetBrands();
            List<Brands> cB = new List<Brands>();

            foreach (var b in brands)
                cB.Add(new Brands { IdBrand = b.IdBrand, Name = b.Name });

            cmbBrands.DataSource = cB;
            cmbBrands.ValueMember = "IdBrand";
            cmbBrands.DisplayMember = "Name";

            Init();
        }

        public void Init()
        {
            dGModels.Rows.Clear();
            List<Models.DB.Models> models = data.GetModels();
            dGModels.AutoGenerateColumns = false;
            foreach (var m in models)
            {
                dGModels.Rows.Add(m.IdModel, m.FkIdBrand, m.Name);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdModel > 0)
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
                    data.DelModel(IdModel);
                    Init();
                    IdModel = 0;
                }
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

        private void dGModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGModels.Rows[e.RowIndex];
                IdModel = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGModels_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGModels.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddModel(new Models.DB.Models
                        {
                            FkIdBrand = Convert.ToInt32(row.Cells[1].Value),
                            Name = row.Cells[2].Value.ToString()
                        });
                        Init();
                        IdModel = 0;
                    }
                    else
                    {
                        data.EditModel(new Models.DB.Models
                        {
                            IdModel = Convert.ToInt32(row.Cells[0].Value),
                            FkIdBrand = Convert.ToInt32(row.Cells[1].Value),
                            Name = row.Cells[2].Value.ToString()
                        });
                    }
                }
            }
        }
    }
}
