using leave_management.Data;
using leave_management.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        async public Task<bool> Create(LeaveHistory entity)
        {
            await _db.LeaveHistories.AddAsync(entity);
            return await Save();
        }

        async public Task<bool> Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return await Save();
        }

        async public Task<ICollection<LeaveHistory>> FindAll()
        {
            return await _db.LeaveHistories.ToListAsync();
        }

        async public Task<LeaveHistory> FindById(int id)
        {
            return await _db.LeaveHistories.FindAsync(id);
        }

        async public Task<bool> isExists(int id)
        {
            return await _db.LeaveHistories.AnyAsync(lh => lh.Id == id);
        }

        async public Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        async public Task<bool> Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return await Save();

        }
    }
}
