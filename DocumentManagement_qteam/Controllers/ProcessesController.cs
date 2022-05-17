using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocumentManagement.Models;
using DocumentManegemant.Data;
using DocumentManagement.Repositories;

namespace DocumentManagement.Controllers
{
    public class ProcessesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProcessesRepository _processRepository;

        public ProcessesController(AppDbContext context, ProcessesRepository processes)
        {
            _context = context;
            _processRepository = processes;
        }

        public async Task<IActionResult> Index()
        {
            var processesList = await _processRepository.GetProcesses();
            return View(processesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Process process)
        {
            if (ModelState.IsValid)
            {
                var response = await _processRepository.InsertProcess(process);
                if (!response)
                {
                    return View("Error");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(process);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var process = await _context.Process
                .FirstOrDefaultAsync(m => m.Id == id);
            if (process == null)
            {
                return NotFound();
            }

            return View(process);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
       
            var processToDelete = await _processRepository.DeleteProcess(id);
            if (!processToDelete)
            {
                return View("Process not found.");
            }
            return RedirectToAction(nameof(Index));
        }
       
    }
}
