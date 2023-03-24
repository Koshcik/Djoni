using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SqlClient;

namespace Djoni
{
    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Server = db.edu.cchgeu.ru;User = 201s_Koshickiy; Password = Qq123123; DataBase = 201s_Koshickiy");
        public void openConnection()
        {
            con.Open();
        }
        public void closeConnection()
        {
            con.Close();
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
    }
    
}
