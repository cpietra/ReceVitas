using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReceVitas.Models
{
    public class ModelRecetas
    {
        public Padron pad1 { get; set; }
        public Medicamentos med1 { get; set; }
    }

    public class SampleViewModel
    {
        [Display(Name = "Archivo de Padron")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "¡Tienes que marcar la casilla!")]
        public bool TermsAndConditions { get; set; }
    }

    public class PaginadorGenerico<T> where T : class
    {
        public int PaginaActual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Resultado { get; set; }
    }

    public class Padron
    {
        [Key]
        public int id_Padron { get; set; }
        public string plan { get; set; }
        public string categoria { get; set; }
        public int numero { get; set; }
        public int orden { get; set; }
        public string tipo_doc { get; set; }
        public string num_doc { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string ecivil { get; set; }
        public DateTime f_nacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string parentesco { get; set; }
        public string vive_calle { get; set; }
        public string vive_numero { get; set; }
        public string vive_piso { get; set; }
        public string vive_depto { get; set; }
        public string vive_cod_postal { get; set; }
        public string vive_localidad_texto { get; set; }
        public string vive_localidad { get; set; }
        public string vive_partido { get; set; }
        public string vive_provincia { get; set; }
        public string telefono { get; set; }
        public string movil { get; set; }
        public string email { get; set; }
        public DateTime f_ingreso { get; set; }
        public string prepaga_anterior { get; set; }
        public DateTime f_egreso { get; set; }
        public string prepaga_proxima { get; set; }
        public string volveria { get; set; }
        public string motivo_baja_miembro { get; set; }
        public string motivo_baja_miembro_agrupado { get; set; }
        public string cobrador { get; set; }
        public string zona { get; set; }
        public DateTime f_alta_grupo { get; set; }
        public DateTime f_antiguedad1 { get; set; }
        public string promotor { get; set; }
        public string tipo_grupo { get; set; }
        public string presento { get; set; }
        public DateTime f_baja { get; set; }
        public string motivo_baja_grupo { get; set; }
        public string motivo_baja_agrupado_grupo { get; set; }
        //public string enfermedades { get; set; }
        public Boolean paciente_cronico { get; set; }
    }

    public class Medicamentos
    {
        [Key]
        public int id_medicamento { get; set; }
        public string atc { get; set; }
        public string generico { get; set; }
        public string nombre { get; set; }
        public string presentacion { get; set; }
        public Double pvp { get; set; }
        public Double acargoos { get; set; }
        public Double acargoafil { get; set; }
        public string laboratorio { get; set; }
        public Double registro { get; set; }
        public Double pr { get; set; }
        public Double grupoter { get; set; }
        public string obser { get; set; }
    }

    public class Medicos
    {
        [Key]
        public int id_medico { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string telefono { get; set; }
        public string movil { get; set; }
        public string compania_m { get; set; }
        public string m_n { get; set; }
        public string m_p { get; set; }
        public string plan { get; set; }
        public Boolean activo { get; set; }
    }

    public class Patologias
    {
        [Key]
        public int id_pat { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public Boolean activo { get; set; }
    }

    public class Recetas_Registros
    {
        [Key]
        public int id_receta { get; set; }
        public int numero_afiliado { get; set; }
        public int id_medicamento { get; set; }
        public int cantidad { get; set; }
        public int id_medico { get; set; }
        public int id_pat { get; set; }
        public Boolean activo { get; set; }
    }

    public class RecetasContext : DbContext
    {
        public RecetasContext(DbContextOptions<RecetasContext> options)
            : base(options)
        { }

        public DbSet<Padron> padron { get; set; }
        public DbSet<Medicamentos> medicamentos { get; set; }
        public DbSet<Medicos> medicos { get; set; }
        public DbSet<Patologias> patologias { get; set; }
        public DbSet<Recetas_Registros> recetas_registros { get; set; }
    }
}
