using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace Demo.PL.helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
