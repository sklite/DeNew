using DeNew.Models;
using DeNew.Models.Entities;
using System.Linq;

namespace DeNew.Services.Pages
{
    public class PageManipulator : IPageManipulator
    {

        private readonly DeContext _context;
        public PageManipulator(DeContext context)
        {
            _context = context;
        }

        public Page CreateNewPage(int parentId)
        {

            var parentPage = _context.Pages.FirstOrDefault(page => page.Id == parentId);
            if (parentPage == null)
                return null;

            var newPage = new Page()
            {
                Name = "Новая страница",
                Description = "Описание",
                Content = "Содержание статьи",
                ParentPage = parentPage,
            };
            _context.Pages.Add(newPage);

            _context.SaveChanges();
            newPage.Alias = newPage.Id.ToString();
            _context.SaveChanges();
            return newPage;
        }

        public bool DeletePage(int pageId, out string message)
        {
            var page = _context.Pages.FirstOrDefault(item => item.Id == pageId);

            if (page == null)
            {
                message = $"Указанной страницы с id = {pageId} не существует";
                return false;
            }

            if (page.SubPages != null && page.SubPages.Any())
            {
                message = $"У страницы с {pageId} есть подстраницы. Сначала удалите их";
                return false;
            }

            page.IsDeleted = true;
            _context.SaveChanges();
            message = "Успешно удалено";
            return true;
        }
    }
}