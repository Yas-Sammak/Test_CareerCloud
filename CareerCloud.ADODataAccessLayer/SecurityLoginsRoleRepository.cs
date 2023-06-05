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
    public class SecurityLoginsRoleRepository : IDataRepository<SecurityLoginsRolePoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Security_Logins_Roles " +
                        "(Id,Login,Role)" +
                        " values (@Id,@Login,@Role)";
                    cmd.Connection = conn;



                    foreach (SecurityLoginsRolePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Role", item.Role);
                       
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

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Security_Logins_Roles where Id=@Id";
                    cmd.Connection = conn;

                    foreach (SecurityLoginsRolePoco item in items)

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

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Security_Logins_Roles " +
                        "SET Login=@Login,Role=@Role" +
                        " where Id = @Id";

                    cmd.Connection = conn;


                    foreach (SecurityLoginsRolePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@Role", item.Role);


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

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            List<SecurityLoginsRolePoco> items = new List<SecurityLoginsRolePoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Security_Logins_Roles";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SecurityLoginsRolePoco item = new SecurityLoginsRolePoco();
                        item.Id = (Guid)reader["Id"];
                        item.Login = (Guid)reader["Login"];
                        item.Role = (Guid)reader["Role"];
                        item.TimeStamp = (byte[])reader["Time_Stamp"];
                        


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

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
