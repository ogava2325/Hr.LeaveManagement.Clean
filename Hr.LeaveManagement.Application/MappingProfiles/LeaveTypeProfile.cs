using AutoMapper;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using Hr.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Hr.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using Hr.LeaveManagement.Domain.Entities;

namespace Hr.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}