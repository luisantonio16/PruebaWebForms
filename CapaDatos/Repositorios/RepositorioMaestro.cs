using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class RepositorioMaestro:ConexionDB
    {
        protected List<SqlParameter> parameters = new List<SqlParameter>();

        public int AgregarPersona(Persona persona)
        {
            int resultado = 0;

            try
            {


                using (var conection = GetConnection())
                {
                    conection.Open();
                    using (var comand = new SqlCommand())
                    {
                        comand.Connection = conection;
                        comand.CommandText = "SP_Agregar_Persona";
                        comand.Parameters.AddWithValue("@nombre", persona.Nombre);
                        comand.Parameters.AddWithValue("@apellido", persona.Apellido);
                        comand.Parameters.AddWithValue("@edad", persona.Edad);
                        //comand.Parameters.Add(new SqlParameter ("@nombre", persona.Nombre));
                        // comand.Parameters.Add(new SqlParameter("@apellido", persona.Apellido));
                        // comand.Parameters.Add(new SqlParameter("@edad", persona.Edad));
                        comand.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter item in parameters)
                        {
                            comand.Parameters.Add(item);

                        }
                        resultado = comand.ExecuteNonQuery();


                    }

                }


            }
            catch (Exception ex)
            {


            }

            return resultado;

        }
        public int ActualizarPersona(Persona persona)
        {
            int resultado = 0;

            try
            {


                using (var conection = GetConnection())
                {
                    conection.Open();
                    using (var comand = new SqlCommand())
                    {
                        comand.Connection = conection;
                        comand.CommandText = "SP_Actualizar_Persona";
                        comand.Parameters.AddWithValue("@id", persona.id);
                        comand.Parameters.AddWithValue("@nombre", persona.Nombre);
                        comand.Parameters.AddWithValue("@apellido", persona.Apellido);
                        comand.Parameters.AddWithValue("@edad", persona.Edad);
                        comand.CommandType = CommandType.StoredProcedure;
                        foreach (SqlParameter item in parameters)
                        {
                            comand.Parameters.Add(item);

                        }
                        resultado = comand.ExecuteNonQuery();


                    }

                }


            }
            catch (Exception ex)
            {


            }

            return resultado;

        }
        public int eliminarPersona(int id)
        {
            int resultado = 0;

            try
            {


                using (var conection = GetConnection())
                {
                    conection.Open();
                    using (var comand = new SqlCommand())
                    {
                        comand.Connection = conection;
                        comand.CommandText = "delete from persona where id=@id";
                        comand.Parameters.AddWithValue("@id", id);
                        comand.CommandType = CommandType.Text;
                        foreach (SqlParameter item in parameters)
                        {
                            comand.Parameters.Add(item);

                        }
                        resultado = comand.ExecuteNonQuery();


                    }

                }


            }
            catch (Exception ex)
            {


            }

            return resultado;

        }

        public DataTable buscar(string codigo)
        {
            using (var conection = GetConnection())
            {
                conection.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = conection;
                    comand.CommandText = "select * from persona WHERE id=@id";
                    comand.Parameters.AddWithValue("@id", codigo);
                    comand.CommandType = CommandType.Text;
                    SqlDataReader reader = comand.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }

                }
            }

        }
        public IEnumerable<Persona> ObtenerLista()
        {
            var ListaPersonas = new List<Persona>();
            using (var conection = GetConnection())
            {
                conection.Open();
                using (var comand = new SqlCommand())
                {
                    comand.Connection = conection;
                    comand.CommandText = "select * from persona";
                    comand.CommandType = CommandType.Text;
                    SqlDataReader reader = comand.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        table.Load(reader);


                        foreach (DataRow item in table.Rows)
                        {
                            ListaPersonas.Add(new Persona
                            {
                                id = Convert.ToInt32(item[0].ToString()),
                                Nombre = item[1].ToString(),
                                Apellido = item[2].ToString(),
                                Edad = Convert.ToInt32(item[3].ToString()),

                            });


                        }

                    }

                }

            }
            return ListaPersonas;

        }
    }
}
