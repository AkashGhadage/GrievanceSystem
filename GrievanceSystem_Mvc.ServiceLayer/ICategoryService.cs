using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface ICategoryService
    {
        int InsertCategory(NewCategoryViewModel category);

        int UpdateCategory(EditCategoryViewModel category);

        int DeleteCategory(int categoryId);

        List<CategoryViewModel> GetCategory(); // to fetch all Category

        CategoryViewModel GetCategoryById(int id);
    }
}
