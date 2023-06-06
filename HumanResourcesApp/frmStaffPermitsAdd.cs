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
    public partial class frmStaffPermitsAdd : Form
    {
        Data mydata = new Data();

        public frmStaffPermitsAdd()
        {
            InitializeComponent();
        }

        private void frmStaffPermitsAdd_Load(object sender, EventArgs e)
        {
            ReturnObject ret = new ReturnObject();


            Dictionary<string, string> personeller = new Dictionary<string, string>();
            ret = mydata.GetStaffList(1);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet positionsDs = ret.data;
                foreach (DataRow row in positionsDs.Tables[0].Rows)
                {
                    personeller.Add(row["id"].ToString(), row["İsim"].ToString());
                }

                comboBox_Personals.DataSource = new BindingSource(personeller, null);
                comboBox_Personals.DisplayMember = "Value";
                comboBox_Personals.ValueMember = "Key";
                comboBox_Personals.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Personel izni eklemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string explanation = richTextBox1.Text;

                DBPermit permit = new DBPermit()
                {
                    reasonForPermission = explanation,
                    day = dpdate.Value
                };

                string personalId = (string)comboBox_Personals.SelectedValue;
                permit.userId = Convert.ToInt32(personalId);

                ReturnObject ret = mydata.AddPermission(permit);
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
            else if (dialogResult == DialogResult.No)
            {
                //Hayır
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
