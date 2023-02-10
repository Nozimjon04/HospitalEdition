using PharmacyEditon.Models;

namespace PharmacyEditon.IRepositories
{
    public interface IMedicineRepository
    {
        Task<Medicine> CreateAsync(Medicine medicine);
        Task<bool> DelateAsync(string name);
        Task<List<Medicine>> GetAllAsync();
        Task<Medicine> GetByIdAsync(int id);
        Task<Medicine> UpdateAsync(Medicine medicine);

    }
}
