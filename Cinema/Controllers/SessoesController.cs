﻿using System;
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
    public class SessoesController : Controller
    {
        private readonly CinemaContext _context;

        public SessoesController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Sessoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sessao.ToListAsync());
        }

        // GET: Sessoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .FirstOrDefaultAsync(m => m.SessaoId == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // GET: Sessoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sessoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessaoId,Endereco,Salas")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sessao);
        }

        // GET: Sessoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao.FindAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }
            return View(sessao);
        }

        // POST: Sessoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessaoId,Endereco,Salas")] Sessao sessao)
        {
            if (id != sessao.SessaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessaoExists(sessao.SessaoId))
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
            return View(sessao);
        }

        // GET: Sessoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessao = await _context.Sessao
                .FirstOrDefaultAsync(m => m.SessaoId == id);
            if (sessao == null)
            {
                return NotFound();
            }

            return View(sessao);
        }

        // POST: Sessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sessao = await _context.Sessao.FindAsync(id);
            _context.Sessao.Remove(sessao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessao.Any(e => e.SessaoId == id);
        }
    }
}
