using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;



namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface IReportService
    {
        
        List<GrievanceViewModel> GetDetailedReport(DateTime? startDate, DateTime? endDate);




    }
}

