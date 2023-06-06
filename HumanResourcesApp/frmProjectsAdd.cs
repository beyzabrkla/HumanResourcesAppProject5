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
    public partial class frmProjectsAdd : Form
    {
        Data mydata = new Data();

        public frmProjectsAdd()
        {
            InitializeComponent();
        }

        private void frmProjectsAdd_Load(object sender, EventArgs e)
        {
            ReturnObject ret = new ReturnObject();

            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");

            comboBox_situation.DataSource = new BindingSource(statues, null);
            comboBox_situation.DisplayMember = "Value";
            comboBox_situation.ValueMember = "Key";
            comboBox_situation.SelectedIndex = 0;

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
                comboBox_ProjectSituation.SelectedIndex = 0;

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
                comboBox_Customers.SelectedIndex = 0;

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

                comboBox_ProjectPersonals.DataSource = new BindingSource(ProjectPersonals, null);
                comboBox_ProjectPersonals.DisplayMember = "Value";
                comboBox_ProjectPersonals.ValueMember = "Key";
                comboBox_ProjectPersonals.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Proje eklemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string project_name = txtbox_Projectname.Text;
                var comboPersonal = comboBox_ProjectPersonals.SelectedValue;
                var comboCustomer = comboBox_Customers.SelectedValue;
                var comboSituation = comboBox_situation.SelectedValue;
                var comboProjectSituation = comboBox_ProjectSituation.SelectedValue;

                DBProject project = new DBProject()
                {
                    addedUserId = localResources.personalInformation.id,
                    projectName = txtbox_Projectname.Text,
                    startDate = dp_StartingDate.Value,
                    endDate = dp_EndDate.Value
                };

                string isActive = (string)comboBox_situation.SelectedValue;
                project.isActive = Convert.ToInt32(isActive);

                string customerId = (string)comboBox_Customers.SelectedValue;
                project.customerId = Convert.ToInt32(customerId);

                string personalId = (string)comboBox_ProjectPersonals.SelectedValue;
                project.projectOwnerId = Convert.ToInt32(personalId);

                string projectStatu = (string)comboBox_ProjectSituation.SelectedValue;
                project.statuId = Convert.ToInt32(projectStatu);

                ReturnObject ret = mydata.AddProject(project);
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
        private Control pnlHeader;

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void lbl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void lbl_Main_MouseMove(object sender, MouseEventArgs e)
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
