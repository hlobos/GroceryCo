using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Services
{
    public static class Receipt
    {
        public static string GenerateTotal(decimal total)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("\t----------------------------------------");

            builder.AppendLine("TOTAL: ");
            builder.AppendFormat("{0:C} ", total);
      
            builder.Append("\t----------------------------------------");

            return builder.ToString();
        }
    }
}
