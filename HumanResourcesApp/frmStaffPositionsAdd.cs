using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesApp.Models;
using HumanResourcesApp.Models.DBModels;

namespace HumanResourcesApp
{
    public partial class frmStaffPositionsAdd : Form
    {
        Data mydata = new Data();

        public frmStaffPositionsAdd()
        {
            InitializeComponent();
        }

        private void frm_PersonalPositionsAdd_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");

            comboBox1.DataSource = new BindingSource(statues, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";


            comboBox1.SelectedIndex = 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Pozisyon eklemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string positionName = txt_name.Text;
                var combo = comboBox1.SelectedValue;

                DBposition position = new DBposition()
                {
                    addedUserId = localResources.personalInformation.id,
                    positionName = txt_name.Text,
                };

                string isActive = (string)comboBox1.SelectedValue;
                position.isActive = Convert.ToInt32(isActive);

                ReturnObject ret = mydata.AddPosition(position);
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


        // mouse hareketleri
        int tiklananX, tiklananY;
        private Control pnlHeader;

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
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

    }
}
