using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RegistroUsuarios.Models;

namespace RegistroUsuarios.Controllers
{
    public class PalindromoController : Controller
    {
        private readonly DbtestContext _context;

        public PalindromoController(DbtestContext context)
        {
            _context = context;
        }

        // GET: Palindromo
        public async Task<IActionResult> Index()
        {
            var palindromos = await _context.Palindromo.ToListAsync();
            return View(palindromos);
        }

        // GET: Palindromo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Palindromo == null)
            {
                return NotFound();
            }

            var palindromo = await _context.Palindromo
                .FirstOrDefaultAsync(m => m.Texto == id);
            if (palindromo == null)
            {
                return NotFound();
            }

            return View(palindromo);
        }

        // GET: Palindromo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Palindromo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Texto")] Palindromo palindromo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(palindromo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(palindromo);
        }



        // GET: Palindromo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Palindromo == null)
            {
                return NotFound();
            }

            var palindromo = await _context.Palindromo.FindAsync(id);
            if (palindromo == null)
            {
                return NotFound();
            }
            return View(palindromo);
        }

        // POST: Palindromo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Texto")] Palindromo palindromo)
        {
            if (id != palindromo.Texto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(palindromo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalindromoExists(palindromo.Texto))
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
            return View(palindromo);
        }

        // GET: Palindromo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Palindromo == null)
            {
                return NotFound();
            }

            var palindromo = await _context.Palindromo
                .FirstOrDefaultAsync(m => m.Texto == id);
            if (palindromo == null)
            {
                return NotFound();
            }

            return View(palindromo);
        }

        // POST: Palindromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Palindromo == null)
            {
                return Problem("Entity set 'DbtestContext.Palindromo'  is null.");
            }
            var palindromo = await _context.Palindromo.FindAsync(id);
            if (palindromo != null)
            {
                _context.Palindromo.Remove(palindromo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalindromoExists(string id)
        {
            return _context.Palindromo.Any(e => e.Texto == id);
        }

        // Método para encontrar palíndromos
        [HttpPost]
        public IActionResult EncontrarPalindromos(Palindromo model)
        {        
            if (ModelState.IsValid)
            {
                string texto = model.Texto;

                if (string.IsNullOrEmpty(texto))
                {
                    return RedirectToAction(nameof(Index));
                }

                // Eliminar espacios en blanco y convertir a minúsculas
                string textoSinEspacios = texto.Replace(" ", "").ToLower();

                /*
                // Obtener subtextos posibles
                List<string> subtextos = ObtenerSubtextos(textoSinEspacios);*/

                // Filtrar palíndromos
                List<string> palindromosEncontrados = FiltrarPalindromos(textoSinEspacios);

                //Establecer ViewBag
                ViewBag.Buscado = true;

                /*
                ViewBag.NumPalindromos = palindromosEncontrados.Count;*/

                //Enviar lista de palindromos a la vista Index
                var palindromosModel = palindromosEncontrados.Select(p => new Palindromo { Texto = p });
                return View("Index", palindromosModel); 
                

            }

            // Si el modelo no es válido, retornar a la vista original
            return View("Index", model);
        }

        private List<string> ObtenerSubtextos(string texto)
        {
            List<string> subtextos = new List<string>();

            for (int i = 0; i < texto.Length; i++)
            {
                for (int j = i; j < texto.Length; j++)
                {
                    string subtexto = texto.Substring(i, j - i + 1);
                    subtextos.Add(subtexto);
                }
            }

            return subtextos;
        }

        private List<string> FiltrarPalindromos(string texto)
        {
            List<string> palindromos = new List<string>();

            for (int i = 0; i < texto.Length; i++)
            {
                for (int j = i + 1; j <= texto.Length; j++)
                {
                    string subtexto = texto.Substring(i, j - i);

                    if (EsPalindromo(subtexto))
                    {
                        palindromos.Add(subtexto);
                    }
                }
            }      

            return palindromos;
        }

        private bool EsPalindromo(string texto)
        {
            int longitud = texto.Length;
            int mitad = longitud / 2;

            for (int i = 0; i < mitad; i++)
            {
                if (texto[i] != texto[longitud - i - 1])
                {
                    return false;
                }
            }


            return true;
        }
    }
}
        


