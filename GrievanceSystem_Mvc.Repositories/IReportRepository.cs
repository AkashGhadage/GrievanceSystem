using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public interface IReportRepository
    {
        List<Grievance> GetDetailedReport(DateTime? startDate, DateTime? endDate);



    }
}
