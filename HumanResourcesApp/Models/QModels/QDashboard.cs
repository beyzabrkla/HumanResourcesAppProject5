using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApp.Models.QModels
{
    public class QDashboard
    {
        public int activePersonal { get; set; }
        public int activeProject { get; set; }
        public int activeTask { get; set; }
        public int activeCustomer { get; set; }
    }
}
