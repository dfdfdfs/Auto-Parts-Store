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
    public partial class FSparePartStock : Form
    {
        private readonly DataDB data = new DataDB();
        int IdSPStock = 0;

        public FSparePartStock()
        {
            InitializeComponent();

            List<SpareParts> sp = data.GetSparePartCmb();
            List<SpareParts> cSp = new List<SpareParts>();

            foreach (var s in sp)
                cSp.Add(new SpareParts { IdSparePart = s.IdSparePart, Code = s.Code });

            cmbSparePart.DataSource = cSp;
            cmbSparePart.ValueMember = "IdSparePart";
            cmbSparePart.DisplayMember = "Code";

            List<Cmb> cs = data.GetCellStockCmb();
            List<Cmb> cCs = new List<Cmb>();

            foreach (var c in cs)
                cCs.Add(new Cmb { IdCmb = c.IdCmb, NameCmb = c.NameCmb });

            cmbCell.DataSource = cCs;
            cmbCell.ValueMember = "IdCmb";
            cmbCell.DisplayMember = "NameCmb";

            Init();
        }

        public void Init()
        {
            dGSparePartStock.Rows.Clear();
            List<SparePartStock> sup = data.GetSPStock();
            dGSparePartStock.AutoGenerateColumns = false;
            foreach (var s in sup)
            {
                dGSparePartStock.Rows.Add(s.IdSpStock, s.FkIdSparePart, s.FkIdCell, s.Amount);
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

        private void dGSparePartStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSparePartStock.Rows[e.RowIndex];
                IdSPStock = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGSparePartStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSparePartStock.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddSPStock(new SparePartStock
                        {
                            FkIdSparePart = Convert.ToInt32(row.Cells[1].Value),
                            FkIdCell = Convert.ToInt32(row.Cells[2].Value),
                            Amount = Convert.ToInt32(row.Cells[3].Value),
                        });
                        Init();
                        IdSPStock = 0;
                    }
                    else
                    {
                        data.EditSPStock(new SparePartStock
                        {
                            IdSpStock = Convert.ToInt32(row.Cells[0].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[1].Value),
                            FkIdCell = Convert.ToInt32(row.Cells[2].Value),
                            Amount = Convert.ToInt32(row.Cells[3].Value),
                        });
                    }
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdSPStock > 0)
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
                    data.DelSPStock(IdSPStock);
                    Init();
                    IdSPStock = 0;
                }
            }
        }
    }
}
