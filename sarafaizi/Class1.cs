using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sarafaizi
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection(@"Data Source=SETARAH\SQLEXPRESS;Initial Catalog=NIGIN_RETURANT;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
