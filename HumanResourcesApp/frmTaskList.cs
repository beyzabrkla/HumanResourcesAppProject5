using Bunifu.UI.WinForms;
using HumanResourcesApp.Helpers;
using HumanResourcesApp.Models;
using HumanResourcesApp.Models.DBModels;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HumanResourcesApp
{
    public partial class frmTaskList : Form
    {
        Data mydata = new Data();
        Tools mytool = new Tools();

        public frmTaskList()
        {
            InitializeComponent();
        }

        private void frmTaskList_Load(object sender, EventArgs e)
        {
            chb_active.Visible = false;
            chb_pasive.Visible = false;

            bunifuDataGridView2.ReadOnly = true;

            Dictionary<string, string> projeler = new Dictionary<string, string>();
            ReturnObject ret = mydata.GetProject(1);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet projeDs = ret.data;
                projeler.Add("-1", "Hepsi");
                foreach (DataRow row in projeDs.Tables[0].Rows)
                {
                    projeler.Add(row["id"].ToString(), row["Proje İsmi"].ToString());
                }

                comboBox2.DataSource = new BindingSource(projeler, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
                comboBox2.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }

            RefreshDataGrid();

        }

        private int GetStatue()
        {
            int Statue = 0;


            return Statue;
        }

        private void RefreshDataGrid()
        {

            string projectId = (string)comboBox2.SelectedValue;
            int projectIdInt = Convert.ToInt32(projectId);


            ReturnObject ret = mydata.getTaskList(projectIdInt);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                bunifuDataGridView2.DataSource = ret.data.Tables[0];
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frmTaskAdd add = new frmTaskAdd();
            add.ShowDialog();
            this.RefreshDataGrid();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = mytool.GetId(bunifuDataGridView2);
            DialogResult dialogResult = MessageBox.Show("Silmek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReturnObject ret = mydata.DeleteTask(id);
                MessageBox.Show(ret.message);
                this.RefreshDataGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                //hayır            
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int editId = mytool.GetId(bunifuDataGridView2);
            if (editId != 0)
            {
                frmTaskEdit edit = new frmTaskEdit(editId);
                
                edit.ShowDialog();
                this.RefreshDataGrid();
            }
        }

        private void btn_excell_Click(object sender, EventArgs e)
        {
            string projectId = (string)comboBox2.SelectedValue;
            int projectIdInt = Convert.ToInt32(projectId);


            ReturnObject ret = mydata.getTaskList(projectIdInt);
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
