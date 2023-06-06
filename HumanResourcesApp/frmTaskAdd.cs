using HumanResourcesApp.Models;
using HumanResourcesApp.Models.DBModels;
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
    public partial class frmTaskAdd : Form
    {
        Data mydata = new Data();

        public frmTaskAdd()
        {
            InitializeComponent();
        }

        private void frmTaskAdd_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> projeler = new Dictionary<string, string>();
            ReturnObject ret = mydata.GetProject(1);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet projeDs = ret.data;
                foreach (DataRow row in projeDs.Tables[0].Rows)
                {
                    projeler.Add(row["id"].ToString(), row["Proje İsmi"].ToString());
                }

                comboBox1.DataSource = new BindingSource(projeler, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }


            Dictionary<string, string> status = new Dictionary<string, string>();
             ret = mydata.getTaskStatuList();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet taskDs = ret.data;
                foreach (DataRow row in taskDs.Tables[0].Rows)
                {
                    status.Add(row["id"].ToString(), row["status"].ToString());
                }

                comboBox2.DataSource = new BindingSource(status, null);
                comboBox2.DisplayMember = "Value";
                comboBox2.ValueMember = "Key";
                comboBox2.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }


        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Yapılacak İşleri eklemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string taskName = txt_name.Text;
                string taskDescription = bunifuTextBox1.Text;
      

                DBTask task = new DBTask()
                {
                    taskName = txt_name.Text,
                    taskDescription = bunifuTextBox1.Text
                };

                string projectId = (string)comboBox1.SelectedValue;
                task.projectId = Convert.ToInt32(projectId);

                string statuId = (string)comboBox2.SelectedValue;
                task.statuId = Convert.ToInt32(statuId);

                ReturnObject ret = mydata.AddTask(task);
                if (ret.ReturnCode == enums.ReturnCode.Ok)
                {
                    MessageBox.Show(ret.message);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ret.message);
                }
            }
        }

        int tiklananX, tiklananY;

        private void lbl_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }

        private void lbl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }
    }
}
