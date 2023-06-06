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
    public partial class frmStaffPositionsEdit : Form
    {
        Data mydata = new Data();

        public int id { get; set; }


        public frmStaffPositionsEdit()
        {
            InitializeComponent();
        }

        private void frm_PersonalPositionsEdit_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");

            comboBox1.DataSource = new BindingSource(statues, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            txt_id.Enabled= false;
            txt_createdDate.Enabled= false;

            ReturnObject ret = mydata.GetPositionById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBposition position = (DBposition)ret.objectData;
                txt_name.Text = position.positionName;
                txt_id.Text = position.id.ToString();
                txt_createdDate.Text = position.createdDate.ToString();
                comboBox1.SelectedValue = position.isActive.ToString();

                lbl_Header.Text = $"Pozisyon Düzenle - {position.positionName}";

            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Pozisyonu güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string positionName = txt_name.Text;
                var combo = comboBox1.SelectedValue;

                DBposition position = new DBposition()
                {
                    id = id,
                    positionName = txt_name.Text,
                    upadtedUserId = localResources.personalInformation.id
                };

                string isActive = (string)comboBox1.SelectedValue;
                position.isActive = Convert.ToInt32(isActive);

                ReturnObject ret = mydata.UptadePosition(position);
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

        //mouse hareketleri
        int tiklananX, tiklananY;
        private Control pnlHeader;


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

