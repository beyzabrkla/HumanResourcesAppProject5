using HumanResourcesApp.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesApp
{

    public partial class frmMain : Form
    {

        Tools mytools = new Tools();
        int authLevel = 0;
        public frmMain()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(pnlMenu);

        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            //Form açıldığında otomatik olarak Dashboard formunu getirme
            frmDahboard frmDahboard = new frmDahboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmDahboard, "Anasayfa");


            // Ad Soyad
            label2.Text = localResources.personalInformation.firstname + " " + localResources.personalInformation.lastname;

            //Pozisyon
            label3.Text = localResources.personalInformation.positionName;


            //yetki
            this.authLevel = localResources.personalInformation.auth;

            //Resim
            if (!string.IsNullOrWhiteSpace(localResources.personalInformation.image))
            {
                localResources.frmMain.picPhoto.Image = mytools.Base64ToImage(localResources.personalInformation.image);
            }

        }


        //main mouse hareketleri
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

        private void bunifuIconButton1_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void bunifuIconButton1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }

        private void lbl_Mainname_MouseDown(object sender, MouseEventArgs e)
        {
            tiklananX = e.X;
            tiklananY = e.Y;
        }

        private void lbl_Mainname_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            this.Left += e.X - tiklananX;
            this.Top += e.Y - tiklananY;
        }



        #region Anasayfa Yönlendirmeleri

        private void setPanel(Form form, string baslik)
        {
            this.panel_Container.Controls.Clear();
            this.panel_Container.Controls.Add(form);
            form.Show();

            lbl_Mainname.Text = baslik;

        }

        //Dashboad Sayfası Açma
        private void btn_MainMenu_Click(object sender, EventArgs e)
        {
            frmDahboard frmDahboard = new frmDahboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmDahboard, "Anasayfa");
        }

        //Müşteriler Sayfası Açma
        private void btn_customer_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmCustomerList, "Müşteriler");
        }

        //Personeller Sayfası Açma
        private void btn_staff_Click(object sender, EventArgs e)
        {
            frmStaffList frmStaffList = new frmStaffList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmStaffList, "Personeller");

        }

        //Personel Pozisyonları Tablosu Açma
        private void btn_positions_Click(object sender, EventArgs e)
        {
            frmStaffPositionsList frmPersonalPositionList = new frmStaffPositionsList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmPersonalPositionList, "Personel Pozisyonları");
        }

        //Personel Avansları Tablosu Açma
        private void btn_advancePayment_Click(object sender, EventArgs e)
        {
            frmAdvanceList frmPersonnelAdvancesList = new frmAdvanceList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmPersonnelAdvancesList, "Personel Avansları");
        }

        //Personel İzinleri Tablosu Açma
        private void btn_permissions_Click(object sender, EventArgs e)
        {
            frmStaffPermitsList frmStaffPermitsList = new frmStaffPermitsList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmStaffPermitsList, "Personel İzinleri");
        }

        //Personel Yetki İşlemleri Tablosu Açma
        private void btn_authorization_Click(object sender, EventArgs e)
        {
            if (authLevel == 2)
            {
                frmStaffAuthList frmStaffAuthList = new frmStaffAuthList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                setPanel(frmStaffAuthList, "Personel Yetki İşlemleri ");
            }
            else
            {
                MessageBox.Show("Erişim yetkiniz bulunmamaktadır.");
            }
       
        }

        //Projeler Sayfası Açma
        private void btn_projects_Click(object sender, EventArgs e)
        {
            frmProjectsList frmProjectsList = new frmProjectsList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmProjectsList, "Projeler ");
        }

        //Yapılacak İşler Sayfası Açma
        private void btn_task_Click(object sender, EventArgs e)
        {
            frmTaskList frmTaskList = new frmTaskList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmTaskList, "Yapılacak İşler");
        }

        //Ayarlar Sayfası Açma
        private void btn_settings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            setPanel(frmSettings, "Ayarlar");
        }

        #endregion

    }

}