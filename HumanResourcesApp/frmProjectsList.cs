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
    public partial class frmProjectsList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmProjectsList()
        {
            InitializeComponent();
        }




        void LoadForm()
        {
            chb_active.Checked = true;
            chb_pasive.Checked = true;

            bunifuDataGridView1.ReadOnly = true;

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

            ReturnObject ret = mydata.GetProject(Statue);
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

        private void btn_excell_Click(object sender, EventArgs e)
        {
            int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetProject(Statue);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                mytool.ExportToExcel(ret.data);
            }
            else
            {
                MessageBox.Show(ret.message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView1);
            if (id != 0)
            {
                frmProjectsEdit edit = new frmProjectsEdit()
                {
                    id = id
                };
                edit.ShowDialog();
                this.RefreshDataGrid();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView1);
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReturnObject ret = mydata.DeleteProject(id);
                MessageBox.Show(ret.message);
                this.RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Hayır
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frmProjectsAdd add = new frmProjectsAdd();
            add.ShowDialog();
            this.RefreshDataGrid();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void frmProjectsList_Load(object sender, EventArgs e)
        {
            this.LoadForm();
        }
    }
}

