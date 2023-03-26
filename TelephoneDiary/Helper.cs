using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDiary
{
    public static class Helper
    {
        public static string conn(string name) 
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
