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
    public partial class frmStaffAddress : Form
    {
        Data mydata = new Data();

        public int id { get; set; }

        public frmStaffAddress()
        {
            InitializeComponent();
        }

        private void frmWage_Load(object sender, EventArgs e)
        {
            ReturnObject ret = mydata.GetpersonalById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBpersonal personal = (DBpersonal)ret.objectData;
                txt_adress.Text = personal.addres;

                lbl_Main.Text = $"Personel Adresi Düzenle - {personal.firstname}{personal.lastname}";

            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Adresi güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string address = txt_adress.Text;


                ReturnObject ret = mydata.updateStafAddress(id, address);
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

        private void lbl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }
    }
}
