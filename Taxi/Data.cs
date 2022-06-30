using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    public static class Data
    {
        public static string ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Taxi; Persist Security Info=True; User ID=sa;Password=sa";
        public static Autarization autarization;
        public static int? AutorizEmp;
        public static int idOrder;
    }
}
