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
    public class DaoPadron
    {
        public List<SelectListItem> GetPadron()
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
                    CommandText = "Select numero,nombre FROM Padron",
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

        public Boolean Insert_Padron(Padron padron)
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
                        CommandText = "INSERT INTO padron(plan,categoria,numero,orden,tipo_doc,num_doc,nombre,sexo,ecivil," +
                        "f_nacimiento,nacionalidad,parentesco,vive_calle,vive_numero,vive_piso,vive_depto,vive_cod_postal,vive_localidad_texto," +
                        "vive_localidad,vive_partido,vive_provincia,telefono,movil,email,f_ingreso,prepaga_anterior,f_egreso,prepaga_proxima," +
                        "volveria,motivo_baja_miembro,motivo_baja_miembro_agrupado,cobrador,zona,f_alta_grupo,f_antiguedad1,promotor,tipo_grupo," +
                        "presento,f_baja,motivo_baja_grupo,motivo_baja_agrupado_grupo,paciente_cronico) values(@Plan,@Categoria,@Numero,@Orden,@Tipo_doc,@Num_doc,@Nombre," +
                        "@Sexo,@Ecivil,@F_nacimiento,@Nacionalidad,@Parentesco,@Vive_calle,@Vive_numero,@Vive_piso,@Vive_depto,@Vive_cod_postal,@Vive_localidad_texto," +
                        "@Vive_localidad,@Vive_partido,@Vive_provincia,@Telefono,@Movil,@Email,@F_ingreso,@Prepaga_anterior,@F_egreso,@Prepaga_proxima,@Volveria," +
                        "@Motivo_baja_miembro,@Motivo_baja_miembro_agrupado,@Cobrador,@Zona,@F_alta_grupo,@F_antiguedad1,@Promotor,@Tipo_grupo,@Presento,@F_baja," +
                        "@Motivo_baja_grupo,@Motivo_baja_agrupado_grupo,@Paciente_Cronico)",
                        CommandType = CommandType.Text
                    };
                    //cmd.Parameters.Add(new NpgsqlParameter("@Id_Padron", padron.Id_Padron));
                    cmd.Parameters.Add(new NpgsqlParameter("@Plan", padron.plan));
                    cmd.Parameters.Add(new NpgsqlParameter("@Categoria", padron.categoria));
                    cmd.Parameters.Add(new NpgsqlParameter("@Numero", padron.numero));
                    cmd.Parameters.Add(new NpgsqlParameter("@Orden", padron.orden));
                    cmd.Parameters.Add(new NpgsqlParameter("@Tipo_doc", padron.tipo_doc));
                    cmd.Parameters.Add(new NpgsqlParameter("@Num_doc", padron.num_doc));
                    cmd.Parameters.Add(new NpgsqlParameter("@Nombre", padron.nombre));
                    cmd.Parameters.Add(new NpgsqlParameter("@Sexo", padron.sexo));
                    cmd.Parameters.Add(new NpgsqlParameter("@Ecivil", padron.ecivil));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_nacimiento", padron.f_nacimiento));
                    cmd.Parameters.Add(new NpgsqlParameter("@Nacionalidad", padron.nacionalidad));
                    cmd.Parameters.Add(new NpgsqlParameter("@Parentesco", padron.parentesco));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_calle", padron.vive_calle));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_numero", padron.vive_numero));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_piso", padron.vive_piso));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_depto", padron.vive_depto));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_cod_postal", padron.vive_cod_postal));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_localidad_texto", padron.vive_localidad_texto));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_localidad", padron.vive_localidad));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_partido", padron.vive_partido));
                    cmd.Parameters.Add(new NpgsqlParameter("@Vive_provincia", padron.vive_provincia));
                    cmd.Parameters.Add(new NpgsqlParameter("@Telefono", padron.telefono));
                    cmd.Parameters.Add(new NpgsqlParameter("@Movil", padron.movil));
                    cmd.Parameters.Add(new NpgsqlParameter("@Email", padron.email));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_ingreso", padron.f_ingreso));
                    cmd.Parameters.Add(new NpgsqlParameter("@Prepaga_anterior", padron.prepaga_anterior));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_egreso", padron.f_egreso));
                    cmd.Parameters.Add(new NpgsqlParameter("@Prepaga_proxima", padron.prepaga_proxima));
                    cmd.Parameters.Add(new NpgsqlParameter("@Volveria", padron.volveria));
                    cmd.Parameters.Add(new NpgsqlParameter("@Motivo_baja_miembro", padron.motivo_baja_miembro));
                    cmd.Parameters.Add(new NpgsqlParameter("@Motivo_baja_miembro_agrupado", padron.motivo_baja_miembro_agrupado));
                    cmd.Parameters.Add(new NpgsqlParameter("@Cobrador", padron.cobrador));
                    cmd.Parameters.Add(new NpgsqlParameter("@Zona", padron.zona));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_alta_grupo", padron.f_alta_grupo));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_antiguedad1", padron.f_antiguedad1));
                    cmd.Parameters.Add(new NpgsqlParameter("@Promotor", padron.promotor));
                    cmd.Parameters.Add(new NpgsqlParameter("@Tipo_grupo", padron.tipo_grupo));
                    cmd.Parameters.Add(new NpgsqlParameter("@Presento", padron.presento));
                    cmd.Parameters.Add(new NpgsqlParameter("@F_baja", padron.f_baja));
                    cmd.Parameters.Add(new NpgsqlParameter("@Motivo_baja_grupo", padron.motivo_baja_grupo));
                    cmd.Parameters.Add(new NpgsqlParameter("@Motivo_baja_agrupado_grupo", padron.motivo_baja_agrupado_grupo));
                    cmd.Parameters.Add(new NpgsqlParameter("@Paciente_Cronico", padron.paciente_cronico));
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
