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
    public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Company_Jobs " +
                        "(Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden)" +
                        " values (@Id,@Company,@ProfileCreated,@IsInactive,@IsCompanyHidden)";
                    cmd.Connection = conn;



                    foreach (CompanyJobPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@ProfileCreated", item.ProfileCreated);
                        cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@IsCompanyHidden", item.IsCompanyHidden);


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
        public void Remove(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Company_Jobs where Id=@Id";
                    cmd.Connection = conn;

                    foreach (CompanyJobPoco item in items)

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

        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Jobs " +
                        "SET Company=@Company,Profile_Created=@ProfileCreated,Is_Inactive=@IsInactive,Is_Company_Hidden=@IsCompanyHidden" +
                        " where Id = @Id";

                    cmd.Connection = conn;

                                
                    foreach (CompanyJobPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@ProfileCreated", item.ProfileCreated);
                        cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                        cmd.Parameters.AddWithValue("@IsCompanyHidden", item.IsCompanyHidden);


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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            List<CompanyJobPoco> items = new List<CompanyJobPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Company_Jobs";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyJobPoco item = new CompanyJobPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Company = (Guid)reader["Company"];
                        item.ProfileCreated = (DateTime)reader["Profile_Created"];
                        item.IsInactive = (bool)reader["Is_Inactive"];
                        item.IsCompanyHidden = (bool)reader["Is_Company_Hidden"];
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

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
