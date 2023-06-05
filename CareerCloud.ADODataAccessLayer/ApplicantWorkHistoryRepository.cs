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
    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Applicant_Work_History " +
                        "(Id,Applicant,Company_Name,Country_Code,Location,Job_Title,Job_Description,Start_Month,Start_Year,End_Month,End_Year)" +
                        " values (@Id,@Applicant,@CompanyName,@CountryCode,@Location,@JobTitle,@JobDescription,@StartMonth,@StartYear,@EndMonth,@EndYear)";
                    cmd.Connection = conn;



                    foreach (ApplicantWorkHistoryPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                        cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                        cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                        cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                        cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                        cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                        cmd.Parameters.AddWithValue("@EndYear", item.EndYear);
                        



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

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Applicant_Work_History where Id=@Id";
                    cmd.Connection = conn;

                    foreach (ApplicantWorkHistoryPoco item in items)

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
        
        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Work_History " +
                        "SET Applicant=@Applicant,Company_Name=@CompanyName,Country_Code=@CountryCode,Location=@Location,Job_Title=@JobTitle,Job_Description=@JobDescription,Start_Month=@StartMonth,Start_Year=@StartYear,End_Month=@EndMonth,End_Year=@EndYear" +
                        " where Id = @Id";
                    cmd.Connection = conn;

                    foreach (ApplicantWorkHistoryPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                        cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                        cmd.Parameters.AddWithValue("@Location", item.Location);
                        cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                        cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                        cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                        cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                        cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                        cmd.Parameters.AddWithValue("@EndYear", item.EndYear);
                        


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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            List<ApplicantWorkHistoryPoco> items = new List<ApplicantWorkHistoryPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Applicant_Work_History";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ApplicantWorkHistoryPoco item = new ApplicantWorkHistoryPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Applicant = (Guid)reader["Applicant"];
                        item.CompanyName = (String)reader["Company_Name"];
                        item.CountryCode = (String)reader["Country_Code"];
                        item.Location = (String)reader["Location"];
                        item.JobTitle = (String)reader["Job_Title"];
                        item.JobDescription = (String)reader["Job_Description"];
                        item.StartMonth = (short)reader["Start_Month"];
                        item.StartYear = (int)reader["Start_Year"];
                        item.EndMonth = (short)reader["End_Month"];
                        item.EndYear = (int)reader["End_Year"];
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


        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }


    }
}
