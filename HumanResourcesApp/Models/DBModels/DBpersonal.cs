using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.DBModels
{
    public class DBpersonal
    {

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string tc { get; set; }
        public string image { get; set; }
        public decimal wage { get; set; }
        public int gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string addres { get; set; }
        public int positionId { get; set; }
        public string guid { get; set; }
        public int isActive { get; set; }
        public int isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public int addedUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public int updatedUserId { get; set; }
        public int auth { get; set; }

        //Sub propertys

        public string positionName { get; set; }
        public Image postedImage { get; set; }


    }
}
