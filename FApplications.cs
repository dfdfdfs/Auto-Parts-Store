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
    public partial class FApplications : Form
    {
        private readonly DataDB data = new DataDB();
        int IdApp= 0;

        public FApplications()
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
            dGApp.Rows.Clear();
            List<Applications> app = data.GetApp();
            dGApp.AutoGenerateColumns = false;
            foreach (var a in app)
            {
                dGApp.Rows.Add(a.IdApplication, a.FkIdClient, a.FkIdSparePart);
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

        private void dGApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGApp.Rows[e.RowIndex];
                IdApp = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGApp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGApp.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddApp(new Applications
                        {
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            FkIdClient = Convert.ToInt32(row.Cells[1].Value),
                        });
                        Init();
                        IdApp = 0;
                    }
                    else
                    {
                        data.EditApp(new Applications
                        {
                            IdApplication = Convert.ToInt32(row.Cells[0].Value),
                            FkIdSparePart = Convert.ToInt32(row.Cells[2].Value),
                            FkIdClient = Convert.ToInt32(row.Cells[1].Value),
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdApp > 0)
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
                    data.DelApp(IdApp);
                    Init();
                }
            }
        }
    }
}
