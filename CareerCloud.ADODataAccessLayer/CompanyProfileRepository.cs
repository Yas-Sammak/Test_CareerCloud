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
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Company_Profiles " +
                        "(Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,Company_Logo)" +
                        " values (@Id,@RegistrationDate,@CompanyWebsite,@ContactPhone,@ContactName,@CompanyLogo)";
                    cmd.Connection = conn;



                    foreach (CompanyProfilePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                        cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                        cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                        cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                        cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);
                     


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
        public void Remove(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Company_Profiles where Id=@Id";
                    cmd.Connection = conn;

                    foreach (CompanyProfilePoco item in items)

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

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Profiles " +
                        "SET Registration_Date=@RegistrationDate,Company_Website=@CompanyWebsite,Contact_Phone=@ContactPhone,Contact_Name=@ContactName,Company_Logo=@CompanyLogo" +
                        " where Id = @Id";

                    cmd.Connection = conn;


                    foreach (CompanyProfilePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                        cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                        cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                        cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                        cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);


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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            List<CompanyProfilePoco> items = new List<CompanyProfilePoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Company_Profiles";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyProfilePoco item = new CompanyProfilePoco();
                        item.Id = (Guid) reader["Id"];
                        item.RegistrationDate = (DateTime) reader["Registration_Date"];
                        item.CompanyWebsite = reader.IsDBNull(2) ? null : (String)reader["Company_Website"];
                        item.ContactPhone = (String) reader["Contact_Phone"];
                        item.ContactName = reader.IsDBNull(4) ? null : (String)reader["Contact_Name"];
                        item.CompanyLogo = reader.IsDBNull(5) ? null : (byte[])reader["Company_Logo"];
                        item.TimeStamp = (Byte[]) reader["Time_Stamp"];

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

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

       
    }
}
