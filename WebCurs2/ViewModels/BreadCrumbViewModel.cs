using WebCurs2.Data.Domain.Entities;
using WebCurs2.Data.Domain.Repositories.Abstract;
using WebCurs2.Models;

namespace WebCurs2.ViewModels
{
    public class BreadCrumbViewModel
    {
        public Navigate endPoint { get; set; }
        public List<Navigate> NavPoints { get; set; }

        public IOptionRepository Options { get; set; }
        public INavigateRepository Navigates { get; set; }
    }
}
