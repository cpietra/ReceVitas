using ExcelDataReader;
using ReceVitas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ReceVitas.Clases
{
    public class ImportarMedicamentos
    {
        public List<Medicamentos> List_Medicamentos(string file)
        {
            StreamReader objReader = new StreamReader(file);
            string sLine = "";
            List<Medicamentos> Return_list = new List<Medicamentos>();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && sLine != "")
                {
                    string[] fields = sLine.Split(',');
                    if (fields[0] != "id")
                    {
                        if (fields[2].Trim() != "")
                        {
                            Medicamentos Medic = new Medicamentos();
                            Medic.atc = fields[0].ToString().Trim();
                            Medic.generico = fields[1].ToString().Trim();
                            Medic.nombre = fields[2].ToString().Trim();
                            Medic.presentacion = fields[3].ToString().Trim();
                            if (fields[4].Trim() != "") { Medic.pvp = Convert.ToInt32(fields[4].ToString().Trim()); }
                            if (fields[5].Trim() != "") { Medic.acargoos = Convert.ToInt32(fields[5].ToString().Trim()); }
                            if (fields[6].Trim() != "") { Medic.acargoafil = Convert.ToInt32(fields[6].ToString().Trim()); }
                            Medic.laboratorio = fields[7].ToString().Trim();
                            if (fields[8].Trim() != "") { Medic.registro = Convert.ToInt32(fields[8].ToString().Trim()); }
                            if (fields[9].Trim() != "") { Medic.pr = Convert.ToInt32(fields[9].ToString().Trim()); }
                            if (fields[10].Trim() != "") { Medic.grupoter = Convert.ToInt32(fields[10].ToString().Trim()); }
                            Medic.obser = fields[12].ToString().Trim();
                            Return_list.Add(Medic);
                        }
                    }
                }
            }
            objReader.Close();
            return Return_list;
        }

        public int Import_Medicamentos(String file)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //StreamReader objReader = new StreamReader(file);
            //string sLine = "";
            int retorno = 0;
            int rowcurrent = 0;
            DaoMedicamentos daoMedic = new DaoMedicamentos();
            try
            {
                using (var stream = File.Open(file, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {                        
                        do
                        {
                            while (reader.Read())
                            {
                                if (rowcurrent >=5)
                                {
                                    Medicamentos Medic = new Medicamentos();
                                    Medic.atc = reader.GetString(1).Trim(); // fields[0].ToString().Trim();
                                    Medic.generico = reader.GetString(2).Trim(); // fields[1].ToString().Trim();
                                    Medic.nombre = reader.GetString(3).Trim(); // fields[2].ToString().Trim();
                                    Medic.presentacion = reader.GetString(4).Trim(); // fields[3].ToString().Trim();
                                    Medic.pvp = reader.GetDouble(5); // Convert.ToInt32(fields[4].ToString().Trim()); }
                                    Medic.acargoos = reader.GetDouble(6); // Convert.ToInt32(fields[5].ToString().Trim()); }
                                    Medic.acargoafil = reader.GetDouble(7); // Convert.ToInt32(fields[6].ToString().Trim()); }
                                    Medic.laboratorio = reader.GetString(8).Trim(); // fields[7].ToString().Trim();
                                    Medic.registro = reader.GetDouble(9); // Convert.ToInt32(fields[8].ToString().Trim()); }
                                    Medic.pr = reader.GetDouble(10); // Convert.ToInt32(fields[9].ToString().Trim()); }
                                    Medic.grupoter = reader.GetDouble(11); // Convert.ToInt32(fields[11].ToString().Trim()); }
                                    if (!reader.IsDBNull(12)) { Medic.obser = reader.GetString(12).Trim(); } else { Medic.obser = ""; } // fields[12].ToString().Trim();*/
                                    if (daoMedic.Insert_Medicamentos(Medic)) { retorno++; }
                                }
                                rowcurrent++;
                            }                            
                        } while (reader.NextResult());

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return retorno;
        }
    }
}
