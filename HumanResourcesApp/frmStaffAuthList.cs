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
    public partial class frmStaffAuthList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmStaffAuthList()
        {
            InitializeComponent();
        }

        private void frmStaffPermitsList_Load(object sender, EventArgs e)
        {
            btn_add.Visible = false;
            btn_delete.Visible = false;
            chb_active.Visible = false;
            chb_pasive.Visible = false;
            btnList.Visible = false;

            bunifuDataGridView1.ReadOnly = true;

            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            //int Statue = this.GetStatue();

            ReturnObject ret = mydata.getAuthList();
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

            return Statue;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
//gerek yok burda
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //gerek yok burda
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView1);
            if (id != 0)
            {
                if (id != localResources.personalInformation.id)
                {
                    frmStaffAuthEdit2 edit = new frmStaffAuthEdit2()
                    {
                        id = id
                    };
                    edit.ShowDialog();
                    this.RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show("Kendi yetki seviyenizi güncelleyemezsiniz.");
                }
        
            }
        }

        private void btn_excell_Click(object sender, EventArgs e)
        {
            //int Statue = this.GetStatue();

            ReturnObject ret = mydata.getAuthList();
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
