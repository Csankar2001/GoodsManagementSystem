using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace GoodsManagementSystem.Pages.Client
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> ListClients = new List<ClientInfo>();
        public void OnGet()
        {
            try 
            {
                String ConnectionString = "Data Source=INTITCCUL-5343\\SQLEXPRESS;Initial Catalog=chandandb;Integrated Security=True;Encrypt=False";
                using(SqlConnection connection=new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using(SqlCommand command=new SqlCommand(sql, connection)) {
                        using (SqlDataReader reader= command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email= reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                //clientInfo.created_at = reader.GetString(5);

                                ListClients.Add(clientInfo);
                            }

                        }
                     
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    public class  ClientInfo
    {
        public int id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String created_at;

    }
}
