using Microsoft.EntityFrameworkCore;
using WebCurs2.Data.Domain.Repositories.Abstract;
using System.Collections;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFNavigateRepository : INavigateRepository
    {
        private readonly ApplicationDbContext _context;
        public EFNavigateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Navigate navigate)
        {
            return _context.Navigates.AddAsync(navigate).IsCompletedSuccessfully;
        }

        public async Task<List<Navigate>> GetAllAsync()
        {
            return await _context.Navigates.ToListAsync();
        }

        public async Task<Navigate?> GetByNameAsync(string name)
        {
            return await _context.Navigates.FirstOrDefaultAsync(n => n.Name == name);
        }

        public async Task<List<Navigate>> GetChildrensByParentIdAsync(long id)
        {
            return await _context.Navigates.Where(i => i.ParentId == id).OrderBy(i=>i.OrderId).ToListAsync();
        }

        public async Task<List<Navigate>> GetParentsAsync()
        {
            return await _context.Navigates.Where(i => i.ParentId == null).OrderBy(i => i.OrderId).ToListAsync();
        }

        public async Task SeveAsync(Navigate nav)
        {
            if (nav.Id == default)
                _context.Entry(nav).State = EntityState.Added;
            else
                _context.Entry(nav).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Navigate entity)
        {
            _context.Navigates.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
