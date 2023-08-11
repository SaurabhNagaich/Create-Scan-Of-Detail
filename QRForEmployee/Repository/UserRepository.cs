using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace QRForEmployee.Repository
{
    public class UserRepository
    {

        SqlConnection myConnection;
        SqlCommand myCommand;
        public UserRepository()
        {
            myConnection = new SqlConnection("server=TRAININGDB01;database=SNAGAICH_User;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public bool CreateUser(User user)
        {

            int status = 0;
            myCommand = new SqlCommand();
            myCommand.CommandText = "SP_UserQR";
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
            myCommand.Parameters.AddWithValue("@LastName", user.LastName);
            myCommand.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
            myCommand.Parameters.AddWithValue("@Latitude", user.Latitude);
            myCommand.Parameters.AddWithValue("@Longitude",user.Longitude);
            myCommand.Parameters.AddWithValue("@QRImage", user.Img);
            myCommand.Parameters.AddWithValue("@StatementType", "insert");
            myCommand.Connection = myConnection;
            try
            {

                myConnection.Open();
                status = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            if (status == 1)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public List<User> GetUserDetails()
        {
            List<User> users = new List<User>();
            myCommand = new SqlCommand();
            myCommand.CommandText = "SP_UserQR";
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@StatementType", "selectall");
            myCommand.Connection = myConnection;
            try
            {
                myConnection.Open();
                SqlDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.FirstName = reader.GetString(0);
                    user.LastName = reader.GetString(1);
                    user.DateOfBirth = reader.GetString(2);
                    user.Latitude = reader.GetString(3);
                    user.Longitude= reader.GetString(4);
                    user.Img = reader.GetString(6);
                    users.Add(user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
            }
            finally
            {
                myConnection.Close();
            }
            return users;
        }
    }
}