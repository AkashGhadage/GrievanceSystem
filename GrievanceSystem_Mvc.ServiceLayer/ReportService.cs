using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ReportService : IReportService
    {

        readonly IReportRepository reportRepository;

        public ReportService()
        {
            reportRepository = new ReportRepository();

        }

        public List<GrievanceViewModel> GetDetailedReport(DateTime? startDate, DateTime? endDate)
        {
            //all service/business logic goes here nd auto mapping happend here 


            List<Grievance> grievances = reportRepository.GetDetailedReport(startDate, endDate);
          
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
                    cfg.CreateMap<User, UserViewModel>();

                    cfg.IgnoreUnmapped();
                });


                IMapper mapper = config.CreateMapper();
                grievanceViewModel = mapper.Map<List<Grievance>, List<GrievanceViewModel>>(grievances);

            }
            return grievanceViewModel;

        }
    }
}
