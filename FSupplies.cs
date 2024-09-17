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
    public partial class FSupplies : Form
    {
        private readonly DataDB data = new DataDB();
        int IdSupplies = 0;

        public FSupplies()
        {
            InitializeComponent();

            List<SpareParts> sp = data.GetSparePartCmb();
            List<SpareParts> cSp = new List<SpareParts>();

            foreach (var s in sp)
                cSp.Add(new SpareParts { IdSparePart = s.IdSparePart, Code = s.Code});

            cmbSparePart.DataSource = cSp;
            cmbSparePart.ValueMember = "IdSparePart";
            cmbSparePart.DisplayMember = "Code";

            Init();
        }

        public void Init()
        {
            dGSupplies.Rows.Clear();
            List<Supplies> sup = data.GetSupplies();
            dGSupplies.AutoGenerateColumns = false;
            foreach (var s in sup)
            {
                dGSupplies.Rows.Add(s.IdSupply, s.Date.ToShortDateString(), s.FkIdSparePart, s.Amount, s.Price);
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

        private void dGSupplies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSupplies.Rows[e.RowIndex];
                IdSupplies = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGSupplies_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGSupplies.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddSupplies(new Supplies
                        {
                            Date = Convert.ToDateTime(row.Cells[1].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            Amount = Convert.ToInt32(row.Cells[3].Value),
                            Price = Convert.ToDecimal(row.Cells[4].Value)
                        });
                        Init();
                        IdSupplies = 0;
                    }
                    else
                    {
                        data.EditSupplies(new Supplies
                        {
                            IdSupply = Convert.ToInt32(row.Cells[0].Value),
                            Date = Convert.ToDateTime(row.Cells[1].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            Amount = Convert.ToInt32(row.Cells[3].Value),
                            Price = Convert.ToDecimal(row.Cells[4].Value)
                        });
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdSupplies > 0)
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
                    data.DelSupplies(IdSupplies);
                    Init();
                    IdSupplies = 0;
                }
            }
        }
    }
}
