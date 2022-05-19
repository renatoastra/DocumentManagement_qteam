using DocumentManagement.Models;
using DocumentManegemant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DocumentManagement.Repositories;

namespace DocumentManagement.Controllers
{
    public class DocumentsController : Controller
    {
        IWebHostEnvironment _appEnvironment;
        private readonly AppDbContext _context;
        private readonly DocumentRepository _documentRepository;

        public DocumentsController(AppDbContext context, IWebHostEnvironment env, DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
            _context = context;
            _appEnvironment = env;
        }

        public async Task<IActionResult> Index()
        {
            var getDocumentList = await _documentRepository.List();
            return View(getDocumentList);
        }

        public IActionResult Create()
        {
            var process = _context.Process.ToList();
            var category = _context.Category.ToList();
            ViewBag.process = process;
            ViewBag.category = category;

            if (process.Count < 1)
            {
                ViewBag.processError = true;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title, ProcessId, CategoryId, Code, File")] DocumentModel document)
        {
            var process = _context.Process.ToList();
            ViewBag.process = process;

            if (ModelState.IsValid)
            {   
                if(document.File != null)
                {
                    string serverPath = "uploadedfiles/documents/";
                    document.FileUrl  = await FileUpload(serverPath, document.File); 
                }

                var response =  await _documentRepository.InsertDocument(document);
                if (!response)
                {
                    return ViewBag.insertDocumentError = true;
                }
                ViewBag.success = true;
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var document = await _context.Document
                .Include(x => x.Process)
                .FirstOrDefaultAsync(x => x.Id == id);
          
            return View(document);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _documentRepository.DeleteDocument(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<string> FileUpload(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_appEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
}
