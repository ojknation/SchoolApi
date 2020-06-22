using AutoMapper;
using StudyApi.ClientModels;
using StudyApi.Models;

namespace StudyApi.Helpers

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

          CreateMap<User, UserModel>();
          CreateMap<RegisterModel, User>();
          CreateMap<UpdateUserModel, User>();
        }
       
    }
}