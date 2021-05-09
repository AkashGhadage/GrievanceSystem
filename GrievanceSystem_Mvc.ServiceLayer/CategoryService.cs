using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;
using GrievanceSystem_Mvc.DomainModels;
using GrievanceSystem_Mvc.Repositories;
using AutoMapper;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository cr;

        public CategoryService()
        {
            cr = new CategoryRepository();
        }

        public int InsertCategory(NewCategoryViewModel category)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewCategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<NewCategoryViewModel, Category>(category);
            int rowAffeted = cr.InsertCategory(c);
            return rowAffeted;
        }

        public int UpdateCategory(EditCategoryViewModel category)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<EditCategoryViewModel, Category>(category);
            int rowAffeted = cr.UpdateCategory(c);
            return rowAffeted;
        }

        public int DeleteCategory(int categoryId)
        {
            int rowAffeted = cr.DeleteCategory(categoryId);
            return rowAffeted;
        }

        public List<CategoryViewModel> GetCategory()
        {
            List<Category> categories = cr.GetCategory();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> categoryViewModel = mapper.Map<List<Category>, List<CategoryViewModel>>(categories);
            return categoryViewModel;
        }

        public CategoryViewModel GetCategoryById(int categoryId)
        {
            Category category = cr.GetCategoryById(categoryId);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            CategoryViewModel categoryViewModel = mapper.Map<Category, CategoryViewModel>(category);
            return categoryViewModel;
        }
    }
}
