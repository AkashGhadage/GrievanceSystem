using GrievanceSystem_Mvc.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrievanceSystem_Mvc.Repositories
{
    public interface ISubcategoryRepository
    {
        int InsertSubcategory(Subcategory subcategory);

        int UpdateSubcategory(Subcategory subcategory);

        int DeleteSubcategory(int subcategoryId);

        List<Subcategory> GetSubcategory(); // to fetch all subcat

        List<Subcategory> GetSubcategoryByCategoryId(int categoryId); // to fetch all subcat based on cat id 

        Subcategory GetSubcategoryById(int subcategoryId);
    }
}
