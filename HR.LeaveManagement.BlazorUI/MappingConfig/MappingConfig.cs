using HR.LeaveManagement.BlazorUI.Models.LeaveTypes;
using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;
using MyNamespace;

namespace HR.LeaveManagement.BlazorUI.MappingConfig
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
