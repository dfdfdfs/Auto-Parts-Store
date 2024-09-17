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
    public partial class FStock : Form
    {
        private readonly DataDB data = new DataDB();
        int IdStock= 0;

        public FStock()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGStock.Rows.Clear();
            List<Stock> st = data.GetStocks();
            dGStock.AutoGenerateColumns = false;
            foreach (var s in st)
            {
                dGStock.Rows.Add(s.IdStock, s.Number, s.Address);
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

        private void dGStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGStock.Rows[e.RowIndex];
                IdStock = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGStock.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        Stock st = new Stock();
                        st.Number = Convert.ToInt32(row.Cells[1].Value);
                        if (!string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                        {
                            st.Address = row.Cells[2].Value.ToString();
                        }
                        data.AddStock(st);
                        Init();
                        IdStock = 0;
                    }
                    else
                    {
                        data.EditStock(new Stock
                        {
                            IdStock = Convert.ToInt32(row.Cells[0].Value),
                            Number = Convert.ToInt32(row.Cells[1].Value),
                            Address = row.Cells[2].Value.ToString()
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdStock > 0)
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
                    data.DelStock(IdStock);
                    Init();
                }
            }
        }
    }
}
