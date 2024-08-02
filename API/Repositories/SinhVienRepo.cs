using API.Context;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace API.Repositories
{
    public class SinhVienRepo : ISinhVienRepo
    {
        private readonly AppDbContext _dbContext;
        public SinhVienRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(SinhVien sv)
        {
            _dbContext.SinhViens.Add(sv);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var sinhVien = await GetById(id);
            _dbContext.SinhViens.Remove(sinhVien);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<SinhVien>> GetAll()
        {
            return await _dbContext.SinhViens.ToListAsync();
        }

        public async Task<SinhVien> GetById(int id)
        {
            return await _dbContext.SinhViens.FindAsync(id);
        }

        public async Task Update(SinhVien sv)
        {
            _dbContext.Entry(sv).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
