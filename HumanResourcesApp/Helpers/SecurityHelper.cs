using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesApp.Helpers
{
    public class SecurityHelper
    {
        public static string RequestControl(string value)
        {
            if (value is null)
                return string.Empty;
            else
            {
                if (value.ToLower().Contains("insert"))
                    value = "";
                else if (value.ToLower().Contains("delete"))
                    value = "";
                else if (value.ToLower().Contains("drop"))
                    value = "";
                else if (value.ToLower().Contains("create"))
                    value = "";
                else if (value.ToLower().Contains("joing"))
                    value = "";
                else if (value.ToLower().Contains("union"))
                    value = "";
                else if (value.ToLower().Contains("'"))
                    value = value.Replace("'", "`");
                else if (value.ToLower().Contains("<"))
                    value = "";
                else if (value.ToLower().Contains(">"))
                    value = "";
                else if (value.ToLower().Contains("select"))
                    value = "";
                else if (value.ToLower().Contains("where"))
                    value = "";
                else if (value.ToLower().Contains("from"))
                    value = "";
                else if (value.ToLower().Contains("into"))
                    value = "";
                else if (value.ToLower().Contains("#"))
                    value = "";
                else if (value.ToLower().Contains("--"))
                    value = "";
                return value;
            }
        }
    }
}