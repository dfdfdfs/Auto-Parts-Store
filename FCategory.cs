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
    public partial class FCategory : Form
    {
        private readonly DataDB data = new DataDB();
        int IdCategory = 0;

        public FCategory()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGCategory.Rows.Clear();
            List<Categories> cat = data.GetCategories();
            dGCategory.AutoGenerateColumns = false;
            foreach (Categories c in cat)
            {
                dGCategory.Rows.Add(c.IdCategory, c.Name);
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

        private void dGCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGCategory.Rows[e.RowIndex];
                IdCategory = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGCategory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGCategory.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddCategory(new Categories
                        {
                            Name = row.Cells[1].Value.ToString()
                        });
                        Init();
                        IdCategory = 0;
                    }
                    else
                    {
                        data.EditCategory(new Categories
                        {
                            IdCategory = Convert.ToInt32(row.Cells[0].Value),
                            Name = row.Cells[1].Value.ToString()
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdCategory > 0)
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
                    data.DelCategory(IdCategory);
                    Init();
                }
            }
        }
    }
}
