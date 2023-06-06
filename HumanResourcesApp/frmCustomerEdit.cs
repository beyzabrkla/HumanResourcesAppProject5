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
    public partial class frmCustomerEdit : Form
    {
        Data mydata = new Data();

        public int id { get; set; }

        public frmCustomerEdit()
        {
            InitializeComponent();
        }

        private void frmCustomerEdit_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> statues = new Dictionary<string, string>();
            statues.Add("1", "Aktif");
            statues.Add("0", "Pasif");

            comboBox1.DataSource = new BindingSource(statues, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            txt_id.Enabled = false;
            txt_createdDate.Enabled = false;

            ReturnObject ret = mydata.GetCustomerById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBCustomer customer = (DBCustomer)ret.objectData;
                txt_name.Text = customer.customerName;
                txt_id.Text = customer.id.ToString();
                txt_createdDate.Text = customer.createdDate.ToString();
                comboBox1.SelectedValue = customer.isActive.ToString();

                lbl_Header.Text = $"Müşteri Düzenle - {customer.customerName}";

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Müşteri güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string customer_name = txt_name.Text;
                var combo = comboBox1.SelectedValue;

                DBCustomer customer = new DBCustomer()
                {
                    id = id,
                    customerName = txt_name.Text,
                    upadtedUserId = localResources.personalInformation.id
                };

                string isActive = (string)comboBox1.SelectedValue;
                customer.isActive = Convert.ToInt32(isActive);

                ReturnObject ret = mydata.UptadeCustomer(customer);
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
