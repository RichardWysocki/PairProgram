using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication.Library.Models;

namespace WebApplication.Library.DataAccess
{
    public class KidDataAccess
    {
        public bool Insert(Kid kid)
        {
            bool insertSuccessful;

            if (kid == null || !kid.IsValidNew())
                throw new ArgumentException();

            var cmd = SqlCommand("Kid_Insert");
            // Start a local transaction.
            var transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Kid_Insert");
            cmd.Transaction = transaction;

            try
            {
                cmd.Parameters.Add("@Name", SqlDbType.Text, 50);
                cmd.Parameters.Add("@Email", SqlDbType.Text, 150);
                cmd.Parameters["@Name"].Value = kid.Name;
                cmd.Parameters["@Email"].Value = kid.Email;

                int returnValue =  cmd.ExecuteNonQuery();
                transaction.Commit();
                if (returnValue < 0)
                {
                    throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
                }
                else
                {
                    insertSuccessful = true;
                }
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
                insertSuccessful = false;
            }
            return insertSuccessful;

        }

        public bool Update(Kid updateKid)
        {
            bool updateSuccessful;

            if (updateKid == null || !updateKid.IsValidUpdate())
                throw new ArgumentException();

            var cmd = SqlCommand("Kid_Update");
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "XKid_Update");
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Add("@KidID", SqlDbType.Int);
                cmd.Parameters.Add("@Name", SqlDbType.Text, 50);
                cmd.Parameters.Add("@Email", SqlDbType.Text, 150);
                cmd.Parameters["@KidID"].Value = updateKid.KidID;
                cmd.Parameters["@Name"].Value = updateKid.Name;
                cmd.Parameters["@Email"].Value = updateKid.Email;

                int returnValue = cmd.ExecuteNonQuery();
                transaction.Commit();

                if (returnValue < 0)
                {
                    throw new Exception("Error Text Added to the Database: " + returnValue.ToString());

                }
                else
                {
                    updateSuccessful = true;
                }
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
                updateSuccessful = false;
            }
            return updateSuccessful;
        }

        public bool Delete(int deleteId)
        {
            if (deleteId == 0)
                throw new ArgumentException();

            bool returnvalue;

            var cmd = SqlCommand("Kid_Delete");

            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cmd.Connection.BeginTransaction(IsolationLevel.ReadCommitted, "Kid_Delete");
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Add("@KidID", SqlDbType.Int, 50);
                cmd.Parameters["@KidID"].Value = deleteId;

                int returnValue = cmd.ExecuteNonQuery();
                transaction.Commit();

                if (returnValue < 1)
                {
                    throw new Exception("Error Text Added to the Database: " + returnValue.ToString());
                }
                returnvalue = true;
                //System.Web.HttpContext.Current.Cache.Remove("PLUList");
            }
            catch (Exception e)
            {
                returnvalue = false;
                try
                {
                    transaction.Rollback();
                }
                catch (SqlException ex)
                {
                    if (transaction.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }

            return returnvalue;
        }

        private static SqlCommand SqlCommand(string storedProcedure)
        {
            SqlCommand cmd = ConfigSettings.DBCmd;
            cmd.Parameters.Clear();
            cmd.CommandText = storedProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }
    }
}