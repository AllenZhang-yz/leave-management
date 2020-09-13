using leave_management.Data;
using leave_management.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        async public Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            return await Save();
        }

        async public Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return await Save();
        }

        async public Task<ICollection<LeaveAllocation>> FindAll()
        {
            return await _db.LeaveAllocations.ToListAsync();
        }

        async public Task<LeaveAllocation> FindById(int id)
        {
            return await _db.LeaveAllocations.FindAsync(id);
        }

        async public Task<bool> isExists(int id)
        {
            return await _db.LeaveAllocations.AnyAsync(la => la.Id == id);
        }

        async public Task<bool> Save()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        async public Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }
    }
}
