using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class DetalheSessoesController : Controller
    {
        private readonly CinemaContext _context;

        public DetalheSessoesController(CinemaContext context)
        {
            _context = context;
        }

        // GET: DetalheSessoes
        public async Task<IActionResult> Index()
        {
            var cinemaContext = _context.DetalheSessao.Include(d => d.Compra).Include(d => d.Filme).Include(d => d.Horario).Include(d => d.Sessao);
            return View(await cinemaContext.ToListAsync());
        }

        // GET: DetalheSessoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalheSessao = await _context.DetalheSessao
                .Include(d => d.Compra)
                .Include(d => d.Filme)
                .Include(d => d.Horario)
                .Include(d => d.Sessao)
                .FirstOrDefaultAsync(m => m.DetalheSessaoId == id);
            if (detalheSessao == null)
            {
                return NotFound();
            }

            return View(detalheSessao);
        }

        // GET: DetalheSessoes/Create
        public IActionResult Create()
        {
            ViewData["CompraId"] = new SelectList(_context.Compra, "CompraId", "Valor");
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme");
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioSessao");
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "Endereco");
            return View();
        }

        // POST: DetalheSessoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetalheSessaoId,NumeroSala,QuantidadeLugares,HorarioId,FilmeId,CadeiraSelecionada,SessaoId,CompraId")] DetalheSessao detalheSessao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalheSessao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "CompraId", "Valor", detalheSessao.CompraId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", detalheSessao.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioSessao", detalheSessao.HorarioId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "Endereco", detalheSessao.SessaoId);
            return View(detalheSessao);
        }

        // GET: DetalheSessoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalheSessao = await _context.DetalheSessao.FindAsync(id);
            if (detalheSessao == null)
            {
                return NotFound();
            }
            ViewData["CompraId"] = new SelectList(_context.Compra, "CompraId", "Valor", detalheSessao.CompraId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", detalheSessao.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioSessao", detalheSessao.HorarioId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "Endereco", detalheSessao.SessaoId);
            return View(detalheSessao);
        }

        // POST: DetalheSessoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetalheSessaoId,NumeroSala,QuantidadeLugares,HorarioId,FilmeId,CadeiraSelecionada,SessaoId,CompraId")] DetalheSessao detalheSessao)
        {
            if (id != detalheSessao.DetalheSessaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalheSessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalheSessaoExists(detalheSessao.DetalheSessaoId))
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
            ViewData["CompraId"] = new SelectList(_context.Compra, "CompraId", "Valor", detalheSessao.CompraId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "FilmeId", "NomeFilme", detalheSessao.FilmeId);
            ViewData["HorarioId"] = new SelectList(_context.Horario, "HorarioId", "HorarioSessao", detalheSessao.HorarioId);
            ViewData["SessaoId"] = new SelectList(_context.Sessao, "SessaoId", "Endereco", detalheSessao.SessaoId);
            return View(detalheSessao);
        }

        // GET: DetalheSessoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalheSessao = await _context.DetalheSessao
                .Include(d => d.Compra)
                .Include(d => d.Filme)
                .Include(d => d.Horario)
                .Include(d => d.Sessao)
                .FirstOrDefaultAsync(m => m.DetalheSessaoId == id);
            if (detalheSessao == null)
            {
                return NotFound();
            }

            return View(detalheSessao);
        }

        // POST: DetalheSessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalheSessao = await _context.DetalheSessao.FindAsync(id);
            _context.DetalheSessao.Remove(detalheSessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalheSessaoExists(int id)
        {
            return _context.DetalheSessao.Any(e => e.DetalheSessaoId == id);
        }
    }
}
