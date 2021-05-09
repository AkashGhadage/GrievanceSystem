using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public interface ICategoryRepository
    {
        int InsertCategory(Category category);

        int UpdateCategory(Category category);

        int DeleteCategory(int categoryId);

        List<Category> GetCategory(); // to fetch all Category
        Category GetCategoryById(int categoryId);
    }
}
