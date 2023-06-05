using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text; 
                    cmd.CommandText = "INSERT INTO Applicant_Educations " +
                        "(Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent)"+
                        " VALUES (@Id,@Applicant,@Major,@CertificateDiploma,@StartDate,@CompletionDate,@CompletionPercent)";
                    cmd.Connection = conn;

                    foreach (ApplicantEducationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                        cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                        cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                        cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                        
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
        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Applicant_Educations where Id=@Id";
                    cmd.Connection = conn;

                    foreach (ApplicantEducationPoco item in items)

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
        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Educations " +
                        "SET Applicant=@Applicant,Major=@Major,Certificate_Diploma=@CertificateDiploma,Start_Date=@StartDate,Completion_Date=@CompletionDate,Completion_Percent=@CompletionPercent" +
                        " where Id = @Id";
                    cmd.Connection = conn;

                    
                    foreach (ApplicantEducationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Major", item.Major);
                        cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                        cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                        cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                        cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);

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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            List<ApplicantEducationPoco> items = new List<ApplicantEducationPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Applicant_Educations";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ApplicantEducationPoco item = new ApplicantEducationPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Applicant = (Guid)reader["Applicant"];
                        item.Major = (String)reader["Major"];
                        item.CertificateDiploma = (String)reader["Certificate_Diploma"];
                        item.StartDate = (DateTime)reader["Start_Date"];
                        item.CompletionDate = (DateTime)reader["Completion_Date"];
                        item.CompletionPercent = (byte)reader["Completion_Percent"];
                        item.TimeStamp = (byte[])reader["Time_Stamp"];

                        items.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                finally { conn.Close(); }

            }
            return items;
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        

       
    }
}
