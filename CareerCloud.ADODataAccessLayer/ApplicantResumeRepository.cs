using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : IDataRepository<ApplicantResumePoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Applicant_Resumes " +
                        "(Id,Applicant,Resume,Last_Updated)" +
                        " VALUES (@Id,@Applicant,@Resume,@LastUpdated)";
                    cmd.Connection = conn;

                    foreach (ApplicantResumePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Resume", item.Resume);
                        cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);
                        
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
        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Applicant_Resumes where Id=@Id";
                    cmd.Connection = conn;

                    foreach (ApplicantResumePoco item in items)

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

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Resumes " +
                        "SET Applicant=@Applicant, Resume=@Resume, Last_Updated=@LastUpdated" +
                        " where Id = @Id";
                    cmd.Connection = conn;

                    foreach (ApplicantResumePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Resume", item.Resume);
                        cmd.Parameters.AddWithValue("@LastUpdated", item.LastUpdated);
                        

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {


                }
                finally { conn.Close(); }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            List<ApplicantResumePoco> items = new List<ApplicantResumePoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Applicant_Resumes";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ApplicantResumePoco item = new ApplicantResumePoco();
                        item.Id = (Guid)reader["Id"];
                        item.Applicant = (Guid)reader["Applicant"];
                        item.Resume = (String)reader["Resume"];
                        item.LastUpdated = reader.IsDBNull(3) ? null : (DateTime)reader["Last_Updated"];


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

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
