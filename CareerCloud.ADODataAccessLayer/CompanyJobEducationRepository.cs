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
    public class CompanyJobEducationRepository : IDataRepository<CompanyJobEducationPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Company_Job_Educations " +
                        "(Id,Job,Major,Importance)" +
                        " values (@Id,@Job,@Major,@Importance)";
                    cmd.Connection = conn;



                    foreach (CompanyJobEducationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Importance", item.Importance);


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
        public void Remove(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Company_Job_Educations where Id=@Id";
                    cmd.Connection = conn;

                    foreach (CompanyJobEducationPoco item in items)

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

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Job_Educations " +
                        "SET Job=@Job,Major=@Major,Importance=@Importance" +
                        " where Id = @Id";
                    cmd.Connection = conn;


             
                    foreach (CompanyJobEducationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Job", item.Job);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@Importance", item.Importance);


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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            List<CompanyJobEducationPoco> items = new List<CompanyJobEducationPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Company_Job_Educations";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyJobEducationPoco item = new CompanyJobEducationPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Job = (Guid)reader["Job"];
                        item.Major = (String)reader["Major"];
                        item.Importance = (short)reader["Importance"];
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

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }
    }

       
    

}
