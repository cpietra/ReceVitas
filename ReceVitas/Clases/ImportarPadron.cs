using ReceVitas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReceVitas.Clases
{
    public class ImportarPadron
    {
        public List<Padron> List_Padron(string file)
        {
            StreamReader objReader = new StreamReader(file);
            string sLine = "";
            List<Padron> Return_list = new List<Padron>();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != "")
                {
                    string[] fields = sLine.Split(',');
                    if (fields[0] != "plan")
                    {
                        if (fields[2].Trim() != "")
                        {
                            Padron Padron1 = new Padron()
                            {
                                plan = fields[0].ToString().Trim(),
                                categoria = fields[1].ToString().Trim()
                            };
                            if (fields[2].Trim() != "") { Padron1.numero = Convert.ToInt32(fields[2].ToString().Trim()); }
                            if (fields[3].Trim() != "") { Padron1.orden = Convert.ToInt32(fields[3].ToString().Trim()); }
                            Padron1.tipo_doc = fields[4].ToString().Trim();
                            Padron1.num_doc = fields[5].ToString().Trim();
                            Padron1.nombre = fields[6].ToString().Trim();
                            Padron1.sexo = fields[7].ToString().Trim();
                            Padron1.ecivil = fields[8].ToString().Trim();
                            if (fields[9].Trim() != "") { Padron1.f_nacimiento = DateTime.ParseExact(fields[9].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.nacionalidad = fields[10].ToString().Trim();
                            Padron1.parentesco = fields[11].ToString().Trim();
                            Padron1.vive_calle = fields[12].ToString().Trim();
                            Padron1.vive_numero = fields[13].ToString().Trim();
                            Padron1.vive_piso = fields[14].ToString().Trim();
                            Padron1.vive_depto = fields[15].ToString().Trim();
                            Padron1.vive_cod_postal = fields[16].ToString().Trim();
                            Padron1.vive_localidad_texto = fields[17].ToString().Trim();
                            Padron1.vive_localidad = fields[18].ToString().Trim();
                            Padron1.vive_partido = fields[19].ToString().Trim();
                            Padron1.vive_provincia = fields[20].ToString().Trim();
                            Padron1.telefono = fields[21].ToString().Trim();
                            Padron1.movil = fields[22].ToString().Trim();
                            Padron1.email = fields[23].ToString().Trim();
                            if (fields[24].Trim() != "") { Padron1.f_ingreso = DateTime.ParseExact(fields[24].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.prepaga_anterior = fields[25].ToString().Trim();
                            if (fields[26].Trim() != "") { Padron1.f_egreso = DateTime.ParseExact(fields[26].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.prepaga_proxima = fields[27].ToString().Trim();
                            Padron1.volveria = fields[28].ToString().Trim();
                            Padron1.motivo_baja_miembro = fields[29].ToString().Trim();
                            Padron1.motivo_baja_miembro_agrupado = fields[30].ToString().Trim();
                            Padron1.cobrador = fields[31].ToString().Trim();
                            Padron1.zona = fields[32].ToString().Trim();
                            if (fields[33].Trim() != "") { Padron1.f_alta_grupo = DateTime.ParseExact(fields[33].ToString().Trim(), "dd/MM/yyyy", null); }
                            if (fields[34].Trim() != "") { Padron1.f_antiguedad1 = DateTime.ParseExact(fields[34].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.promotor = fields[35].ToString().Trim();
                            Padron1.tipo_grupo = fields[36].ToString().Trim();
                            Padron1.presento = fields[37].ToString().Trim();
                            if (fields[38].Trim() != "") { Padron1.f_baja = DateTime.ParseExact(fields[38].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.motivo_baja_grupo = fields[39].ToString().Trim();
                            Padron1.motivo_baja_agrupado_grupo = fields[40].ToString().Trim();
                            Padron1.paciente_cronico = false;
                            //Padron1.enfermedades = fields[41].ToString().Trim();
                            Return_list.Add(Padron1);
                        }
                    }
                }
            }
            objReader.Close();
            return Return_list;
        }

        public int Import_Padron(String file)
        {
            StreamReader objReader = new StreamReader(file);
            string sLine = "";
            int retorno = 0;
            DaoPadron daoPadron = new DaoPadron();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != "")
                {
                    string[] fields = sLine.Split(',');
                    if (fields[0] != "plan")
                    {
                        if (fields[2].Trim() != "")
                        {
                            Padron Padron1 = new Padron()
                            {
                                plan = fields[0].ToString().Trim(),
                                categoria = fields[1].ToString().Trim()
                            };
                            if (fields[2].Trim() != "") { Padron1.id_Padron = Convert.ToInt32(fields[2].ToString().Trim()); }
                            if (fields[2].Trim() != "") { Padron1.numero = Convert.ToInt32(fields[2].ToString().Trim()); }
                            if (fields[3].Trim() != "") { Padron1.orden = Convert.ToInt32(fields[3].ToString().Trim()); }
                            Padron1.tipo_doc = fields[4].ToString().Trim();
                            Padron1.num_doc = fields[5].ToString().Trim();
                            Padron1.nombre = fields[6].ToString().Trim();
                            Padron1.sexo = fields[7].ToString().Trim();
                            Padron1.ecivil = fields[8].ToString().Trim();
                            if (fields[9].Trim() != "") { Padron1.f_nacimiento = DateTime.ParseExact(fields[9].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.nacionalidad = fields[10].ToString().Trim();
                            Padron1.parentesco = fields[11].ToString().Trim();
                            Padron1.vive_calle = fields[12].ToString().Trim();
                            Padron1.vive_numero = fields[13].ToString().Trim();
                            Padron1.vive_piso = fields[14].ToString().Trim();
                            Padron1.vive_depto = fields[15].ToString().Trim();
                            Padron1.vive_cod_postal = fields[16].ToString().Trim();
                            Padron1.vive_localidad_texto = fields[17].ToString().Trim();
                            Padron1.vive_localidad = fields[18].ToString().Trim();
                            Padron1.vive_partido = fields[19].ToString().Trim();
                            Padron1.vive_provincia = fields[20].ToString().Trim();
                            Padron1.telefono = fields[21].ToString().Trim();
                            Padron1.movil = fields[22].ToString().Trim();
                            Padron1.email = fields[23].ToString().Trim();
                            if (fields[24].Trim() != "") { Padron1.f_ingreso = DateTime.ParseExact(fields[24].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.prepaga_anterior = fields[25].ToString().Trim();
                            if (fields[26].Trim() != "") { Padron1.f_egreso = DateTime.ParseExact(fields[26].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.prepaga_proxima = fields[27].ToString().Trim();
                            Padron1.volveria = fields[28].ToString().Trim();
                            Padron1.motivo_baja_miembro = fields[29].ToString().Trim();
                            Padron1.motivo_baja_miembro_agrupado = fields[30].ToString().Trim();
                            Padron1.cobrador = fields[31].ToString().Trim();
                            Padron1.zona = fields[32].ToString().Trim();
                            if (fields[33].Trim() != "") { Padron1.f_alta_grupo = DateTime.ParseExact(fields[33].ToString().Trim(), "dd/MM/yyyy", null); }
                            if (fields[34].Trim() != "") { Padron1.f_antiguedad1 = DateTime.ParseExact(fields[34].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.promotor = fields[35].ToString().Trim();
                            Padron1.tipo_grupo = fields[36].ToString().Trim();
                            Padron1.presento = fields[37].ToString().Trim();
                            if (fields[38].Trim() != "") { Padron1.f_baja = DateTime.ParseExact(fields[38].ToString().Trim(), "dd/MM/yyyy", null); }
                            Padron1.motivo_baja_grupo = fields[39].ToString().Trim();
                            Padron1.motivo_baja_agrupado_grupo = fields[40].ToString().Trim();
                            Padron1.paciente_cronico = false;
                            //Padron1.enfermedades = fields[41].ToString().Trim();
                            if (daoPadron.Insert_Padron(Padron1)) { retorno++; }
                        }
                    }
                }
            }
            objReader.Close();
            return retorno;
        }
    }
}
