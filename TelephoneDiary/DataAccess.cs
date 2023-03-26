using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TelephoneDiary
{
    public class DataAccess
    {
        public List<Person> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.conn("Phone")))
            {
                return connection.Query<Person>("SELECT * FROM Mobiles").ToList();
            }
        }

        public void InsertPeople(string first, string last, string mobile, string email, string category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.conn("Phone")))
            {
               connection.Query<Person>("INSERT INTO Mobiles (First, Last, Mobile, Email, Category) VALUES ('"+first+"','" + last + "','"+ mobile + "','"+ email +"','"+ category + "')");
            }
        }

        public void DeletePeople(string mobile)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.conn("Phone")))
            {
                connection.Query<Person>("DELETE FROM Mobiles WHERE (Mobile = '" + mobile + "')");
            }
        }

        public void UpdatePeople(string first, string last, string mobile, string email, string category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.conn("Phone")))
            {
                connection.Query<Person>("UPDATE Mobiles SET First='"+ first +"', Last='" + last +"', Mobile ='"+ mobile +"' , Email= '" + email+ "', Category ='" +category+ "' WHERE (Mobile = '" + mobile +"')");
            }
        }

        public List<Person> SearchPeople(string mobile, string last)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.conn("Phone")))
            {
                return connection.Query<Person>("SELECT * FROM Mobiles WHERE (Mobile LIKE '%"+ mobile + "%') or (Last LIKE '%"+ last+ "%')").ToList();
            }
        }
    }
}
