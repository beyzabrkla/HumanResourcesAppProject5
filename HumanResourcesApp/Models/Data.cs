using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApp.Models;
using HumanResourcesApp.Models.DBModels;
using HumanResourcesApp.Models.QModels;
using HumanResourcesApp.Helpers;
using System.Data;
using System.Windows.Navigation;
using System.Windows.Markup;

namespace HumanResourcesApp.Models
{
    public class Data
    {
        // Data Acces Layer (Veri Erişim Katmanı)
        Dal mydal = new Dal();
        Tools mytool = new Tools();

        public ReturnObject Login(DBpersonal data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(data.username))
                {
                    throw new Exception("Lütfen Kullanıcı Adınızı giriniz.");
                }
                if (string.IsNullOrEmpty(data.password))
                {
                    throw new Exception("Lütfen Şifrenizi giriniz.");
                }

                sql = $@"SELECT p.id,p.username,p.firstname,
                        p.lastname,po.position,p.guid,p.image,
						p.addres,p.email,p.phone,p.gender,p.dateOfBirth,p.tc,p.auth
                        FROM 
                        [HumanResourcesDB].[dbo].[personal] p 
                        inner join [HumanResourcesDB].[dbo].[position] po on p.positionId = po.id
                        WHERE p.isDeleted = 0 and p.username = '{SecurityHelper.RequestControl(data.username)}'
                          and p.password = '{SecurityHelper.RequestControl(data.password)}'";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.objectData = new DBpersonal()
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()),
                        username = ds.Tables[0].Rows[0]["username"].ToString(),
                        firstname = ds.Tables[0].Rows[0]["firstname"].ToString(),
                        lastname = ds.Tables[0].Rows[0]["lastname"].ToString(),
                        positionName = ds.Tables[0].Rows[0]["position"].ToString(),
                        guid = ds.Tables[0].Rows[0]["guid"].ToString(),
                        image = ds.Tables[0].Rows[0]["image"].ToString(),
                        addres = ds.Tables[0].Rows[0]["addres"].ToString(),
                        email = ds.Tables[0].Rows[0]["email"].ToString(),
                        phone = ds.Tables[0].Rows[0]["phone"].ToString(),
                        tc = ds.Tables[0].Rows[0]["tc"].ToString(),
                        gender = Convert.ToInt32(ds.Tables[0].Rows[0]["gender"].ToString()),
                        auth = Convert.ToInt32(ds.Tables[0].Rows[0]["auth"].ToString()),
                        dateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[0]["dateOfBirth"].ToString())

                    };

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Lütfen Kullanıcı Adınızı ve Şifrenizi kontrol ediniz.");

                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject getUserPropsById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {

                sql = $@"SELECT p.id,p.username,p.firstname,
                        p.lastname,po.position,p.guid,p.image,
						p.addres,p.email,p.phone,p.gender,p.dateOfBirth,p.tc,p.auth
                        FROM 
                        [HumanResourcesDB].[dbo].[personal] p 
                        inner join [HumanResourcesDB].[dbo].[position] po on p.positionId = po.id
                        WHERE p.id = {id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.objectData = new DBpersonal()
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()),
                        username = ds.Tables[0].Rows[0]["username"].ToString(),
                        firstname = ds.Tables[0].Rows[0]["firstname"].ToString(),
                        lastname = ds.Tables[0].Rows[0]["lastname"].ToString(),
                        positionName = ds.Tables[0].Rows[0]["position"].ToString(),
                        guid = ds.Tables[0].Rows[0]["guid"].ToString(),
                        image = ds.Tables[0].Rows[0]["image"].ToString(),
                        addres = ds.Tables[0].Rows[0]["addres"].ToString(),
                        email = ds.Tables[0].Rows[0]["email"].ToString(),
                        phone = ds.Tables[0].Rows[0]["phone"].ToString(),
                        tc = ds.Tables[0].Rows[0]["tc"].ToString(),
                        gender = Convert.ToInt32(ds.Tables[0].Rows[0]["gender"].ToString()),
                        auth = Convert.ToInt32(ds.Tables[0].Rows[0]["auth"].ToString()),
                        dateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[0]["dateOfBirth"].ToString())

                    };

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Lütfen Kullanıcı Adınızı ve Şifrenizi kontrol ediniz.");

                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject UpdateUserProps(DBpersonal data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.username)))
                {
                    throw new Exception("Kullanıcı adı boş olamaz.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.firstname)) || string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.lastname)))
                {
                    throw new Exception("Ad , Soyad boş olamaz.");
                }

                if (!mytool.EmailControl(SecurityHelper.RequestControl(data.email)))
                {
                    throw new Exception("Lütfen geçerli bir email giriniz.");
                }

                if (!mytool.phoneNumberControl(data.phone))
                {
                    throw new Exception("Lütfen geçerli bir telefon bilgisi giriniz.");
                }

                if (!mytool.controlTckno(data.tc))
                {
                    throw new Exception("Lütfen geçerli bir T.C. Numarası  giriniz.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[personal] p where (p.username = '{SecurityHelper.RequestControl(data.username)}' or p.tc = '{SecurityHelper.RequestControl(data.tc)}') and p.id != {data.id}";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $@"update  [HumanResourcesDB].[dbo].[personal] 
                            set username = '{SecurityHelper.RequestControl(data.username)}',firstname = '{SecurityHelper.RequestControl(data.firstname)}',
                            lastname = '{SecurityHelper.RequestControl(data.lastname)}', email = '{SecurityHelper.RequestControl(data.email)}',phone = '{SecurityHelper.RequestControl(data.phone)}'
                            ,addres = '{SecurityHelper.RequestControl(data.addres)}',tc = '{SecurityHelper.RequestControl(data.tc)}',
                            gender = {data.gender},dateOfBirth = '{data.dateOfBirth}',updatedUserId = {data.id}, updatedDate = GETDATE()";
                    if (!string.IsNullOrEmpty(data.image))
                    {
                        sql += $",image = '{data.image}'";
                    }
                    if (!string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.password)))
                    {
                        sql += $",password = '{SecurityHelper.RequestControl(data.password)}'";
                    }
                    sql += $"where id = {data.id} ";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.message = "Bilgileriniz başarı ile güncellendi.";
                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Kullanıcı Adı veya T.C. numarası başkası tarafından kullanılıyor.");
                }
            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject GetDasboard()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"select
                (SELECT count(0) FROM [HumanResourcesDB].[dbo].[personal] where isActive = 1 and isDeleted = 0) as activePersonal,
                (SELECT count(0) FROM [HumanResourcesDB].[dbo].[project] where isDeleted = 0) as activeProject,
                (SELECT count(0) FROM [HumanResourcesDB].[dbo].[task] where isDeleted = 0 ) as activeTask,
                (SELECT count(0) FROM [HumanResourcesDB].[dbo].[customer] where isActive = 1 and isDeleted = 0) as activeCustomer";


                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    QDashboard Dashboard = new QDashboard()
                    {
                        activeCustomer = Convert.ToInt32(ds.Tables[0].Rows[0]["activeCustomer"].ToString()),
                        activePersonal = Convert.ToInt32(ds.Tables[0].Rows[0]["activePersonal"].ToString()),
                        activeProject = Convert.ToInt32(ds.Tables[0].Rows[0]["activeProject"].ToString()),
                        activeTask = Convert.ToInt32(ds.Tables[0].Rows[0]["activeTask"].ToString())
                    };

                    ret.objectData = Dashboard;
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Veri bulundu.";
                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject AddPosition(DBposition data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.positionName)))
                {
                    throw new Exception("Pozisyon Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[position] where position = '{SecurityHelper.RequestControl(data.positionName)}' and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"insert into  [HumanResourcesDB].[dbo].[position] (position,isActive,addedUserId) values('{SecurityHelper.RequestControl(data.positionName)}',{data.isActive},{data.addedUserId})";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Pozisyon başarılı bir şekilde eklendi";
                }
                else
                {
                    throw new Exception("Böyle bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject DeletePoisiton(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[personal] where positionId = {id} and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"update  [HumanResourcesDB].[dbo].[position] set isDeleted = 1 where id = {id}";
                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Pozisyon başarılı bir şekilde silindi";
                }
                else
                {
                    throw new Exception("Bu pozisyonu kullanan personeller mevcut.");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject GetPositions(int Statue)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT p.[id]
                      ,[position] as 'Pozisyon'
                      ,p.[createdDate] as 'Oluşturulma Tarihi'
                      ,pe.firstname + ' ' + pe.lastname as 'Ekleyen Personel' 
                      ,p.[updatedDate] as 'Güncelleme Tarihi'
                      ,pu.firstname + ' ' + pu.lastname as 'Güncelleyen Personel' 
                  FROM [HumanResourcesDB].[dbo].[position] p
                  inner join [HumanResourcesDB].[dbo].[personal] pe on p.addedUserId = pe.id
                  left join [HumanResourcesDB].[dbo].[personal] pu on p.updatedUserId = pu.id
                  where p.isDeleted = 0";


                if (Statue != (int)enums.Statues.All)
                {
                    sql += $"and p.isActive = {Statue}";
                }
                sql += "order by p.id desc";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }

            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject GetPositionById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $@"SELECT [id]
                      ,[position]
                      ,[isActive]
                      ,[isDeleted]
                      ,[createdDate]
                      ,[addedUserId]
                      ,[updatedDate]
                      ,[updatedUserId]
                  FROM [HumanResourcesDB].[dbo].[position] where id = {id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DBposition dBposition = new DBposition()
                    {
                        positionName = ds.Tables[0].Rows[0]["position"].ToString(),
                        isActive = Convert.ToInt32(ds.Tables[0].Rows[0]["isActive"].ToString()),
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()),
                        createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["createdDate"].ToString())
                    };

                    ret.objectData = dBposition;
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Veri bulundu";

                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject UptadePosition(DBposition data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.positionName)))
                {
                    throw new Exception("Pozisyon Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[position] where position = '{SecurityHelper.RequestControl(data.positionName)}' and isDeleted = 0 and id != {data.id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"update [HumanResourcesDB].[dbo].[position] set position = '{SecurityHelper.RequestControl(data.positionName)}',isActive = {data.isActive}, updatedDate = GETDATE() , updatedUserId = {data.upadtedUserId} where id ={data.id}";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Pozisyon başarılı bir şekilde güncellendi.";
                }
                else
                {
                    throw new Exception("Böyle başka bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject AddCustomer(DBCustomer data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.customerName)))
                {
                    throw new Exception("Müşteri Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[customer] where customerName = '{SecurityHelper.RequestControl(data.customerName)}' and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"insert into  [HumanResourcesDB].[dbo].[customer] (customerName,isActive,addedUserId) values('{SecurityHelper.RequestControl(data.customerName)}',{data.isActive},{data.addedUserId})";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Müşteri başarılı bir şekilde eklendi";
                }
                else
                {
                    throw new Exception("Böyle bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject GetCustomers(int Statue)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"  SELECT c.[id]
                      ,[customerName] as 'Müşteri İsmi'
                      ,c.[createdDate] as 'Oluşturulma Tarihi'
                      ,pe.firstname + ' ' + pe.lastname as 'Ekleyen Personel' 
                      ,c.[updatedDate] as 'Güncelleme Tarihi'
                      ,pu.firstname + ' ' + pu.lastname as 'Güncelleyen Personel' 
                  FROM [HumanResourcesDB].[dbo].[customer] c
                  inner join [HumanResourcesDB].[dbo].[personal] pe on c.addedUserId = pe.id
                  left join [HumanResourcesDB].[dbo].[personal] pu on c.updatedUserId = pu.id
                  where c.isDeleted = 0";


                if (Statue != (int)enums.Statues.All)
                {
                    sql += $"and c.isActive = {Statue}";
                }
                sql += "order by c.id desc";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }

            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject UptadeCustomer(DBCustomer data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.customerName)))
                {
                    throw new Exception("Müşteri Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[customer] where customerName = '{SecurityHelper.RequestControl(data.customerName)}' and isDeleted = 0 and id != {data.id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"update [HumanResourcesDB].[dbo].[customer] set customerName = '{SecurityHelper.RequestControl(data.customerName)}',isActive = {data.isActive}, updatedDate = GETDATE() , updatedUserId = {data.upadtedUserId} where id ={data.id}";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Müşteri başarılı bir şekilde güncellendi.";
                }
                else
                {
                    throw new Exception("Böyle başka bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject GetCustomerById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $@"SELECT [id]
                      ,[customerName]
                      ,[isActive]
                      ,[isDeleted]
                      ,[createdDate]
                      ,[addedUserId]
                      ,[updatedDate]
                      ,[updatedUserId]
                  FROM [HumanResourcesDB].[dbo].[customer] where id = {id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DBCustomer customer = new DBCustomer()
                    {
                        customerName = ds.Tables[0].Rows[0]["customerName"].ToString(),
                        isActive = Convert.ToInt32(ds.Tables[0].Rows[0]["isActive"].ToString()),
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()),
                        createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["createdDate"].ToString())
                    };

                    ret.objectData = customer;
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Veri bulundu";

                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject DeleteCustomer(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[project] where customerId = {id} and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $"update  [HumanResourcesDB].[dbo].[customer] set isDeleted = 1 where id = {id}";
                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Müşteri başarılı bir şekilde silindi.";
                }
                else
                {
                    throw new Exception("Elimizde bu müşteriye ait bir proje bulunmaktadır.");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject AddProject(DBProject data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.projectName)))
                {
                    throw new Exception("Proje Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[project] where projectName = '{SecurityHelper.RequestControl(data.projectName)}' and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $@"insert into [HumanResourcesDB].[dbo].[project] (projectName,customerId, projectOwnerId, startDate, endDate, statuId, isActive,addedUserId) 
                          values ('{SecurityHelper.RequestControl(data.projectName)}',{data.customerId},{data.projectOwnerId},'{data.startDate}','{data.endDate}',{data.statuId},{data.isActive},{data.addedUserId})";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Proje başarılı bir şekilde eklendi";
                }
                else
                {
                    throw new Exception("Böyle bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject GetProject(int statue)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT 
                      p.[id], 
                      [projectName] as 'Proje İsmi', 
                      cu.customerName as 'Müşteri İsmi', 
                      po.firstname + ' ' + po.lastname as 'Proje Sahibi', 
                      [startDate] as 'Proje Başlangıç Tarihi', 
                      [endDate] as 'Proje Bitiş Tarihi', 
					  ts.status 'Proje Durumu',
                      p.[createdDate] as 'Oluşturulma Tarihi', 
                      pe.firstname + ' ' + pe.lastname as 'Ekleyen Personel', 
                      p.[updatedDate] as 'Güncelleme Tarihi', 
                      pu.firstname + ' ' + pu.lastname as 'Güncelleyen Personel' 
                    FROM 
                      [HumanResourcesDB].[dbo].[project] p 
                      inner join [HumanResourcesDB].[dbo].[personal] pe on p.addedUserId = pe.id 
                      left join [HumanResourcesDB].[dbo].[personal] pu on p.updatedUserId = pu.id 
                      inner join [HumanResourcesDB].[dbo].[customer] cu on p.customerId = cu.id 
                      inner join [HumanResourcesDB].[dbo].[personal] po on po.id = p.projectOwnerId 
					  inner join [HumanResourcesDB].[dbo].[projectStatus] ts on p.statuId = ts.id
                    where 
                      p.isDeleted = 0";

                if (statue != (int)enums.Statues.All)
                {
                    sql += $"and p.isActive = {statue}";
                }
                sql += "order by p.id desc";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }

            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject UpdateProject(DBProject data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.projectName)))
                {
                    throw new Exception("Proje Adı boş geçilemez.");
                }

                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[project] where projectName = '{SecurityHelper.RequestControl(data.projectName)}' and isDeleted = 0 and id != {data.id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $@"update  [HumanResourcesDB].[dbo].[project] set projectName = '{SecurityHelper.RequestControl(data.projectName)}',customerId = {data.customerId},
                        startDate = '{data.startDate}',endDate = '{data.endDate}' , statuId = {data.statuId}, isActive = {data.isActive},updatedDate = GETDATE(),updatedUserId = {data.upadtedUserId}
                       ,projectOwnerId = {data.projectOwnerId}  where id = {data.id}";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Proje başarılı bir şekilde güncellendi";
                }
                else
                {
                    throw new Exception("Böyle bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject DeleteProject(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {

                sql = $"update  [HumanResourcesDB].[dbo].[project] set isDeleted = 1 where id = {id}";
                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                sql = $"update  [HumanResourcesDB].[dbo].[task] set isDeleted = 1 where projectId = {id}";
                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Müşteri başarılı bir şekilde silindi.";


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject GetProjectStatus()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = "SELECT  [id] ,[status] FROM [HumanResourcesDB].[dbo].[projectStatus]";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject GetProjectCustomers()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT id, customerName FROM [HumanResourcesDB].[dbo].[customer]
                        where isActive = 1 and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject GetProjectPersonals()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT id, firstname +' ' + lastname as 'Yetkili'
                       FROM [HumanResourcesDB].[dbo].[personal]  where isActive = 1 and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject GetProjectById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $@"SELECT  [id]
                      ,[projectName]
                      ,[customerId]
                      ,[projectOwnerId]
                      ,[startDate]
                      ,[endDate]
                      ,[statuId]
                      ,[isActive]
                      ,[createdDate]
                  FROM [HumanResourcesDB].[dbo].[project] where id = {id}";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DBProject project = new DBProject()
                    {
                        id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()),
                        projectName = ds.Tables[0].Rows[0]["projectName"].ToString(),
                        isActive = Convert.ToInt32(ds.Tables[0].Rows[0]["isActive"].ToString()),
                        statuId = Convert.ToInt32(ds.Tables[0].Rows[0]["statuId"].ToString()),
                        customerId = Convert.ToInt32(ds.Tables[0].Rows[0]["customerId"].ToString()),
                        projectOwnerId = Convert.ToInt32(ds.Tables[0].Rows[0]["projectOwnerId"].ToString()),
                        createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["createdDate"].ToString()),
                        startDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["startDate"].ToString()),
                        endDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["endDate"].ToString())
                    };

                    ret.objectData = project;
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Veri bulundu";

                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject GetStaffList(int statue)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"
                SELECT  pe.[id]
                      , pe.[firstname] + ' ' + pe.[lastname] as 'İsim'
                      , pe.[email]
                      , pe.[phone] as 'Telefon'
                      , pe.[wage] as 'Maaş'
                      , g.gender as 'Cinsiyet'
                      ,po.position as 'Posizyon'                 
                       ,pe.addres as 'Adres'
                      ,pe.[createdDate] as 'Oluşturulma Tarihi'
	                  ,pea.[firstname] + ' ' + pea.[lastname] as 'Ekleyen Personel'
                      ,pe.updatedDate as 'Güncellenme Tarihi'
	                  ,pu.[firstname] + ' ' + pu.[lastname] as 'Güncelleyen Personel'
                  FROM [HumanResourcesDB].[dbo].[personal] pe
                  inner join [HumanResourcesDB].[dbo].[position] po on pe.positionId = po.id
                  inner join [HumanResourcesDB].[dbo].[personal] pea on pe.addedUserId = pea.id
                  left join [HumanResourcesDB].[dbo].[personal] pu on pe.updatedUserId = pu.id
                  inner join [HumanResourcesDB].[dbo].[gender] g on g.id = pe.gender where 1=1 and pe.isDeleted = 0 
                    ";

                if (statue != (int)enums.Statues.All)
                {
                    sql += $"and pe.isActive = {statue}";
                }
                sql += "order by pe.id desc";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret.data = ds;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }
                else
                {
                    throw new Exception("Veri Bulunamadı...");
                }
            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject DeleteStaff(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT id FROM [HumanResourcesDB].[dbo].[personal] where id = {id} and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = $"update  [HumanResourcesDB].[dbo].[personal] set isDeleted = 1 where id = {id}";
                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);
                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Personel başarılı bir şekilde silindi.";
                }
                else
                {
                    throw new Exception("Personel Bulanmadı");
                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;
        }
        public ReturnObject AddStaf(DBpersonal data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.firstname)))
                {
                    throw new Exception("İsim boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.username)))
                {
                    throw new Exception("Kullanıcı Adı boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.lastname)))
                {
                    throw new Exception("Soy İsim boş geçilemez.");
                }

                if (!mytool.EmailControl(SecurityHelper.RequestControl(data.email)))
                {
                    throw new Exception("Lütfen geçerli bir email giriniz.");
                }

                if (!mytool.phoneNumberControl(data.phone))
                {
                    throw new Exception("Lütfen geçerli bir telefon bilgisi giriniz.");
                }


                if (data.gender <= 0)
                {
                    throw new Exception("Cinsiyet seçilmelidir.");
                }

                sql = $"SELECT *  FROM [HumanResourcesDB].[dbo].[personal] " +
                    $"where (username = '{data.username}' or email = '{data.email}' or phone = '{data.phone}' ) and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    sql = $@"insert into [HumanResourcesDB].[dbo].[personal]
                    (username,password,firstname,lastname,email,phone,gender,dateOfBirth,positionId,addedUserId)
                    values('{SecurityHelper.RequestControl(data.username)}','{SecurityHelper.RequestControl(data.password)}','{SecurityHelper.RequestControl(data.firstname)}','{SecurityHelper.RequestControl(data.lastname)}','{SecurityHelper.RequestControl(data.email)}','{SecurityHelper.RequestControl(data.phone)}',{data.gender},'{data.dateOfBirth}',{data.positionId},{localResources.personalInformation.id})";

                    mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                    ret.ReturnCode = enums.ReturnCode.Ok;
                    ret.message = "Personel başarılı bir şekilde eklendi";
                }
                else
                {
                    throw new Exception("Böyle bir kayıt mevcut.");
                }


            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject GetpersonalById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT* FROM [HumanResourcesDB].[dbo].[personal] where id = {id} and isDeleted = 0";

                ret.data = mydal.CommandExecuteReader(sql, mydal.myConnection);

                if (ret.data.Tables[0].Rows.Count > 0)
                {
                    DBpersonal dBpersonal = new DBpersonal();
                    dBpersonal.id = Convert.ToInt32(ret.data.Tables[0].Rows[0]["id"].ToString());
                    dBpersonal.positionId = Convert.ToInt32(ret.data.Tables[0].Rows[0]["positionId"].ToString());
                    dBpersonal.gender = Convert.ToInt32(ret.data.Tables[0].Rows[0]["gender"].ToString());
                    dBpersonal.wage = Convert.ToDecimal(ret.data.Tables[0].Rows[0]["wage"].ToString());
                    dBpersonal.username = ret.data.Tables[0].Rows[0]["username"].ToString();
                    dBpersonal.firstname = ret.data.Tables[0].Rows[0]["firstname"].ToString();
                    dBpersonal.lastname = ret.data.Tables[0].Rows[0]["lastname"].ToString();
                    dBpersonal.email = ret.data.Tables[0].Rows[0]["email"].ToString();
                    dBpersonal.phone = ret.data.Tables[0].Rows[0]["phone"].ToString();
                    dBpersonal.dateOfBirth = Convert.ToDateTime(ret.data.Tables[0].Rows[0]["dateOfBirth"].ToString());
                    dBpersonal.addres = ret.data.Tables[0].Rows[0]["addres"].ToString();

                    ret.objectData = dBpersonal;
                    ret.ReturnCode = enums.ReturnCode.Ok;

                }

            }
            catch (Exception ex)
            {
                ret.message = ex.Message.ToString();
            }

            return ret;
        }
        public ReturnObject updateStaf(DBpersonal data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.firstname)))
                {
                    throw new Exception("İsim boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.username)))
                {
                    throw new Exception("Kullanıcı Adı boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.lastname)))
                {
                    throw new Exception("Soy İsim boş geçilemez.");
                }

                if (!mytool.EmailControl(SecurityHelper.RequestControl(data.email)))
                {
                    throw new Exception("Lütfen geçerli bir email giriniz.");
                }

                if (!mytool.phoneNumberControl(data.phone))
                {
                    throw new Exception("Lütfen geçerli bir telefon bilgisi giriniz.");
                }

                if (data.gender <= 0)
                {
                    throw new Exception("Cinsiyet seçilmelidir.");
                }

                sql = $@"update  [HumanResourcesDB].[dbo].[personal] set 
                    username = '{SecurityHelper.RequestControl(data.username)}',firstname= '{SecurityHelper.RequestControl(data.firstname)}',lastname = '{SecurityHelper.RequestControl(data.lastname)}',email = '{SecurityHelper.RequestControl(data.email)}'
                    ,phone = '{SecurityHelper.RequestControl(data.phone)}',gender ={data.gender} ,
                    dateOfBirth = '{data.dateOfBirth}',positionId = {data.positionId} ,updatedUserId = {localResources.personalInformation.id} ,updatedDate = GETDATE()
                    where id = {data.id} and isDeleted = 0
                    ";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Personel başarılı bir şekilde güncellendi";




            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject updateStafAddress(int id, string address)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(address)))
                {
                    throw new Exception("Adres boş geçilemez.");
                }

                sql = $@"update  [HumanResourcesDB].[dbo].[personal] set  addres = '{SecurityHelper.RequestControl(address)}',
                    updatedUserId = {localResources.personalInformation.id} ,updatedDate = GETDATE()
                    where id = {id} and isDeleted = 0
                    ";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Personel adresi başarılı bir şekilde güncellendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject updateStafWage(int id, decimal wage)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (wage < 8500)
                {
                    throw new Exception("Geçerli bir maaş giriniz.");
                }

                sql = $@"update  [HumanResourcesDB].[dbo].[personal] set  wage = {wage},
                    updatedUserId = {localResources.personalInformation.id} ,updatedDate = GETDATE()
                    where id = {id} and isDeleted = 0
                    ";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Personel maaşı başarılı bir şekilde güncellendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject GetAdvanceList()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"
               SELECT a.[id] 
               ,p.firstname + ' ' + p.lastname as 'Personel'
              ,a.[advance] as 'Avans'
              ,a.[advanceDate] as 'Avans Tarihi' 
              ,a.[createdDate] as 'Oluşturulma Tarihi '
	           ,pa.firstname + ' ' + pa.lastname as 'Oluşturan Personel'
              ,a.[updatedDate] as 'Güncellenme Tarihi '
	          ,pu.firstname + ' ' + pu.lastname as 'Güncelleyen Personel'
          FROM [HumanResourcesDB].[dbo].[advancePayment] a 
          inner join [HumanResourcesDB].[dbo].[personal] p on a.personalId = p.id
          inner join [HumanResourcesDB].[dbo].[personal] pa on a.addedUserId = pa.id
          left join [HumanResourcesDB].[dbo].[personal] pu on a.updatedUserId = pu.id
          where a.isDeleted = 0";

                sql += " order by a.id desc";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject AddAdvance(DBAdvance data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.advanceNote)))
                {
                    throw new Exception("Avans notu boş geçilemez.");
                }

                if (data.advance < 0)
                {
                    throw new Exception("Lütfen geçerli bir miktar giriniz");
                }



                sql = $@"insert into [HumanResourcesDB].[dbo].[advancePayment] (personalId,advance,advanceNote,advanceDate,addedUserId) 
                            values({data.userId},{data.advance},'{SecurityHelper.RequestControl(data.advanceNote)}','{data.advanceDate}',{localResources.personalInformation.id})";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Avans başarılı bir şekilde eklendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject GetAdvanceById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT * FROM [HumanResourcesDB].[dbo].[advancePayment] where id = {id} and isDeleted = 0";

                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;
                if (ret.data.Tables[0].Rows.Count > 0)
                {
                    DBAdvance advance = new DBAdvance();
                    advance.id = Convert.ToInt32(ret.data.Tables[0].Rows[0]["id"].ToString());
                    advance.userId = Convert.ToInt32(ret.data.Tables[0].Rows[0]["personalId"].ToString());
                    advance.advance = Convert.ToDecimal(ret.data.Tables[0].Rows[0]["advance"].ToString());
                    advance.advanceDate = Convert.ToDateTime(ret.data.Tables[0].Rows[0]["advanceDate"].ToString());
                    advance.advanceNote = ret.data.Tables[0].Rows[0]["advanceNote"].ToString();

                    ret.objectData = advance;

                    ret.ReturnCode = enums.ReturnCode.Ok;
                }


            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject UpdateAdvance(DBAdvance data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.advanceNote)))
                {
                    throw new Exception("Avans notu boş geçilemez.");
                }

                if (data.advance < 0)
                {
                    throw new Exception("Lütfen geçerli bir miktar giriniz");
                }



                sql = $@"update [HumanResourcesDB].[dbo].[advancePayment] set personalId = {data.userId} , advance = {data.advance},
                advanceNote = '{SecurityHelper.RequestControl(data.advanceNote)}' ,advanceDate = '{data.advanceDate}' , updatedDate = GETDATE(), updatedUserId = {localResources.personalInformation.id}
                where id = {data.id} and isDeleted = 0";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Avans başarılı bir şekilde güncellendi.";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject DeleteAdvance(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {


                sql = $@"update [HumanResourcesDB].[dbo].[advancePayment] set isDeleted = 1
                where id = {id} and isDeleted = 0";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "Avans başarılı bir şekilde silindi.";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject getPermissionList()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"
             
               SELECT a.[id] 
               ,p.firstname + ' ' + p.lastname as 'Personel'
              ,a.day as 'Gün'
              ,a.[createdDate] as 'Oluşturulma Tarihi '
	           ,pa.firstname + ' ' + pa.lastname as 'Oluşturan Personel'
              ,a.[updatedDate] as 'Güncellenme Tarihi '
	          ,pu.firstname + ' ' + pu.lastname as 'Güncelleyen Personel'
          FROM  [HumanResourcesDB].[dbo].[permissionDay] a 
          inner join [HumanResourcesDB].[dbo].[personal] p on a.personalId = p.id
          inner join [HumanResourcesDB].[dbo].[personal] pa on a.addedUserId = pa.id
          left join [HumanResourcesDB].[dbo].[personal] pu on a.updatedUserId = pu.id
          where a.isDeleted = 0";

                sql += " order by a.id desc";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject AddPermission(DBPermit data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.reasonForPermission)))
                {
                    throw new Exception("izin açıklaması boş geçilemez.");
                }

                sql = $@"insert into [HumanResourcesDB].[dbo].[permissionDay] (personalId,day,addedUserId,reasonForPermission)
                values ({data.userId},'{data.day}',{localResources.personalInformation.id},'{SecurityHelper.RequestControl(data.reasonForPermission)}')";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İzin başarılı bir şekilde eklendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject getPermissionById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $" SELECT  *   FROM  [HumanResourcesDB].[dbo].[permissionDay] a where id = {id} ";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);
                ret.data = ds;
                if (ret.data.Tables[0].Rows.Count > 0)
                {
                    DBPermit permit = new DBPermit();
                    permit.id = Convert.ToInt32(ret.data.Tables[0].Rows[0]["id"].ToString());
                    permit.userId = Convert.ToInt32(ret.data.Tables[0].Rows[0]["personalId"].ToString());
                    permit.day = Convert.ToDateTime(ret.data.Tables[0].Rows[0]["day"].ToString());
                    permit.reasonForPermission = ret.data.Tables[0].Rows[0]["reasonForPermission"].ToString();


                    ret.objectData = permit;
                    ret.ReturnCode = enums.ReturnCode.Ok;

                }


            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject EditPermission(DBPermit data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.reasonForPermission)))
                {
                    throw new Exception("izin açıklaması boş geçilemez.");
                }

                sql = $@"update [HumanResourcesDB].[dbo].[permissionDay] set personalId = {data.userId} , day = '{data.day}',reasonForPermission = '{SecurityHelper.RequestControl(data.reasonForPermission)}',updatedUserId = {localResources.personalInformation.id} ,updatedDate = GETDATE() where id = {data.id}";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İzin başarılı bir şekilde güncellendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject DeletePermission(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {


                sql = $@"update [HumanResourcesDB].[dbo].[permissionDay] set isDeleted = 1
                where id = {id} and isDeleted = 0";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İzin başarılı bir şekilde silindi.";

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject getAuthList()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"
              SELECT  p.[id]
                  ,[username] as 'Kullanıcı Adı'
                  ,[firstname] + ' ' + [lastname] as 'Personel'
                  ,a.[auth] as 'Yetki Seviyesi'
                  ,p.[createdDate] as 'Oluşturulma Tarihi'
              FROM [HumanResourcesDB].[dbo].[personal] p
              inner join [HumanResourcesDB].[dbo].[authLevel] a on p.auth = a.id
              where p.isDeleted = 0";


                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject getAuthListForEdit()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT * FROM [HumanResourcesDB].[dbo].[authLevel]";


                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject updateUserAuhtLevel(int id, int auth)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"update  [HumanResourcesDB].[dbo].[personal] set auth = {auth} where id = {id}";

                  mydal.CommandExecuteReader(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;

                ret.message = "Yetki seviyesi güncellendi";

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject getTaskList(int projectId)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT 
                  t.[id], 
                  [taskName] as 'İş Adı',
                  p.[projectName] as 'Proje Adı',
                  ta.[status] as 'Durum', 
                  t.[createdDate] as 'Oluşturulma Tarihi', 
                  pea.[firstname] + ' ' + pea.[lastname] as 'Ekleyen Personel', 
                  t.updatedDate as 'Güncellenme Tarihi', 
                  pu.[firstname] + ' ' + pu.[lastname] as 'Güncelleyen Personel' 
                FROM 
                  [HumanResourcesDB].[dbo].[task] t 
                  inner join [HumanResourcesDB].[dbo].[personal] pea on t.addedUserId = pea.id 
                  left join [HumanResourcesDB].[dbo].[personal] pu on t.updatedUserId = pu.id
                  inner join [HumanResourcesDB].[dbo].[project] p on t.projectId = p.id
                  inner join [HumanResourcesDB].[dbo].[taskStatus] ta on t.statuId = ta.id
                where t.isDeleted = 0  ";

                if (projectId > 0)
                {
                    sql += $"and t.projectId = {projectId}";
                }

                sql += " order by t.id desc";
                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;

        }
        public ReturnObject getTaskStatuList()
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = @"SELECT * FROM [HumanResourcesDB].[dbo].[taskStatus]";


                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);


                ret.data = ds;

                ret.ReturnCode = enums.ReturnCode.Ok;

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject AddTask(DBTask data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.taskName)))
                {
                    throw new Exception("İş adı boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.taskDescription)))
                {
                    throw new Exception("İş açıklaması boş geçilemez.");
                }

                sql = $@"insert into [HumanResourcesDB].[dbo].[task] (taskName,taskDescription,projectId,statuId,addedUserId)
                        values('{SecurityHelper.RequestControl(data.taskName)}','{SecurityHelper.RequestControl(data.taskDescription)}',{data.projectId},{data.statuId},{localResources.personalInformation.id})";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İş başarılı bir şekilde eklendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject getTaskById(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $"SELECT * FROM [HumanResourcesDB].[dbo].[task] where id = {id} ";


                DataSet ds = mydal.CommandExecuteReader(sql, mydal.myConnection);
                ret.data = ds;
                if (ret.data.Tables[0].Rows.Count > 0)
                {
                    DBTask task = new DBTask();
                    task.id = Convert.ToInt32(ret.data.Tables[0].Rows[0]["id"].ToString());
                    task.statuId = Convert.ToInt32(ret.data.Tables[0].Rows[0]["statuId"].ToString());
                    task.projectId = Convert.ToInt32(ret.data.Tables[0].Rows[0]["projectId"].ToString());
                    task.taskName = ret.data.Tables[0].Rows[0]["taskName"].ToString();
                    task.taskDescription = ret.data.Tables[0].Rows[0]["taskDescription"].ToString();

                    ret.objectData = task;
                    ret.ReturnCode = enums.ReturnCode.Ok;
                }

            }
            catch (Exception ex)
            {

                ret.message = ex.Message;
            }

            return ret;
        }
        public ReturnObject updateTask(DBTask data)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.taskName)))
                {
                    throw new Exception("İş adı boş geçilemez.");
                }

                if (string.IsNullOrWhiteSpace(SecurityHelper.RequestControl(data.taskDescription)))
                {
                    throw new Exception("İş açıklaması boş geçilemez.");
                }

                sql = $@"update [HumanResourcesDB].[dbo].[task] set taskName = '{SecurityHelper.RequestControl(data.taskName)}',taskDescription = '{SecurityHelper.RequestControl(data.taskDescription)}' ,
                projectId = {data.projectId},statuId = {data.statuId}
               ,updatedUserId = {localResources.personalInformation.id}, updatedDate = GETDATE()
               where id = {data.id} ";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İş başarılı bir şekilde güncellendi";



            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
        public ReturnObject DeleteTask(int id)
        {
            ReturnObject ret = new ReturnObject();
            ret.ReturnCode = enums.ReturnCode.Error;
            string sql = string.Empty;

            try
            {
                sql = $@"update [HumanResourcesDB].[dbo].[task] set isDeleted = 1
                where id = {id} and isDeleted = 0";

                mydal.CommandExecuteNonQuery(sql, mydal.myConnection);

                ret.ReturnCode = enums.ReturnCode.Ok;
                ret.message = "İzin başarılı bir şekilde silindi.";

            }
            catch (Exception ex)
            {
                ret.message = ex.Message;
            }
            return ret;

        }
    }
}
