using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Windows;

namespace DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        public SqlConnection conn { get; set; }

        public DataAccessService()
        {
            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-LKVJU83\\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }
        public List<Person> GetPerson(int id = 0)
        {
            try
            {
                conn.Open();

                return conn.Query<Person>($"SELECT [BusinessEntityID],[Title],[FirstName],[LastName],PersonType,Suffix FROM [Person].[Person] where [BusinessEntityID] = {id} or {id} = 0").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }

            return null;
        }

        public List<Person> AllPerson()
        {
            try

            {
                conn.Open();

                return conn.Query<Person>("SELECT [BusinessEntityID],[Title],[FirstName],[LastName],Suffix,PersonType FROM [Person].[Person] order by 1 desc").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new YourCustomException("Put your error message here.", e);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }

            return null;
        }

        //to get suffix for dropdown
        public List<Person> suffixPerson()
        {
            try

            {
                conn.Open();

                return conn.Query<Person>("SELECT DISTINCT [Suffix] FROM [Person].[Person] WHERE [Suffix] is not null").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new YourCustomException("Put your error message here.", e);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }

            return null;
        }

        
        //person type for drop down
        public IEnumerable<DropDownItem> PersonType()
        {
            try

            {
                conn.Open();

                return conn.Query<DropDownItem>("SELECT DISTINCT Id=PersonType, Text=PersonType FROM [Person].[Person] WHERE PersonType is not null");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw new YourCustomException("Put your error message here.", e);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }

            return null;
        }

        public void DeletePerson(int id)
        {
            try
            {
                conn.Open();

                conn.Query<Person>($"delete FROM [Person].[Person] where BusinessEntityID = {id}").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }
        }

        //code for login
        public void LoginUser(int id)
        {
            try
            {
                conn.Open();

                conn.Query<Person>($"delete FROM [Person].[Person] where BusinessEntityID = {id}").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }
        }

        public void InsertPerson(Person person)
        {
            try
            {
                conn.Open();


                var p = new DynamicParameters();
                p.Add("@BusinessEntityID", dbType: System.Data.DbType.Int32, value: person.BusinessEntityID);
                p.Add("@Title", dbType: System.Data.DbType.String, value: person.Title);
                p.Add("@FirstName", dbType: System.Data.DbType.String, value: person.FirstName);
                p.Add("@LastName", dbType: System.Data.DbType.String, value: person.LastName);

                conn.Execute("person.insertPerson", p, commandType: CommandType.StoredProcedure);



                // return conn.Query<int>("SELECT [BusinessEntityID],[Title],[FirstName],[LastName] FROM[Person].[Person]").FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Handle exception, perhaps log it and do the needful
            }
            finally
            {
                //Connection should always be closed here so that it will close always
                conn.Close();
            }

            // return 0;
        }
    }
}