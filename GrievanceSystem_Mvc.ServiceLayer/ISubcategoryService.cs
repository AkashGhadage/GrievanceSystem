using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface ISubcategoryService
    {
        int InsertSubcategory(NewSubcategoryViewModel subcategory);

        int UpdateSubcategory(EditSubcategoryViewModel subcategory);

        int DeleteSubcategory(int subcategoryId);

        List<SubcategoryViewModel> GetSubcategory(); // to fetch all subcat

        List<SubcategoryViewModel> GetSubcategoryByCategoryId(int categoryId); // to fetch all subcat based on cat id 
      
        SubcategoryViewModel GetSubategoryById(int subcategoryId);
    }
}
