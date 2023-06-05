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
    public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
    {
        string cs = "Data Source=DESKTOP-S6DCAPE;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Company_Locations " +
                        "(Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)" +
                        " values (@Id,@Company,@CountryCode,@Province,@Street,@City,@PostalCode)";
                    cmd.Connection = conn;



                    foreach (CompanyLocationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
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
        public void Remove(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from Company_Locations where Id=@Id";
                    cmd.Connection = conn;

                    foreach (CompanyLocationPoco item in items)

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

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Locations " +
                        "SET Company=@Company,Country_Code=@CountryCode,State_Province_Code=@Province,Street_Address=@Street,City_Town=@City,Zip_Postal_Code=@PostalCode" +
                        " where Id = @Id";

                    cmd.Connection = conn;


                    foreach (CompanyLocationPoco item in items)

                    {
                        cmd.Parameters.AddWithValue("@Id", item.Id);
                        cmd.Parameters.AddWithValue("@Company", item.Company);
                        cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            List<CompanyLocationPoco> items = new List<CompanyLocationPoco>();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Company_Locations";
                    cmd.Connection = conn;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CompanyLocationPoco item = new CompanyLocationPoco();
                        item.Id = (Guid)reader["Id"];
                        item.Company = (Guid)reader["Company"];
                        item.CountryCode = reader["Country_Code"] != null ? reader["Country_Code"].ToString() : null;
                        item.Province = reader["State_Province_Code"] != null ? reader["State_Province_Code"].ToString() : null;
                        item.Street = reader["Street_Address"] != null ? reader["Street_Address"].ToString() : null;
                        item.City = reader["City_Town"] != null ? reader["City_Town"].ToString() : null;
                        item.PostalCode = reader["Zip_Postal_Code"] != null ? reader["Zip_Postal_Code"].ToString() : null;
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
    

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        
    }
}
