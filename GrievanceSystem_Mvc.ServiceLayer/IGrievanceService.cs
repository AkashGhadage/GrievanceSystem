using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrievanceSystem_Mvc.ViewModels;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public interface IGrievanceService
    {
        int InsertGrievanceDetails(NewGrievanceViewModel grievance);

        int UpdateGrievanceDetails(EditGrievanceViewModel grievance);

        int DeleteGrievance(int grievanceID);

        List<GrievanceViewModel> GetGrievance(); // to fetch all users

        List<GrievanceViewModel> GetGrievanceByUserId(int userId); //to get grievance by  user  id 

        GrievanceViewModel GetGrievanceByGrievanceId(int grievanceId); // to get grievance by g id 
        List<GrievanceViewModel> GetPendingGrievances();
        List<GrievanceViewModel> GetResolvedGrievances();

        //GrievanceStatViewModel GetGrievanceStat(); // total grievances 2-> redressed grievance 3 -> pending grievance
        //GrievanceViewModel GetGrievanceByGrievanceId(int userId); //to get grievance by  grievance  id 

    }
}
