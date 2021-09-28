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
    public class GrievanceService : IGrievanceService
    {

        readonly IGrievanceRepository gr;

        public GrievanceService()
        {
            gr = new GrievanceRepository();
        }

        public int InsertGrievanceDetails(NewGrievanceViewModel grievance)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewGrievanceViewModel, Grievance>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            //TODO : RESOLVE EXCEPTION AutoMapper.AutoMapperMappingException: 'Error mapping types.'
            Grievance grievanceDomainModel = mapper.Map<NewGrievanceViewModel, Grievance>(grievance);
            int rowAffected = gr.InsertGrievanceDetails(grievanceDomainModel);
            return rowAffected;
        }

        public int UpdateGrievanceDetails(EditGrievanceViewModel grievance)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditGrievanceViewModel, Grievance>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Grievance grievanceDomainModel = mapper.Map<EditGrievanceViewModel, Grievance>(grievance);
            int rowAffeted = gr.UpdateGrievanceDetails(grievanceDomainModel);
            return rowAffeted;
        }

        public int DeleteGrievance(int grievanceID)
        {
            int rowAffeted = gr.DeleteGrievance(grievanceID);
            return rowAffeted;
        }

        public List<GrievanceViewModel> GetGrievance()
        {
            List<Grievance> grievances = gr.GetGrievance();
            var config = new MapperConfiguration(
             cfg =>
             {
                 cfg.CreateMap<Grievance, GrievanceViewModel>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.StatusName));
                 cfg.IgnoreUnmapped();

                 cfg.CreateMap<Category, CategoryViewModel>();
                 cfg.CreateMap<Subcategory, SubcategoryViewModel>();
                 cfg.CreateMap<Reply, ReplyViewModel>();
                 cfg.IgnoreUnmapped();
             }
             );

            IMapper mapper = config.CreateMapper();
            List<GrievanceViewModel> grievanceViewModel = mapper.Map<List<Grievance>, List<GrievanceViewModel>>(grievances);
            return grievanceViewModel;
        }

        public List<GrievanceViewModel> GetGrievanceByUserId(int userId)
        {
            List<Grievance> grievances = gr.GetGrievanceByUserId(userId);
            List<GrievanceViewModel> grievanceViewModel = null;
            if (grievances != null)
            {
                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<Grievance, GrievanceViewModel>(); cfg.IgnoreUnmapped(); });
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Grievance, GrievanceViewModel>().ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.StatusName));
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Subcategory, SubcategoryViewModel>();
                    //cfg.CreateMap<Reply, ReplyViewModel>();

                    cfg.IgnoreUnmapped();
                });


                IMapper mapper = config.CreateMapper();
                grievanceViewModel = mapper.Map<List<Grievance>, List<GrievanceViewModel>>(grievances);

            }
            return grievanceViewModel;
        }

        public GrievanceViewModel GetGrievanceByGrievanceId(int grievanceId)
        {
            Grievance grievances = gr.GetGrievanceByGrievanceId(grievanceId).SingleOrDefault();
            GrievanceViewModel grievanceViewModel = null;
            if (grievances != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Grievance, GrievanceViewModel>().ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.StatusName));
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Subcategory, SubcategoryViewModel>();
                    cfg.CreateMap<Reply, ReplyViewModel>();

                    cfg.IgnoreUnmapped();
                });





                IMapper mapper = config.CreateMapper();
                grievanceViewModel = mapper.Map<Grievance, GrievanceViewModel>(grievances);

            }
            return grievanceViewModel;
        }

        public List<GrievanceViewModel> GetPendingGrievances()
        {
            int statusId = 1;
            List<Grievance> grievances = gr.GetGrievancesByStatusId(statusId);
            List<GrievanceViewModel> grievanceViewModel = null;
            if (grievances != null)
            {
                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<Grievance, GrievanceViewModel>(); cfg.IgnoreUnmapped(); });
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Grievance, GrievanceViewModel>().ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.StatusName));
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Subcategory, SubcategoryViewModel>();
                    cfg.CreateMap<Reply, ReplyViewModel>();

                    cfg.IgnoreUnmapped();
                });


                IMapper mapper = config.CreateMapper();
                grievanceViewModel = mapper.Map<List<Grievance>, List<GrievanceViewModel>>(grievances);

            }
            return grievanceViewModel;
        }

        public List<GrievanceViewModel> GetResolvedGrievances()
        {
            int statusId = 2;
            List<Grievance> grievances = gr.GetGrievancesByStatusId(statusId);
            List<GrievanceViewModel> grievanceViewModel = null;
            if (grievances != null)
            {
                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<Grievance, GrievanceViewModel>(); cfg.IgnoreUnmapped(); });
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Grievance, GrievanceViewModel>().ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.StatusName));
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.CreateMap<Subcategory, SubcategoryViewModel>();
                    cfg.CreateMap<Reply, ReplyViewModel>();

                    cfg.IgnoreUnmapped();
                });


                IMapper mapper = config.CreateMapper();
                grievanceViewModel = mapper.Map<List<Grievance>, List<GrievanceViewModel>>(grievances);

            }
            return grievanceViewModel;
        }
    }
}
