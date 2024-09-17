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
    public partial class FSales : Form
    {
        private readonly DataDB data = new DataDB();
        int IdSale = 0;

        public FSales()
        {
            InitializeComponent();

            List<SpareParts> sp = data.GetSparePartCmb();
            List<SpareParts> cSp = new List<SpareParts>();

            foreach (var s in sp)
                cSp.Add(new SpareParts { IdSparePart = s.IdSparePart, Code = s.Code });

            cmbSparePart.DataSource = cSp;
            cmbSparePart.ValueMember = "IdSparePart";
            cmbSparePart.DisplayMember = "Code";

            List<Clients> cl = data.GetClients();
            List<Clients> cCl = new List<Clients>();

            foreach (var c in cl)
                cCl.Add(new Clients { IdClient = c.IdClient, Fio = c.Fio });

            cmbClients.DataSource = cCl;
            cmbClients.ValueMember = "IdClient";
            cmbClients.DisplayMember = "Fio";

            Init();
        }

        public void Init()
        {
            dGSales.Rows.Clear();
            List<Sales> sales = data.GetSales();
            dGSales.AutoGenerateColumns = false;
            foreach (var s in sales)
            {
                dGSales.Rows.Add(s.IdSale, s.Date.ToShortDateString(), s.FkIdSparePart, s.FkIdClient, s.Amount, s.TotalPrice);
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

        private void dGSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSales.Rows[e.RowIndex];
                IdSale = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGSales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSales.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddSale(new Sales
                        {
                            Date = Convert.ToDateTime(row.Cells[1].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            FkIdClient = Convert.ToInt32(row.Cells[3].Value),
                            Amount = Convert.ToInt32(row.Cells[4].Value),
                            TotalPrice = Convert.ToDecimal(row.Cells[5].Value),
                        });
                        Init();
                        IdSale = 0;
                    }
                    else
                    {
                        data.EditSale(new Sales
                        {
                            IdSale = Convert.ToInt32(row.Cells[0].Value),
                            Date = Convert.ToDateTime(row.Cells[1].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            FkIdClient = Convert.ToInt32(row.Cells[3].Value),
                            Amount = Convert.ToInt32(row.Cells[4].Value),
                            TotalPrice = Convert.ToDecimal(row.Cells[5].Value),
                        });
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdSale > 0)
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
                    data.DelSale(IdSale);
                    Init();
                }
            }
        }
    }
}
