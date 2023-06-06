using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesApp.Models.QModels;
using HumanResourcesApp.Models;

namespace HumanResourcesApp
{
    public partial class frmDahboard : Form
    {
        Data mydata = new Data();
        public frmDahboard()
        {
            InitializeComponent();
        }

        private void frmDahboard_Load(object sender, EventArgs e)
        {
            QDashboard QDashboard = null;

            ReturnObject ret = mydata.GetDasboard();
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                QDashboard = (QDashboard)ret.objectData;

                lbl_Personal.Text = QDashboard.activePersonal.ToString();
                lbl_TaskCount.Text = QDashboard.activeTask.ToString();
                lbl_Projects.Text = QDashboard.activeProject.ToString();
                lbl_Customers.Text = QDashboard.activeCustomer.ToString();
            }

        }
    }
}
