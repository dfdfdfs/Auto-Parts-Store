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
    public partial class FManuf : Form
    {
        private readonly DataDB data = new DataDB();
        int IdManuf = 0;

        public FManuf()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            dGManuf.Rows.Clear();
            List<Manufacturers> manuf = data.GetManuf();
            dGManuf.AutoGenerateColumns = false;
            foreach (var m in manuf)
            {
                dGManuf.Rows.Add(m.IdManufacturer, m.Name);
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

        private void dGManuf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGManuf.Rows[e.RowIndex];
                IdManuf = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void dGManuf_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dGManuf.Rows[e.RowIndex];
                if (Valid(row))
                {
                    if (row.Cells[0].Value == null)
                    {
                        data.AddManuf(new Manufacturers
                        {
                            Name = row.Cells[1].Value.ToString()
                        });
                        Init();
                        IdManuf = 0;
                    }
                    else
                    {
                        data.EditManuf(new Manufacturers
                        {
                            IdManufacturer = Convert.ToInt32(row.Cells[0].Value),
                            Name = row.Cells[1].Value.ToString()
                        });
                    }
                }

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (IdManuf > 0)
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
                    data.DelManuf(IdManuf);
                    Init();
                }
            }
        }
    }
}
