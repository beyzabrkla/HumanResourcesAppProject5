using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.DBModels
{
    public class DBProject
    {

        public int id { get; set; }
        public string projectName { get; set; }
        public int customerId { get; set; }
        public int projectOwnerId { get; set; }
        public int statuId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int isActive { get; set; }
        public int isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public int addedUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public int upadtedUserId { get; set; }


    }
}
