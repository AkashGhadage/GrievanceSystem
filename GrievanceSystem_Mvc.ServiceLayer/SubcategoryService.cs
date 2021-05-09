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
    public class SubcategoryService : ISubcategoryService
    {
        readonly ISubcategoryRepository scr;

        public SubcategoryService()
        {
            scr = new SubcategoryRepository();
        }

        public int InsertSubcategory(NewSubcategoryViewModel subcategory)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewSubcategoryViewModel, Subcategory>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Subcategory r = mapper.Map<NewSubcategoryViewModel, Subcategory>(subcategory);
            int rowAffeted = scr.InsertSubcategory(r);
            return rowAffeted;
        }

        public int UpdateSubcategory(EditSubcategoryViewModel subcategory)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditSubcategoryViewModel, Subcategory>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Subcategory r = mapper.Map<EditSubcategoryViewModel, Subcategory>(subcategory);
            int rowAffeted = scr.UpdateSubcategory(r);
            return rowAffeted;
        }

        public int DeleteSubcategory(int subcategoryId)
        {
            int rowAffeted = scr.DeleteSubcategory(subcategoryId);
            return rowAffeted;
        }

        public List<SubcategoryViewModel> GetSubcategory()
        {
            List<Subcategory> subcategories = scr.GetSubcategory();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Subcategory, SubcategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<SubcategoryViewModel> subcategoryViewModel = mapper.Map<List<Subcategory>, List<SubcategoryViewModel>>(subcategories);
            return subcategoryViewModel;
        }

        public List<SubcategoryViewModel> GetSubcategoryByCategoryId(int categoryId)
        {
            List<Subcategory> subcategories = scr.GetSubcategoryByCategoryId(categoryId);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Subcategory, SubcategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<SubcategoryViewModel> subcategoryViewModel = mapper.Map<List<Subcategory>, List<SubcategoryViewModel>>(subcategories);
            return subcategoryViewModel;
        }

        public SubcategoryViewModel GetSubategoryById(int subcategoryId)
        {
            Subcategory subcategory = scr.GetSubcategoryById(subcategoryId);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Subcategory, SubcategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            SubcategoryViewModel subcategoryViewModel = mapper.Map<Subcategory, SubcategoryViewModel>(subcategory);
            return subcategoryViewModel;
        }
    }
}
