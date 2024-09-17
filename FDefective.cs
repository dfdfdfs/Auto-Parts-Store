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
    public partial class FDefective : Form
    {
        private readonly DataDB data = new DataDB();
        int IdDefective = 0;

        public FDefective()
        {
            InitializeComponent();

            List<Supplies> sp = data.GetSupplies();
            List<Cmb> cSp = new List<Cmb>();

            foreach (var s in sp)
                cSp.Add(new Cmb { IdCmb = s.IdSupply, NameCmb = "№" + s.IdSupply + " (дата: " + s.Date.ToShortDateString() + ")"});

            cmbSupply.DataSource = cSp;
            cmbSupply.ValueMember = "IdCmb";
            cmbSupply.DisplayMember = "NameCmb";

            Init();
        }

        public void Init()
        {
            dGDefective.Rows.Clear();
            List<DefectiveGoods> defectives = data.GetDefective();
            dGDefective.AutoGenerateColumns = false;
            foreach (var d in defectives)
            {
                dGDefective.Rows.Add(d.IdDefect, d.FkIdSupplies, d.Amount);
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

        private void dGDefective_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGDefective.Rows[e.RowIndex];
                IdDefective = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGDefective_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGDefective.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddDefective(new DefectiveGoods
                        {                            
                            FkIdSupplies = Convert.ToInt32(row.Cells[1].Value),
                            Amount = Convert.ToInt32(row.Cells[2].Value)
                        });
                        Init();
                        IdDefective = 0;
                    }
                    else
                    {
                        data.EditDefective(new DefectiveGoods
                        {
                            IdDefect = Convert.ToInt32(row.Cells[0].Value),
                            FkIdSupplies = Convert.ToInt32(row.Cells[1].Value),
                            Amount = Convert.ToInt32(row.Cells[2].Value)
                        });
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdDefective > 0)
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
                    data.DelDefective(IdDefective);
                    Init();
                    IdDefective = 0;
                }
            }
        }
    }
}
