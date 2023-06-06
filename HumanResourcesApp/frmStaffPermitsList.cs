using Bunifu.UI.WinForms;
using HumanResourcesApp.Helpers;
using HumanResourcesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesApp
{
    public partial class frmStaffPermitsList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmStaffPermitsList()
        {
            InitializeComponent();
        }

        private void frmStaffPermitsList_Load(object sender, EventArgs e)
        {
            chb_active.Visible = false;
            chb_pasive.Visible = false;
            btnList.Visible = false;

            bunifuDataGridView1.ReadOnly = true;

            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            //int Statue = this.GetStatue();

            ReturnObject ret = mydata.getPermissionList();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                bunifuDataGridView1.DataSource = ret.data.Tables[0];
            }
            else
            {
                bunifuDataGridView1.DataSource = null;
                MessageBox.Show(ret.message);
            }
        }

        private int GetStatue()
        {
            int Statue = 0;

            if (chb_active.Checked == true && chb_pasive.Checked == true)
            {
                Statue = (int)enums.Statues.All;
            }
            else if (chb_active.Checked == true && chb_pasive.Checked == false)
            {
                Statue = (int)enums.Statues.Active;
            }
            else if (chb_pasive.Checked == true && chb_active.Checked == false)
            {
                Statue = (int)enums.Statues.Inactive;
            }

            return Statue;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frmStaffPermitsAdd add = new frmStaffPermitsAdd();
            add.ShowDialog();
            this.RefreshDataGrid();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView1);
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReturnObject ret = mydata.DeletePermission(id);
                MessageBox.Show(ret.message);
                this.RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Hayır
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView1);
            if (id != 0)
            {
                frmStaffPermitsEdit edit = new frmStaffPermitsEdit()
                {
                    id = id
                };
                edit.ShowDialog();
                this.RefreshDataGrid();
            }
        }

        private void btn_excell_Click(object sender, EventArgs e)
        {
            //int Statue = this.GetStatue();

            ReturnObject ret = mydata.getPermissionList();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                mytool.ExportToExcel(ret.data);
            }
            else
            {
                MessageBox.Show(ret.message);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();

        }
    }
}
