using Microsoft.EntityFrameworkCore;
using WebCurs2.Models;
using WebCurs2.Data.Domain.Repositories.Abstract;

namespace WebCurs2.Data.Domain.Repositories.EntityFramework
{
    public class EFNavigateRepository : INavigateRepository
    {
        private readonly ApplicationDbContext _context;
        public EFNavigateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Navigate>> GetAllAsync()
        {
            return await _context.Navigates.ToListAsync();
        }

        /*public async Task<User?> GetUser(string email,string password)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if(user!= null&&)


            return await _context.Users.FindAsync();


        }*/



        /*public async Task DeleteAsync(User user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }*/

        public async Task<List<Navigate>> GetChildrensByParentIdAsync(int id)
        {
            List<Navigate>? list = await _context.Navigates.ToListAsync();

            if (list != null)
                return list.FindAll((a) => a.ParentId == id);
            

            return null;
        }

        public async Task<List<Navigate>> GetParentsAsync()
        {
            List<Navigate>? list = await _context.Navigates.ToListAsync();

            if (list != null)
                return list.FindAll((a) => a.ParentId == null);


            return null;
        }

        /*public async Task SeveAsync(User user)
        {
            if (user.Id == default)
                _context.Entry(user).State = EntityState.Added;
            else
                _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }*/
    }
}
