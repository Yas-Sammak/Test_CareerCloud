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
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Applicant_Profiles " +
                        "(Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)" +
                        " values (@Id,@Login,@CurrentSalary,@CurrentRate,@Currency,@Country,@Province,@Street,@City,@PostalCode)";
                    
                    cmd.Connection = conn;



                    foreach (ApplicantProfilePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);
                        cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                        cmd.Parameters.AddWithValue("@Currency", item.Currency);
                        cmd.Parameters.AddWithValue("@Country", item.Country);
                        cmd.Parameters.AddWithValue("@Province", item.Province);
                        cmd.Parameters.AddWithValue("@Street", item.Street);
                        cmd.Parameters.AddWithValue("@City", item.City);
                        cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);
                       

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
        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Applicant_Profiles where Id=@Id";
                    cmd.Connection = conn;

                    foreach (ApplicantProfilePoco item in items)

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
        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Profiles " +
                        "SET Login=@Login,Current_Salary=@CurrentSalary,Current_Rate=@CurrentRate,Currency=@Currency,Country_Code=@Country,State_Province_Code=@Province,Street_Address=@Street,City_Town=@City,Zip_Postal_Code=@PostalCode" +
                        " where Id = @Id";
                    cmd.Connection = conn;

                   
                    foreach (ApplicantProfilePoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Login", item.Login);
                        cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);
                        cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                        cmd.Parameters.AddWithValue("@Currency", item.Currency);
                        cmd.Parameters.AddWithValue("@Country", item.Country);
                        cmd.Parameters.AddWithValue("@Province", item.Province);
                        cmd.Parameters.AddWithValue("@Street", item.Street);
                        cmd.Parameters.AddWithValue("@City", item.City);
                        cmd.Parameters.AddWithValue("@PostalCode", item.PostalCode);


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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            List<ApplicantProfilePoco> items = new List<ApplicantProfilePoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Applicant_Profiles";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ApplicantProfilePoco item = new ApplicantProfilePoco();
                        item.Id = (Guid)reader["Id"];
                        item.Login = (Guid)reader["Login"];
                        item.CurrentSalary = (decimal)reader["Current_Salary"];
                        item.CurrentRate = (decimal)reader["Current_Rate"];
                        item.Currency = (String)reader["Currency"];
                        item.Country = (String)reader["Country_Code"];
                        item.Province = (String)reader["State_Province_Code"];
                        item.Street = (String)reader["Street_Address"];
                        item.City = (String)reader["City_Town"];
                        item.PostalCode = (String)reader["Zip_Postal_Code"];
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

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
