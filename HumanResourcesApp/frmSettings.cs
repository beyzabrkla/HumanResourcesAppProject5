using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesApp.Models.DBModels;
using HumanResourcesApp.Models.QModels;
using HumanResourcesApp.Models;
using HumanResourcesApp.Helpers;

namespace HumanResourcesApp
{
    public partial class frmSettings : Form
    {
        [Obsolete]
        public frmSettings()
        {
            InitializeComponent();
        }

        public string img_Str = string.Empty;
        public Image img = null;

        Data mydata = new Data();
        Tools mytools = new Tools();


        // Sayfa açılırken login olurken localresources class ına kaydettiğimiz verileri inputlara doldurma
        private void frmSettings_Load(object sender, EventArgs e)
        {
            DBpersonal personalInfo = localResources.personalInformation;

            txt_name.Text = personalInfo.firstname;
            txt_lastname.Text = personalInfo.lastname;
            txt_username.Text = personalInfo.username;
            txt_mail.Text = personalInfo.email;
            txt_telno.Text = personalInfo.phone;
            txt_tc.Text = personalInfo.tc;

            if (personalInfo.gender == (int)enums.Gender.Female)
            {
                radioButton_woman.Checked = true;
            }
            else
            {
                radioButton_men.Checked = true;
            }

            dp_dateOfBirth.Value = personalInfo.dateOfBirth;
            txtbox_addres.Text = personalInfo.addres;

        }

        //Kaydetme işlemi
        private void btn_set_Click(object sender, EventArgs e)
        {
            string name= txt_name.Text;
            string lastname= txt_lastname.Text;
            string username= txt_username.Text;
            string mail= txt_mail.Text;
            string phone= txt_telno.Text;   
            string tc= txt_tc.Text;
            bool check = radioButton_woman.Checked;
            bool check2 = radioButton_men.Checked;
            string password = txt_password.Text;
            string address = txtbox_addres.Text;

            DBpersonal personalInfo = new DBpersonal()
            {
                id = localResources.personalInformation.id,
                firstname = txt_name.Text,
                lastname = txt_lastname.Text,
                username = txt_username.Text,
                email = txt_mail.Text,
                phone = txt_telno.Text,
                tc = txt_tc.Text,
                dateOfBirth = dp_dateOfBirth.Value,
                addres = txtbox_addres.Text,
                image = img_Str,
                password = txt_password.Text
            };

            if (radioButton_woman.Checked == true)
            {
                personalInfo.gender = (int)enums.Gender.Female;
            }
            else if (radioButton_men.Checked == true)
            {
                personalInfo.gender = (int)enums.Gender.Male;
            }

            ReturnObject ret = mydata.UpdateUserProps(personalInfo);

            MessageBox.Show(ret.message);

            ret = mydata.getUserPropsById(personalInfo.id);
            if (ret.ReturnCode == enums.ReturnCode.Ok)
            {
                localResources.personalInformation = (DBpersonal)ret.objectData;

                localResources.frmMain.label2.Text = localResources.personalInformation.firstname + " " + localResources.personalInformation.lastname;

                localResources.frmMain.label3.Text = localResources.personalInformation.positionName;
               
                if (!string.IsNullOrWhiteSpace(localResources.personalInformation.image))
                {
                    localResources.frmMain.picPhoto.Image = mytools.Base64ToImage(localResources.personalInformation.image);
                }


            }

        }

        //Open filedialog kullanarak resim ekleme işlemi
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PictureBox picture = new PictureBox();
                    picture.Image = new Bitmap(ofd.FileName);

                    btn_picture.Image = picture.Image;

                    img_Str = mytools.ImageToBase64(ofd.FileName);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}
