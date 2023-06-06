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
using System.Windows.Controls;
using System.Windows.Forms;

namespace HumanResourcesApp
{
    public partial class frmPersonnelAdvancesEdit : Form
    {
        Data mydata = new Data();

        public int id { get; set; }

        public frmPersonnelAdvancesEdit()
        {
            InitializeComponent();
        }

        private void frmPersonnelAdvancesAdd_Load(object sender, EventArgs e)
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

                comboBox_AdvancePersonnel.DataSource = new BindingSource(personeller, null);
                comboBox_AdvancePersonnel.DisplayMember = "Value";
                comboBox_AdvancePersonnel.ValueMember = "Key";
                comboBox_AdvancePersonnel.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show(ret.message);
            }

            ret = mydata.GetAdvanceById(id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                DBAdvance advance = (DBAdvance)ret.objectData;
                textBox1.Text = advance.advance.ToString();
                dpdate.Value = advance.advanceDate;
                richTextBox1.Text = advance.advanceNote;
                comboBox_AdvancePersonnel.SelectedValue = advance.userId.ToString();


            }



        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Avan işlemini güncellemek istediğinize emin misiniz?", "Emin Misiniz?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    decimal advanceAmount = Convert.ToDecimal(textBox1.Text);

                    DBAdvance advance = new DBAdvance()
                    {
                        id = id,
                        advanceNote = richTextBox1.Text,
                        advanceDate = dpdate.Value,
                        advance = advanceAmount
                    };

                    string personalId = (string)comboBox_AdvancePersonnel.SelectedValue;
                    advance.userId = Convert.ToInt32(personalId);

                    ReturnObject ret = mydata.UpdateAdvance(advance);
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
                    MessageBox.Show("Geçerli bir miktar giriniz.");
                }
           
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

        private void lbl_Main_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }
    }
}
