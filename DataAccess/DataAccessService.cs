using Dapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        public SqlConnection conn { get; set; }


        //Connection string
        public DataAccessService()
        {
            try
            {
                conn = new SqlConnection("Data Source=DESKTOP-LKVJU83\\SQLEXPRESS;Initial " +
                    "Catalog=AdventureWorks2017;Integrated Security=True;Connect Timeout=30;" +
                    "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        //get the person details based on ID
        public List<Person> GetPerson(int id = 0)
        {
            try
            {
                conn.Open();

                return conn.Query<Person>($"SELECT [BusinessEntityID],[Title],[FirstName],[LastName],PersonType,Suffix " +
                    $"FROM [Person].[Person] " +
                    $"WHERE [BusinessEntityID] = {id} or {id} = 0").ToList();
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

        //get the list of persons
        public List<Person> AllPerson()
        {
            try

            {
                conn.Open();

                return conn.Query<Person>("SELECT [BusinessEntityID],[Title],[FirstName],[LastName],Suffix,PersonType " +
                    "FROM [Person].[Person] " +
                    "ORDER BY 1 DESC").ToList();
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

                return conn.Query<Person>("SELECT DISTINCT [Suffix] " +
                    "FROM [Person].[Person] " +
                    "WHERE [Suffix] is not null").ToList();
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

                return conn.Query<DropDownItem>("SELECT DISTINCT Id=PersonType, Text=PersonType " +
                    "FROM [Person].[Person] " +
                    "WHERE PersonType is not null");
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

        //delete the person from the database
        public void DeletePerson(int id)
        {
            try
            {
                conn.Open();

                conn.Query<Person>($"DELETE " +
                    $"FROM [Person].[Person] " +
                    $"WHERE BusinessEntityID = {id}").ToList();
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
        public List<User> LoginUser(User user)
        {
            //string UserName = "";
            try
            {
                conn.Open();

                return conn.Query<User>($"SELECT FirstName  + ' ' + LastName AS UserName " +
                    $"FROM dbo.PersonLogin " +
                    $"WHERE EmailID = '{user.Email}' and Password = '{user.Password}'").ToList();
                //return data.FirstOrDefault();
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
                // return conn.Query<int>("SELECT [BusinessEntityID],[Title],[FirstName],[LastName] FROM[Person]. " +
                //"[Person]").FirstOrDefault();
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

        //Sign up new user
        public void InsertUser(User user)
        {
            try
            {
                conn.Open();
                var u = new DynamicParameters();
                u.Add("@FirstName", dbType: System.Data.DbType.String, value: user.FirstName);
                u.Add("@LastName", dbType: System.Data.DbType.String, value: user.LastName);
                u.Add("@EmailID", dbType: System.Data.DbType.String, value: user.Email);
                u.Add("@Password", dbType: System.Data.DbType.String, value: user.Password);

                conn.Execute("person.insertUser", u, commandType: CommandType.StoredProcedure);
                // return conn.Query<int>("SELECT [BusinessEntityID],[Title],[FirstName],[LastName] FROM[Person]. " +
                //"[Person]").FirstOrDefault();
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