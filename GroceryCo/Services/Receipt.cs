using System.Text;

namespace GroceryCo.Services
{
    public static class Receipt
    {
        public static string GenerateTotalStub(decimal total)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("\t----------------------------------------");

            builder.AppendFormat("{0,-35}{1:C} ", "\n\tTOTAL: ", total);
      
            builder.Append("\n\t----------------------------------------");

            return builder.ToString();
        }
    }
}
