using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFOptionRepository : IOptionRepository
    {
        private readonly ApplicationDbContext _context;
        public EFOptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        IEnumerable<Option> IOptionRepository.Options => _context.Options;

        public async Task CreateAsync(Option entity)
        {
            await _context.Options.AddAsync(entity);
        }

        public async Task DeleteAsync(Option entity)
        {
            _context.Options.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Option>> GetAllAsync()
        {
            return await _context.Options.ToListAsync();
        }

        public Option? GetByName(string name)
        {
            return _context.Options.FirstOrDefault(n => n.Name == name);
        }

        public async Task<Option?> GetByNameAsync(string name)
        {
            return await _context.Options.FirstOrDefaultAsync(n => n.Name == name);
        }

        public async Task SeveAsync(Option entity)
        {
            if (entity.Id == default)
                _context.Entry(entity).State = EntityState.Added;
            else
                _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
