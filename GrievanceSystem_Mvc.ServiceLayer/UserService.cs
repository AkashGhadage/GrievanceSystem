using System.Collections.Generic;
using System.Linq;
using GrievanceSystem_Mvc.ViewModels;
using GrievanceSystem_Mvc.DomainModels;
using GrievanceSystem_Mvc.Repositories;
using AutoMapper;

namespace GrievanceSystem_Mvc.ServiceLayer
{
    public class UserService : IUserService
    {

        //repository  ref

        //code that map viewmodel and domain model class matching properties 
        // if we want to get data from database we need to convevert domain model into view model 
        // nd if we want to put data into database then we need to convert viewmodel into domainmodel

        //repo ref we need repo methods to acces data from database

        readonly IUserRepository ur;

        //constructor
        public UserService()
        {
            ur = new UserRepository(); //actual class creation
        }

        public int InsertUser(RegisterViewModel user)
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<RegisterViewModel, User>();
                    cfg.CreateMap<RegisterViewModel, Email>().ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress));
                    cfg.IgnoreUnmapped();
                }
                );
            IMapper mapper = config.CreateMapper();
            User us = mapper.Map<RegisterViewModel, User>(user); //AutoMapper.AutoMapperMappingException: 'Error mapping types 22 1 21 
            us.Email = mapper.Map<RegisterViewModel, Email>(user);
            us.PasswordHash = Helper.GenerateHash(user.Password);
            int affectedRows = ur.InsertUser(us);
            return affectedRows;


        }

        public int UpdateUserDetails(EditUserViewModel user)
        {
            //var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserViewModel, User>(); cfg.IgnoreUnmapped(); });

            var config = new MapperConfiguration(
               cfg =>
               {
                   cfg.CreateMap<EditUserViewModel, User>();
                   cfg.CreateMap<EditUserViewModel, Email>().ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.EmailAddress));
                   cfg.IgnoreUnmapped();
               }
               );

            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserViewModel, User>(user);
            u.Email = mapper.Map<EditUserViewModel, Email>(user);
            int affectedRows = ur.UpdateUserDetails(u);
            return affectedRows;

        }

        public int UpdateUserPassword(EditUserPasswordViewModel user)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserPasswordViewModel, User>(user);
            u.PasswordHash = Helper.GenerateHash(user.Password);
            int affectedRows = ur.UpdateUserPassword(u);
            return affectedRows;
        }

        public int DeleteUser(int userId)
        {
            int affectedRows = ur.DeleteUser(userId);
            return affectedRows;
        }

        public List<UserViewModel> GetUser()

        {
            List<User> user = ur.GetUser(); //get data from repository 
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> userViewModels = mapper.Map<List<User>, List<UserViewModel>>(user);
            return userViewModels;
        }

        public UserViewModel GetUserByEmail(string emailAddress)
        {
            User user = ur.GetUserByEmail(emailAddress).FirstOrDefault();
            UserViewModel userViewModel = null;
            if (user != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                userViewModel = mapper.Map<User, UserViewModel>(user);
            }

            return userViewModel;

        }

        public UserViewModel GetUserByEmailAndPassword(string emailAddress, string password)
        {
            // here we need to convert original password into hash and then compare with saved password and then authenticate user 
            // if no matching user is found then we get null so we need check here 

            User user = ur.GetUserByEmailAndPassword(Email: emailAddress, Password: Helper.GenerateHash(password)).FirstOrDefault();
            UserViewModel userViewModel = null;
            if (user != null)
            {
                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });

                var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>().ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.Email.EmailAddress))
                    .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role.RoleName));
                    cfg.IgnoreUnmapped();
                }
                );
                IMapper mapper = config.CreateMapper();
                userViewModel = mapper.Map<User, UserViewModel>(user);

            }
            return userViewModel;
        }

        public UserViewModel GetUserByUserID(int userId)
        {
            User user = ur.GetUserByUserID(userId).FirstOrDefault();

            UserViewModel userViewModel = null;
            if (user != null)
            {
                var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.CreateMap<User, UserViewModel>().ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.Email.EmailAddress));
                    cfg.IgnoreUnmapped();
                }
                );

                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();

                userViewModel = mapper.Map<User, UserViewModel>(user);

            }

            return userViewModel;
        }

        public List<UserViewModel> GetUsersByRoleId(int roleId)
        {
            List<User> user = ur.GetUsersByRoleId(roleId);

            List<UserViewModel> userViewModels = null;
            if (user != null)
            {
                var config = new MapperConfiguration(
               cfg =>
               {
                   cfg.CreateMap<User, UserViewModel>();
                   cfg.CreateMap<User, UserViewModel>()
                   .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.Email.EmailAddress))
                   .ForMember(d => d.Role, opt => opt.MapFrom(src => src.Role.RoleName));
                   cfg.IgnoreUnmapped();
               }
               );


                //var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                userViewModels = mapper.Map<List<User>, List<UserViewModel>>(user);

            }

            return userViewModels;


        }

        public string[] GetRolesForUser(string username)
        {
            string[] roles = ur.GetRolesForUser(username);
            return ur.GetRolesForUser(username);
        }
    }
}
