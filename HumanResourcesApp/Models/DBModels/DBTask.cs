using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.DBModels
{
    public class DBTask
    {

        public int id { get; set; }
        public int projectId { get; set; }
        public int statuId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }

    }
}
