using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Security_Logins " +
                        "(Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language)" +
                        " values (@Id,@Login,@Password,@Created,@PasswordUpdate,@AgreementAccepted,@IsLocked,@IsInactive,@EmailAddress,@PhoneNumber,@FullName,@ForceChangePassword,@PrefferredLanguage)";
                    cmd.Connection = conn;



                    foreach (SecurityLoginPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Password", item.Password);
                        cmd.Parameters.AddWithValue("@Created", item.Created);
                        cmd.Parameters.AddWithValue("@PasswordUpdate", item.PasswordUpdate);
                        cmd.Parameters.AddWithValue("@AgreementAccepted", item.AgreementAccepted);
                        cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                        cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                        cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                        cmd.Parameters.AddWithValue("@FullName", item.FullName);
                        cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                        cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);



                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally { conn.Close(); }
            }
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Security_Logins where Id=@Id";
                    cmd.Connection = conn;

                    foreach (SecurityLoginPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);


                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { conn.Close(); }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Security_Logins " +
                        "SET Login=@Login,Password=@Password,Created_Date=@Created,Password_Update_Date=@PasswordUpdate,Agreement_Accepted_Date=@AgreementAccepted,Is_Locked=@IsInactive,Is_Inactive=@IsInactive,Email_Address=@EmailAddress,Phone_Number=@PhoneNumber,Full_Name=@FullName,Force_Change_Password=@ForceChangePassword,Prefferred_Language=@PrefferredLanguage" +
                        " where Id = @Id";

                    cmd.Connection = conn;


                    foreach (SecurityLoginPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Password", item.Password);
                        cmd.Parameters.AddWithValue("@Created", item.Created);
                        cmd.Parameters.AddWithValue("@PasswordUpdate", item.PasswordUpdate);
                        cmd.Parameters.AddWithValue("@AgreementAccepted", item.AgreementAccepted);
                        cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                        cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                        cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                        cmd.Parameters.AddWithValue("@FullName", item.FullName);
                        cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                        cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);


                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;

                }
                finally { conn.Close(); }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            List<SecurityLoginPoco> items = new List<SecurityLoginPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Security_Logins";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SecurityLoginPoco item = new SecurityLoginPoco();
                        item.Id = (Guid) reader["Id"];
                        item.Login = (String) reader["Login"];
                        item.Password = (String) reader["Password"];
                        item.Created = (DateTime) reader["Created_Date"];
                        item.PasswordUpdate = reader.IsDBNull(4) ? null :(DateTime) reader["Password_Update_Date"];
                        item.AgreementAccepted = reader.IsDBNull(5) ? null : (DateTime) reader["Agreement_Accepted_Date"];
                        item.IsLocked = (bool) reader["Is_Locked"];
                        item.IsInactive = (bool) reader["Is_Inactive"];
                        item.EmailAddress = (String) reader["Email_Address"];
                        item.PhoneNumber = reader.IsDBNull(9) ? null : (String) reader["Phone_Number"];
                        item.FullName = reader.IsDBNull(10) ? null : (String) reader["Full_Name"];
                        item.ForceChangePassword = (bool) reader["Force_Change_Password"];
                        item.PrefferredLanguage = reader.IsDBNull(12) ? null : (String) reader["Prefferred_Language"];
                        item.TimeStamp = (byte[]) reader["Time_Stamp"];

                        items.Add(item);
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally { conn.Close(); }

            }
            return items;
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

       
    }
}
