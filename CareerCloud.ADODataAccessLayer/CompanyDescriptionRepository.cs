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
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Company_Descriptions " +
                        "(Id,Company,LanguageID,Company_Name,Company_Description)" +
                        " values (@Id,@Company,@LanguageId,@CompanyName,@CompanyDescription)";
                    cmd.Connection = conn;



                    foreach (CompanyDescriptionPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@LanguageId", item.LanguageId);
                        cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyDescription", item.CompanyDescription);
                       
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
        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Company_Descriptions where Id=@Id";
                    cmd.Connection = conn;

                    foreach (CompanyDescriptionPoco item in items)

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

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Descriptions " +
                        "SET Company=@Company,LanguageID=@LanguageId,Company_Name=@CompanyName,Company_Description=@CompanyDescription" +
                        " where Id = @Id";
                    cmd.Connection = conn;


                    foreach (CompanyDescriptionPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@LanguageId", item.LanguageId);
                        cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyDescription", item.CompanyDescription);

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

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            List<CompanyDescriptionPoco> items = new List<CompanyDescriptionPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Company_Descriptions";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyDescriptionPoco item = new CompanyDescriptionPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Company = (Guid)reader["Company"];
                        item.LanguageId = (String)reader["LanguageID"];
                        item.CompanyName = (String)reader["Company_Name"];
                        item.CompanyDescription = (String)reader["Company_Description"];
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

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
