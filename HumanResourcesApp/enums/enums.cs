using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesApp.Models
{
    public class enums
    {
        public enum ReturnCode
        {
            Ok = 1,
            Error = 2
        }
        public enum Gender
        {
            Female = 1,
            Male = 2
        }
        
        public enum Statues
        {
            Active = 1,
            Inactive = 0,
            All = -1
        }

       
    }
}