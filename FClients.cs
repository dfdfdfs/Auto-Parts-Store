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
    public partial class FClients : Form
    {
        private readonly DataDB data = new DataDB();
        int IdClient= 0;

        public FClients()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGClients.Rows.Clear();
            List<Clients> clients = data.GetClients();
            dGClients.AutoGenerateColumns = false;
            foreach (var c in clients)
            {
                dGClients.Rows.Add(c.IdClient, c.Fio, c.Phone);
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

        private void dGClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGClients.Rows[e.RowIndex];
                IdClient = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGClients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGClients.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddClient(new Clients
                        {
                            Fio = row.Cells[1].Value.ToString(),
                            Phone = row.Cells[2].Value.ToString(),
                        });
                        Init();
                        IdClient = 0;
                    }
                    else
                    {
                        data.EditClient(new Clients
                        {
                            IdClient = Convert.ToInt32(row.Cells[0].Value),
                            Fio = row.Cells[1].Value.ToString(),
                            Phone = row.Cells[2].Value.ToString(),
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdClient > 0)
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
                    data.DelClient(IdClient);
                    Init();
                }
            }
        }
    }
}
