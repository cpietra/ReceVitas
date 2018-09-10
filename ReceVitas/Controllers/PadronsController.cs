using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReceVitas.Models;

namespace ReceVitas.Controllers
{
    public class PadronsController : Controller
    {
        private readonly int _RegistrosPorPagina = 10;
        private List<Padron> _Padrons;
        private PaginadorGenerico<Padron> _PaginadorCustomers;
        private readonly RecetasContext _context;

        public PadronsController(RecetasContext context)
        {
            _context = context;
        }

        /*public ActionResult Index(int pagina = 1)
        {
            int _TotalRegistros = 0;
            using (_context.padron.ToListAsync())
            {
                // Número total de registros de la tabla Customers
                _TotalRegistros = _context.padron.Count();
                // Obtenemos la 'página de registros' de la tabla Customers
                _Padrons = _context.padron.OrderBy(x => x.numero)
                                                 .Skip((pagina - 1) * _RegistrosPorPagina)
                                                 .Take(_RegistrosPorPagina)
                                                 .ToList();
                // Número total de páginas de la tabla Customers
                var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginadorCustomers = new PaginadorGenerico<Padron>()
                {
                    RegistrosPorPagina = _RegistrosPorPagina,
                    TotalRegistros = _TotalRegistros,
                    TotalPaginas = _TotalPaginas,
                    PaginaActual = pagina,
                    Resultado = _Padrons
                };
                // Enviamos a la Vista la 'Clase de paginación'
                return View(_PaginadorCustomers);
            }
        }*/

        // GET: Padrons
        public async Task<IActionResult> Index()
        {
            return View(await _context.padron.ToListAsync());
        }

        // GET: Padrons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padron = await _context.padron
                .FirstOrDefaultAsync(m => m.id_Padron == id);
            if (padron == null)
            {
                return NotFound();
            }

            return View(padron);
        }

        // GET: Padrons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Padrons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Padron,plan,categoria,numero,orden,tipo_doc,num_doc,nombre,sexo,ecivil,f_nacimiento,nacionalidad,parentesco,vive_calle,vive_numero,vive_piso,vive_depto,vive_cod_postal,vive_localidad_texto,vive_localidad,vive_partido,vive_provincia,telefono,movil,email,f_ingreso,prepaga_anterior,f_egreso,prepaga_proxima,volveria,motivo_baja_miembro,motivo_baja_miembro_agrupado,cobrador,zona,f_alta_grupo,f_antiguedad1,promotor,tipo_grupo,presento,f_baja,motivo_baja_grupo,motivo_baja_agrupado_grupo,enfermedades,paciente_cronico")] Padron padron)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padron);
        }

        // GET: Padrons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padron = await _context.padron.FindAsync(id);
            if (padron == null)
            {
                return NotFound();
            }
            return View(padron);
        }

        // POST: Padrons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Padron,plan,categoria,numero,orden,tipo_doc,num_doc,nombre,sexo,ecivil,f_nacimiento,nacionalidad,parentesco,vive_calle,vive_numero,vive_piso,vive_depto,vive_cod_postal,vive_localidad_texto,vive_localidad,vive_partido,vive_provincia,telefono,movil,email,f_ingreso,prepaga_anterior,f_egreso,prepaga_proxima,volveria,motivo_baja_miembro,motivo_baja_miembro_agrupado,cobrador,zona,f_alta_grupo,f_antiguedad1,promotor,tipo_grupo,presento,f_baja,motivo_baja_grupo,motivo_baja_agrupado_grupo,enfermedades,paciente_cronico")] Padron padron)
        {
            if (id != padron.id_Padron)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadronExists(padron.id_Padron))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(padron);
        }

        // GET: Padrons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padron = await _context.padron
                .FirstOrDefaultAsync(m => m.id_Padron == id);
            if (padron == null)
            {
                return NotFound();
            }

            return View(padron);
        }

        // POST: Padrons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padron = await _context.padron.FindAsync(id);
            _context.padron.Remove(padron);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadronExists(int id)
        {
            return _context.padron.Any(e => e.id_Padron == id);
        }
    }
}
