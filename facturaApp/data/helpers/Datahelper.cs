using facturaApp.data.helpers;
using facturaApp.domain;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace facturaApp.data
{
    public class Datahelper
    {
        private static Datahelper? _instance;
        private SqlConnection _connection;

        private Datahelper()
        {
            _connection = new SqlConnection(@"Data Source=CARMEN\SQLEXPRESS;Initial Catalog=ACT_factura;Integrated Security=True;Encrypt=False");
        }
        public static Datahelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Datahelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp, List<parameters>? param = null)
        {
            DataTable dt = new DataTable();
            try
            {

                 _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                if (param != null)
                {
                    foreach (parameters p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
               
                throw;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return dt;
        }
        public bool ExecuteSPT(string sp, List<parameters>? param = null)
        {
            bool result;
            try
            {

                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (parameters p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }
                int affectedRows = cmd.ExecuteNonQuery();

                result = affectedRows > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                result = false;
            }
            finally
            {

                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return result;
        }

        public bool executeTransaction(Bill b)
        {
            bool success;

            _connection.Open();
            using (SqlTransaction t = _connection.BeginTransaction())
            {
                try
                {
                   
                    using (SqlCommand cmd = new SqlCommand("sp_insertar_Maestro", _connection, t))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fecha", b.date);
                        cmd.Parameters.AddWithValue("@tipo", b.Type);   
                        cmd.Parameters.AddWithValue("@cliente", b.client);
                        int nroFactura;
                        nroFactura = Convert.ToInt32(cmd.ExecuteScalar());



                        foreach (billDetails bd in b.details)
                        {
                            using (SqlCommand db = new SqlCommand("sp_insertar_Detalle", _connection, t))
                            {
                                db.CommandType = CommandType.StoredProcedure;
                                
                                db.Parameters.AddWithValue("@articulo", bd.id);
                                db.Parameters.AddWithValue("@cantidad", bd.count);
                                db.Parameters.AddWithValue("@nroFactura",nroFactura);
                                db.Parameters.AddWithValue("@monto", bd.price);

                                int affectedRowsD = db.ExecuteNonQuery();

                                if (affectedRowsD <= 0)
                                {
                                    t.Rollback();
                                    return false;
                                }
                            }
                            

                        }

                        t.Commit();
                        success = true;
                    }

                   
                }
                catch (SqlException ex)
                {
                    t.Rollback();
                    Console.WriteLine("Error SQL: " + ex.Message);
                    return false;
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }
            }
            return success;
        }

    }
}
