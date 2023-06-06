using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.DBModels
{
    public class DBCustomer
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public int isActive { get; set; }
        public int isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public int addedUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public int upadtedUserId { get; set; }


    }
}
