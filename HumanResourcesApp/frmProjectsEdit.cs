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
    public partial class frmProjectsEdit : Form
    {
        Data mydata = new Data();

        public int id { get; set; }

        public frmProjectsEdit()
        {
            InitializeComponent();
        }

        private void frmProjectsEdit_Load(object sender, EventArgs e)
        {

            ReturnObject ret = new ReturnObject();

            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");

            comboBox_situation.DataSource = new BindingSource(statues, null);
            comboBox_situation.DisplayMember = "Value";
            comboBox_situation.ValueMember = "Key";


            Dictionary<string, string> projectStatues = new Dictionary<string, string>();
            ret = mydata.GetProjectStatus();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet statuesDs = ret.data;
                foreach (DataRow row in statuesDs.Tables[0].Rows)
                {
                    projectStatues.Add(row["id"].ToString(), row["status"].ToString());
                }

                comboBox_ProjectSituation.DataSource = new BindingSource(projectStatues, null);
                comboBox_ProjectSituation.DisplayMember = "Value";
                comboBox_ProjectSituation.ValueMember = "Key";

            }
            else
            {
                MessageBox.Show(ret.message);
            }

            Dictionary<string, string> ProjectCustomers = new Dictionary<string, string>();
            ret = mydata.GetProjectCustomers();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet ProjectCustomersDs = ret.data;
                foreach (DataRow row in ProjectCustomersDs.Tables[0].Rows)
                {
                    ProjectCustomers.Add(row["id"].ToString(), row["customerName"].ToString());
                }

                comboBox_Customers.DataSource = new BindingSource(ProjectCustomers, null);
                comboBox_Customers.DisplayMember = "Value";
                comboBox_Customers.ValueMember = "Key";

            }
            else
            {
                MessageBox.Show(ret.message);
            }

            Dictionary<string, string> ProjectPersonals = new Dictionary<string, string>();
            ret = mydata.GetProjectPersonals();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet ProjectPersonalsDs = ret.data;
                foreach (DataRow row in ProjectPersonalsDs.Tables[0].Rows)
                {
                    ProjectPersonals.Add(row["id"].ToString(), row["Yetkili"].ToString());
                }

                comboBox_Personals.DataSource = new BindingSource(ProjectPersonals, null);
                comboBox_Personals.DisplayMember = "Value";
                comboBox_Personals.ValueMember = "Key";

            }
            else
            {
                MessageBox.Show(ret.message);
            }


            ret = mydata.GetProjectById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBProject project = (DBProject)ret.objectData;
                txtbox_ProjectTopic.Text = project.projectName;
                txt_id.Text = project.id.ToString();
                txt_createdDate.Text = project.createdDate.ToString();
                comboBox_situation.SelectedValue = project.isActive.ToString();
                comboBox_ProjectSituation.SelectedValue = project.statuId.ToString();
                comboBox_Customers.SelectedValue = project.customerId.ToString();
                comboBox_Personals.SelectedValue = project.projectOwnerId.ToString();
                dp_StartingDate.Value = project.startDate;
                dp_EndDate.Value = project.endDate;

                lbl_Header.Text = $"Proje Düzenle - {project.projectName}";

            }

            txt_id.Enabled = false; 
            txt_createdDate.Enabled = false;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Projeyi güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string project_name = txtbox_ProjectTopic.Text;
                var comboPersonal = comboBox_Personals.SelectedValue;
                var comboCustomer = comboBox_Customers.SelectedValue;
                var comboSituation = comboBox_situation.SelectedValue;
                var comboProjectSituation = comboBox_ProjectSituation.SelectedValue;

                DBProject project = new DBProject()
                {
                    upadtedUserId = localResources.personalInformation.id,
                    projectName = txtbox_ProjectTopic.Text,
                    startDate = dp_StartingDate.Value,
                    endDate = dp_EndDate.Value,
                    id = id
                };

                string isActive = (string)comboBox_situation.SelectedValue;
                project.isActive = Convert.ToInt32(isActive);

                string customerId = (string)comboBox_Customers.SelectedValue;
                project.customerId = Convert.ToInt32(customerId);

                string personalId = (string)comboBox_Personals.SelectedValue;
                project.projectOwnerId = Convert.ToInt32(personalId);

                string projectStatu = (string)comboBox_ProjectSituation.SelectedValue;
                project.statuId = Convert.ToInt32(projectStatu);

                ReturnObject ret = mydata.UpdateProject(project);
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

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void lbl_Header_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void lbl_Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }

    }
}
