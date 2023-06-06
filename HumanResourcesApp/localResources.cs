using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HumanResourcesApp.Models.DBModels;

namespace HumanResourcesApp
{
    public class localResources
    {
        public static frmMain frmMain = new frmMain();
        public static DBpersonal personalInformation { get; set; }
    }
}
