using Microsoft.AspNetCore.Mvc.Rendering;
using Npgsql;
using ReceVitas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReceVitas.Clases
{
    public class DaoMedicamentos
    {
        public List<Medicamentos> List_medicamentos()
        {
            List<Medicamentos> return_medicamentos = new List<Medicamentos>();
            string connString = "Server=192.168.0.190;Port=5432;Database=recetas;User Id=postgres;Password=aliciad2102;";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = connString; // ConfigurationManager.ConnectionStrings["constr"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand
                {
                    Connection = connection,
                    CommandText = "Select * FROM medicamentos",
                    CommandType = CommandType.Text
                };
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        Medicamentos medic = new Medicamentos();
                        medic.id_medicamento = dr.GetInt32(0);
                        medic.atc = dr.GetString(1);
                        medic.generico = dr.GetString(2);
                        medic.nombre = dr.GetString(3);
                        medic.presentacion = dr.GetString(4);
                        medic.pvp = dr.GetDouble(5);
                        medic.acargoos = dr.GetDouble(6);
                        medic.acargoafil = dr.GetDouble(7);
                        medic.laboratorio = dr.GetString(8);
                        medic.registro = dr.GetDouble(9);
                        medic.pr = dr.GetDouble(10);
                        medic.grupoter = dr.GetDouble(11);
                        if (!dr.IsDBNull(12)) { medic.obser = dr.GetString(12); }
                        return_medicamentos.Add(medic);
                    }
                }
                connection.Close();
                return return_medicamentos;
            }
        }

        public List<SelectListItem> GetMedicamentos()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string connString = "Server=192.168.0.190;Port=5432;Database=recetas;User Id=postgres;Password=aliciad2102;";
            using (NpgsqlConnection connection = new NpgsqlConnection())
            {
                connection.ConnectionString = connString; // ConfigurationManager.ConnectionStrings["constr"].ToString();
                connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand
                {
                    Connection = connection,
                    CommandText = "Select * FROM medicamentos",
                    CommandType = CommandType.Text
                };
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        items.Add(new SelectListItem
                        {
                            Text = dr.GetString(1),
                            Value = dr.GetInt32(0).ToString()
                        });
                        
                    }
                }
                connection.Close();
            }
            return items;
        }

        public Boolean Insert_Medicamentos(Medicamentos Medic)
        {
            Boolean retorno = false;
            try
            {
                string connString = "Server=192.168.0.190;Port=5432;Database=recetas;User Id=postgres;Password=aliciad2102;";
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.ConnectionString = connString; // ConfigurationManager.ConnectionStrings["constr"].ToString();
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = connection,
                        CommandText = "INSERT INTO Medicamentos(atc,generico,nombre,presentacion,pvp,acargoos,acargoafil,laboratorio,registro," +
                        "pr,grupoter,obser) values(@Atc,@Generico,@Nombre,@Presentacion,@Pvp,@Acargoos,@Acargoafil," +
                        "@Laboratorio,@Registro,@Pr,@Grupoter,@Obser)",
                        CommandType = CommandType.Text
                    };
                    //cmd.Parameters.Add(new NpgsqlParameter("@Id_Padron", padron.Id_Padron));
                    cmd.Parameters.Add(new NpgsqlParameter("@Atc", Medic.atc));
                    cmd.Parameters.Add(new NpgsqlParameter("@Generico", Medic.generico));
                    cmd.Parameters.Add(new NpgsqlParameter("@Nombre", Medic.nombre));
                    cmd.Parameters.Add(new NpgsqlParameter("@Presentacion", Medic.presentacion));
                    cmd.Parameters.Add(new NpgsqlParameter("@Pvp", Medic.pvp));
                    cmd.Parameters.Add(new NpgsqlParameter("@Acargoos", Medic.acargoos));
                    cmd.Parameters.Add(new NpgsqlParameter("@Acargoafil", Medic.acargoafil));
                    cmd.Parameters.Add(new NpgsqlParameter("@Laboratorio", Medic.laboratorio));
                    cmd.Parameters.Add(new NpgsqlParameter("@Registro", Medic.registro));
                    cmd.Parameters.Add(new NpgsqlParameter("@Pr", Medic.pr));
                    cmd.Parameters.Add(new NpgsqlParameter("@Grupoter", Medic.grupoter));
                    cmd.Parameters.Add(new NpgsqlParameter("@Obser", Medic.obser));
                    //cmd.Parameters.Add(new NpgsqlParameter("@Enfermedades", padron.enfermedades));
                    cmd.ExecuteNonQuery();
                    retorno = true;
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // something went wrong, and you wanna know why
                retorno = false;
                throw;
            }
            return retorno;
        }
    }
}
