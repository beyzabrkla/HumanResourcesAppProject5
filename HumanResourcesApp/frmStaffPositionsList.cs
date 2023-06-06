using HumanResourcesApp.Helpers;
using HumanResourcesApp.Models;
using Kimtoo.BindingProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Jenga.Theme;

namespace HumanResourcesApp
{
    public partial class frmStaffPositionsList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmStaffPositionsList()
        {
#pragma warning disable CS0612 // Tür veya üye artık kullanılmıyor
            InitializeComponent();
#pragma warning restore CS0612 // Tür veya üye artık kullanılmıyor
        }

        private void frmPersonalPositionList_Load(object sender, EventArgs e)
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

            ReturnObject ret = mydata.GetPositions(Statue);
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



        private void btnList_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }


        private void btn_excell_Click(object sender, EventArgs e)
        {

            int Statue = this.GetStatue();

            ReturnObject ret = mydata.GetPositions(Statue);
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
                frmStaffPositionsEdit edit = new frmStaffPositionsEdit()
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
                ReturnObject ret = mydata.DeletePoisiton(id);
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
            frmStaffPositionsAdd add = new frmStaffPositionsAdd();
            add.ShowDialog();
            this.RefreshDataGrid();
        }
    }
}
