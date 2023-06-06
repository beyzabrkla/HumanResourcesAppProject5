using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using HumanResourcesApp.Helpers;
using HumanResourcesApp.Models;

namespace HumanResourcesApp.Helpers
{
    public class Tools
    {
        Dal mydal = new Dal();

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        //Regex ile E-mail Controlu
        public bool EmailControl(string input)
        {
            bool result = Regex.IsMatch(input, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return result;
        }

        public bool phoneNumberControl(string Telefon)
        {
            string RegexDesen = @"^(05(\d{9}))$";
            Match Eslesme = Regex.Match(Telefon, RegexDesen, RegexOptions.IgnoreCase);
            return Eslesme.Success;
        }

        public string clearPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            phoneNumber = "0" + phoneNumber;

            return phoneNumber;
        }

        public bool controlTckno(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        public string ReplaceTurkishCharacters(string turkishWord)
        {
            string source = "ığüşöçĞÜŞİÖÇ";
            string destination = "igusocGUSIOC";

            string result = turkishWord;

            for (int i = 0; i < source.Length; i++)
            {
                result = result.Replace(source[i], destination[i]);
            }

            return result;
        }

        public string ImageToBase64(string _imagePath)
        {
            string _base64String = null;

            using (System.Drawing.Image _image = System.Drawing.Image.FromFile(_imagePath))
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, _image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    //return "data:image/jpg;base64," + _base64String;
                    return _base64String;
                }
            }
        }

        public Image Base64ToImage(string pic)
        {
            Image ret;
            byte[] imageBytes = Convert.FromBase64String(pic);
          
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ret = Image.FromStream(ms, true);
            }
            return ret;
        }

        //Excell csv çıktısı verir
        public void ExportToExcel(DataSet ds)
        {
            try
            {
                string FileDelimiter = ";";
                DataTable d_table = ds.Tables[0];
                SaveFileDialog FileFullPath = new SaveFileDialog();
                FileFullPath.DefaultExt = ".csv";
                FileFullPath.Filter = "CSV Dosyası (*.csv)|*.csv";
                if (FileFullPath.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = null;
                    sw = new StreamWriter(FileFullPath.FileName, false, Encoding.UTF8); // UTF-8 kodlamasıyla dosyayı oluştur
                    int ColumnCount = d_table.Columns.Count;
                    for (int ic = 0; ic < ColumnCount; ic++)
                    {
                        sw.Write(d_table.Columns[ic]);
                        if (ic < ColumnCount - 1)
                        {
                            sw.Write(FileDelimiter);
                        }
                    }
                    sw.Write(sw.NewLine);
                    foreach (DataRow dr in d_table.Rows)
                    {
                        for (int ir = 0; ir < ColumnCount; ir++)
                        {
                            if (!Convert.IsDBNull(dr[ir]))
                            {
                                if (d_table.Columns[ir].DataType.Name == "String")
                                {
                                    sw.Write("\"" + dr[ir].ToString() + "\"");
                                }
                                else
                                {
                                    sw.Write(dr[ir].ToString());
                                }
                            }
                            if (ir < ColumnCount - 1)
                            {
                                sw.Write(FileDelimiter);
                            }
                        }
                        sw.Write(sw.NewLine);
                    }
                    sw.Close();
                    MessageBox.Show("Excel CSV çıktısı oluşturuldu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata ile karşılaşıldı");
            }
        }

        public int GetId(Bunifu.UI.WinForms.BunifuDataGridView dataGridView)
        {
            int id = 0;

            if (dataGridView.SelectedRows.Count == 1)
            {
                try
                {
                    string selected_Row = dataGridView.SelectedRows[0].Cells["id"].Value.ToString();
                    if (!string.IsNullOrEmpty(selected_Row))
                    {
                        id = Convert.ToInt32(selected_Row);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir veri seçiniz...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lütfen geçerli bir veri seçiniz...");
                }
            }
            else
            {
                MessageBox.Show("Lütfen sadece bir adet veri seçiniz...");
            }

            return id;
        }
    }
}