using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LiveOnRiviera.DAL
{
    public class MasterData
    {
        public static DataTable GetData()
        {

            //using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString)) // strCon is the string containing connection string

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\mahith\Documents\Visual Studio 2013\Projects\LiveOnRiviera\LiveOnRiviera\App_Data\PDataStore.mdf;Integrated Security=True")) // strCon is the string containing connection string

           // using (SqlConnection connection = new SqlConnection(@"Data Source=MAHITH;Initial Catalog=PDataStore;Integrated Security=True")) // strCon is the string containing connection string
            {
                SqlCommand command = new SqlCommand("select * from MasterData order by cast(HNO as int)", connection);
                connection.Open();
                //SqlDataReader reader = command.ExecuteReader();
                DataTable dtData = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                Console.WriteLine("connection opened successfuly");
                adapt.Fill(dtData);
                connection.Close();
                return dtData;


            }
        }


        public static DataTable GetHomeData()
        {

            //using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString)) // strCon is the string containing connection string

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\mahith\Documents\Visual Studio 2013\Projects\LiveOnRiviera\LiveOnRiviera\App_Data\PDataStore.mdf;Integrated Security=True")) // strCon is the string containing connection string
            //using (SqlConnection connection = new SqlConnection(@"Data Source=MAHITH;Initial Catalog=PDataStore;Integrated Security=True")) // strCon is the string containing connection string
            {
                SqlCommand command = new SqlCommand("select Description from HomeData", connection);
                connection.Open();
                //SqlDataReader reader = command.ExecuteReader();
                DataTable dtData = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                // Console.WriteLine("connection opened successfuly");
                adapt.Fill(dtData);
                connection.Close();
                return dtData;


            }
        }


        public static void GetDescription(string Description)
        {

            //using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString)) // strCon is the string containing connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\mahith\Documents\Visual Studio 2013\Projects\LiveOnRiviera\LiveOnRiviera\App_Data\PDataStore.mdf;Integrated Security=True")) // strCon is the string containing connection string
               // using (SqlConnection connection = new SqlConnection(@"Data Source=MAHITH;Initial Catalog=PDataStore;Integrated Security=True")) // strCon is the string containing connection string
                {
                    SqlCommand command = new SqlCommand("UPDATE [HomeData] SET Description = '" + Description + "' where ID='1' ", connection);
                    connection.Open();
                    int nNoAdded = command.ExecuteNonQuery();
                    // Execute the SQL command
                }
            }
            catch (Exception)
            {
                //throw;


            }
        }
    }
}