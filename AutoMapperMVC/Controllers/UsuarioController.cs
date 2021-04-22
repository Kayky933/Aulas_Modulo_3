using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMapperMVC.Data;
using AutoMapperMVC.Models;

namespace AutoMapperMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MVCContext _context;

        public UsuarioController(MVCContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.UsuarioModel.Include(u => u.Endereco);
            return View(await mVCContext.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.UsuarioEndereco, "Id_Endereco", "Id_Endereco");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Usuario,Name,Email,Password,EnderecoId")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.UsuarioEndereco, "Id_Endereco", "Id_Endereco", usuarioModel.EnderecoId);
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.UsuarioEndereco, "Id_Endereco", "Id_Endereco", usuarioModel.EnderecoId);
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Usuario,Name,Email,Password,EnderecoId")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id_Usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.Id_Usuario))
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
            ViewData["EnderecoId"] = new SelectList(_context.UsuarioEndereco, "Id_Endereco", "Id_Endereco", usuarioModel.EnderecoId);
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.Id_Usuario == id);
        }
    }
}
