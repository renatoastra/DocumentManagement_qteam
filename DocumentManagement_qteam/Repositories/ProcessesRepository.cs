using DocumentManagement.Models;
using DocumentManegemant.Data;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagement.Repositories
{
    public class ProcessesRepository : IProcessesRepository
    {
        private readonly AppDbContext _context;
        public ProcessesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteProcess(int id)
        {
            var process = await _context.Process.FindAsync(id);

            if (process != null)
            {
                _context.Process.Remove(process);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<Process>> GetProcesses()
        {
            return await _context.Process.ToListAsync();
        }

        public async Task<bool> InsertProcess(Process process)
        {   
            if(process == null)
            {
                return false;
            }

            _context.Add(process);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
