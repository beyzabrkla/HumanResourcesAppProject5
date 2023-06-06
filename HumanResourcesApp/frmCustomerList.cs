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
    public partial class frmCustomerList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            chb_active.Checked = true;
            chb_pasive.Checked = true;

            bunifuDataGridView2.ReadOnly = true;

            RefreshDataGrid();
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


        private void RefreshDataGrid()
        {
            int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetCustomers(Statue);
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
            int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetCustomers(Statue);
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
                frmCustomerEdit edit = new frmCustomerEdit()
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
                ReturnObject ret = mydata.DeleteCustomer(id);
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
            frmCustomerAdd add = new frmCustomerAdd();
            add.ShowDialog();
            this.RefreshDataGrid();
        }

        private void btnList_Click_1(object sender, EventArgs e)
        {
            RefreshDataGrid();

        }
    }
}
