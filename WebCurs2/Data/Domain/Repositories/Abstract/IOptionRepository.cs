using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCurs2.Data.Domain.Entities;

namespace WebCurs2.Data.Domain.Repositories.Abstract
{
    public interface IOptionRepository
    {
        IEnumerable<Option> Options { get; }

        public Task<List<Option>> GetAllAsync();

        public Option? GetByName(string name);
        public Task<Option?> GetByNameAsync(string name);

        public Task<bool> CreateAsync(Option entity);

        public Task SeveAsync(Option entity);
        public Task DeleteAsync(Option entity);

    }
}
