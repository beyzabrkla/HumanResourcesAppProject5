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
    public partial class frmAdvanceList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmAdvanceList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            btnList.Visible = false;
            chb_active.Visible = false;
            chb_pasive.Visible = false;

            bunifuDataGridView2.ReadOnly = true;

            RefreshDataGrid();
        }


        private int GetStatue()
        {
            int Statue = 0;


            return Statue;
        }


        private void RefreshDataGrid()
        {
            int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetAdvanceList();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                bunifuDataGridView2.DataSource = ret.data.Tables[0];
            }
            else
            {
                bunifuDataGridView2.DataSource = null;
                MessageBox.Show(ret.message);
            }
        }


        private void btn_excell_Click_1(object sender, EventArgs e)
        {
            //int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetAdvanceList();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                mytool.ExportToExcel(ret.data);
            }
            else
            {
                MessageBox.Show(ret.message);
            }
        }

        private void btn_update_Click_1(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView2);
            if (id != 0)
            {
                frmPersonnelAdvancesEdit edit = new frmPersonnelAdvancesEdit()
                {
                    id = id
                };
                edit.ShowDialog();
                this.RefreshDataGrid();
            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView2);
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReturnObject ret = mydata.DeleteAdvance(id);
                MessageBox.Show(ret.message);
                this.RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Hayır
            }
        }

        private void btn_add_Click_1(object sender, EventArgs e)
        {
            frmPersonnelAdvancesAdd add = new frmPersonnelAdvancesAdd();
            add.ShowDialog();
            this.RefreshDataGrid();
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            RefreshDataGrid();

        }
    }
}
