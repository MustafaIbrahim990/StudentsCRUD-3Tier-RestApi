using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.DAL
{
    public static class clsDataSettings
    {
        public static readonly string ConnectionString = "Server = localhost; DataBase = Students_DB; User Id = sa; PassWord = sa123456; Encrypt = True; TrustServerCertificate = True;";
        //public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}