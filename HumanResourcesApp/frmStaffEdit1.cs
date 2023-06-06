using Bunifu.UI.WinForms;
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
    public partial class frmStaffEdit1 : Form
    {
        Data mydata = new Data();

        public int id { get; set; }


        public frmStaffEdit1()
        {
            InitializeComponent();
        }

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {
            ReturnObject ret = new ReturnObject();

            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");




            Dictionary<string, string> positions = new Dictionary<string, string>();
            ret = mydata.GetPositions(1);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DataSet positionsDs = ret.data;
                foreach (DataRow row in positionsDs.Tables[0].Rows)
                {
                    positions.Add(row["id"].ToString(), row["Pozisyon"].ToString());
                }

                comboBox_Positons.DataSource = new BindingSource(positions, null);
                comboBox_Positons.DisplayMember = "Value";
                comboBox_Positons.ValueMember = "Key";
                comboBox_Positons.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }

            ret = mydata.GetpersonalById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBpersonal personal = (DBpersonal)ret.objectData;
                txtbox_username.Text = personal.username;
                txtbox_personalName.Text = personal.firstname;
                txtbox_personalSurname.Text = personal.lastname;
                dpdate.Value = personal.dateOfBirth;
                txtbox_email.Text = personal.email;
                bunifuTextBox2.Text = personal.phone;

                if (personal.gender == 1)
                {
                    radioButton_men.Checked = false;
                    radioButton_woman.Checked = true;
                }
                else
                {
                    radioButton_men.Checked = true;
                    radioButton_woman.Checked = false;
                }
          

                txtbox_Id.Text = personal.id.ToString();
                txtbox_Id.Enabled = false;

                comboBox_Positons.SelectedValue = personal.positionId.ToString();

                lbl_Main.Text = $"Personel Düzenle - {personal.firstname}{personal.lastname}";

            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Personel eklemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                string phone = bunifuTextBox2.Text;



                DBpersonal personal = new DBpersonal()
                {
                    id = id,
                    addedUserId = localResources.personalInformation.id,
                    username = txtbox_username.Text,
                    firstname = txtbox_personalName.Text,
                    lastname = txtbox_personalSurname.Text,
                    dateOfBirth = dpdate.Value,
                    email = txtbox_email.Text,
                    phone = phone,
                };

                string positionId = (string)comboBox_Positons.SelectedValue;
                personal.positionId = Convert.ToInt32(positionId);

                if (radioButton_woman.Checked == true)
                {
                    personal.gender = (int)enums.Gender.Female;
                }
                else if (radioButton_men.Checked == true)
                {
                    personal.gender = (int)enums.Gender.Male;
                }


                ReturnObject ret = mydata.updateStaf(personal);
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
        private Control pnlHeader;

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
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

        private void lbl_customers_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }
    }
}
