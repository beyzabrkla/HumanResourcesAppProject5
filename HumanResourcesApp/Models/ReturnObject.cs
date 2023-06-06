using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using HumanResourcesApp.Models;

namespace HumanResourcesApp.Models
{
    public class ReturnObject
    {
        public enums.ReturnCode ReturnCode { get; set; }
        public string message { get; set; }
        public DataSet data { get; set; }
        public Object objectData { get; set; }

    }
}