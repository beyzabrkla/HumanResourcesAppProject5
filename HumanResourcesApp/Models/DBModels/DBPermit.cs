using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.DBModels
{
    public class DBPermit
    {

        public int id { get; set; }
        public int userId { get; set; }
        public DateTime day { get; set; }
        public string advanceNote { get; set; }
        public DateTime advanceDate { get; set; }
        public string reasonForPermission { get; set; }

    }
}
