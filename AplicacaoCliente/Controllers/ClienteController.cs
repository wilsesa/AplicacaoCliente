using AplicacaoCliente.Data;
using AplicacaoCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCliente.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create(int? id)
        {
            Cliente cliente = new Cliente();
            if (id == null)
            {
                return View(cliente);
            }
            else
            {
                cliente = await _db.Cliente.FindAsync(id);
                return View(cliente);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)     //Cria um registro
                {
                    await _db.Cliente.AddAsync(cliente);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
                else
                {
                    _db.Cliente.Update(cliente);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Create), new { id=
                        0 });
                }
            }
            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _db.Cliente.ToListAsync();
            return Json(new { data = todos });
        }
    }
}

