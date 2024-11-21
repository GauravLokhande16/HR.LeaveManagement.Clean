﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using Microsoft.VisualBasic;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, 
            ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);
            }

            // Get Leave type for allocations
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            // Get Employees

            // Get Period

            // Assign allocations
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}
