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
    public partial class frmWage : Form
    {
        Data mydata = new Data();

        public int id { get; set; }

        public frmWage()
        {
            InitializeComponent();
        }

        private void frmWage_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> statues = new Dictionary<string, string>();

            ReturnObject ret = mydata.GetpersonalById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBpersonal personal = (DBpersonal)ret.objectData;
                txt_wage.Text = personal.wage.ToString(); 

                lbl_Main.Text = $"Personel Maaş Düzenle - {personal.firstname}{personal.lastname}";

            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Maaş güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                try
                {

                    decimal wage = Convert.ToDecimal(txt_wage.Text);

                    ReturnObject ret = mydata.updateStafWage(id,wage);
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
                catch (Exception ex)
                {

                    MessageBox.Show("Geçerli bir tutar giriniz.");
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
