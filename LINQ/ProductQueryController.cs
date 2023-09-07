using LINQ;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace practiceDapper
{

    public class ProductQueries
    {
        public List<Product> productList { get; set; } = new List<Product>();

        public ProductQueries(string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                productList = connection.Query<Product>("select * from Production.Product");
            }
        }

        //products that don't have a null color
        public IEnumerable<Product> productsThatHaveColors() {
            return productList.Where(product => product.Color != null);
        }
    }
}