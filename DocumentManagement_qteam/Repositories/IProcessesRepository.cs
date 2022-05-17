using DocumentManagement.Models;

namespace DocumentManagement.Repositories
{
    public interface IProcessesRepository
    {
        Task<bool> DeleteProcess(int id);

        Task<bool> InsertProcess(Process process);

        Task<List<Process>> GetProcesses();
    }
}
