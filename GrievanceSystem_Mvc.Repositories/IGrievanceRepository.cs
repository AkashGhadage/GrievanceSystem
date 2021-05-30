using System.Collections.Generic;
using GrievanceSystem_Mvc.DomainModels;

namespace GrievanceSystem_Mvc.Repositories
{
    public interface IGrievanceRepository
    {

        int InsertGrievanceDetails(Grievance grievance);
       
        int UpdateGrievanceDetails(Grievance grievance);
      
        int DeleteGrievance(int grievanceID);
      
        List<Grievance> GetGrievance(); // to fetch all users

        List<Grievance> GetGrievanceByUserId(int userId); //to get grievance by  user  id 
      
        List<Grievance> GetGrievanceByGrievanceId(int grievanceId); //to get grievance by  grievance  id 
       
        List<Grievance> GetGrievancesByStatusId(int statusId);
    }
}
