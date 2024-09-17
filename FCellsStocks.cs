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
    public partial class FCellsStocks : Form
    {
        private readonly DataDB data = new DataDB();
        int IdCell = 0;

        public FCellsStocks()
        {
            InitializeComponent();

            List<Stock> stocks = data.GetStocks();
            List<Stock> cS = new List<Stock>();

            foreach (var s in stocks)
                cS.Add(new Stock { IdStock = s.IdStock, Number = s.Number });

            cmbStock.DataSource = cS;
            cmbStock.ValueMember = "IdStock";
            cmbStock.DisplayMember = "Number";

            Init();
        }

        public void Init()
        {
            dGCellStock.Rows.Clear();
            List<CellsStocks> cs = data.GetCellsStock();
            dGCellStock.AutoGenerateColumns = false;
            foreach (var c in cs)
            {
                dGCellStock.Rows.Add(c.IdCell, c.FkIdStock, c.Number);
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

        private void dGCellStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGCellStock.Rows[e.RowIndex];
                IdCell = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGCellStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGCellStock.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddCell(new CellsStocks
                        {
                            FkIdStock = Convert.ToInt32(row.Cells[1].Value),
                            Number = Convert.ToInt32(row.Cells[2].Value)
                        });
                        Init();
                        IdCell = 0;
                    }
                    else
                    {
                        data.EditCell(new CellsStocks
                        {
                            IdCell = Convert.ToInt32(row.Cells[0].Value),
                            FkIdStock = Convert.ToInt32(row.Cells[1].Value),
                            Number = Convert.ToInt32(row.Cells[2].Value)
                        });
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
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
                    data.DelCell(IdCell);
                    Init();
                    IdCell = 0;
                }
            }
        }
    }
}
