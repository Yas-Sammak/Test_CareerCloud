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
    public class ApplicantSkillRepository : IDataRepository<ApplicantSkillPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params ApplicantSkillPoco[] items)
        {
            using(SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Applicant_Skills " +
                        "(Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year)" +
                        " values (@Id,@Applicant,@Skill,@SkillLevel,@StartMonth,@StartYear,@EndMonth,@EndYear)";
                    cmd.Connection = conn;



                    foreach (ApplicantSkillPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@SkillLevel", item.SkillLevel);
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
        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Applicant_Skills where Id=@Id";
                    cmd.Connection = conn;

                    foreach (ApplicantSkillPoco item in items)

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

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Skills " +
                        "SET Applicant=@Applicant,Skill=@Skill,Skill_Level=@SkillLevel,Start_Month=@StartMonth,Start_Year=@StartYear,End_Month=@EndMonth,End_Year=@EndYear" +
                        " where Id = @Id";
                    cmd.Connection = conn;

                    foreach (ApplicantSkillPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                        cmd.Parameters.AddWithValue("@Skill", item.Skill);
                        cmd.Parameters.AddWithValue("@SkillLevel", item.SkillLevel);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            List<ApplicantSkillPoco> items = new List<ApplicantSkillPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Applicant_Skills";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ApplicantSkillPoco item = new ApplicantSkillPoco();
                        item.Id = (Guid) reader["Id"];
                        item.Applicant = (Guid)reader["Applicant"];
                        item.Skill = (String)reader["Skill"];
                        item.SkillLevel = (String)reader["Skill_Level"];
                        item.StartMonth = (byte)reader["Start_Month"];
                        item.StartYear = (int)reader["Start_Year"];
                        item.EndMonth = (byte)reader["End_Month"];
                        item.EndYear = (int)reader["End_Year"];
                        item.TimeStamp = (byte[])reader["Time_Stamp"];


                        items.Add(item);
                    }

                }
                catch (Exception ex)
                {


                }
                finally { conn.Close(); }

            }
            return items;
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
