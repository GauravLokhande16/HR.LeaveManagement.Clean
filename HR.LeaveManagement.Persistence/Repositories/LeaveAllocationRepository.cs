﻿using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
        public class LeaveAllocationRepository : GenericReository<LeaveAllocation>, ILeaveAllocationRepository
        {
            public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
            {
            }

            public async Task AddAllocation(List<LeaveAllocation> allocations)
            {
                await _context.AddRangeAsync(allocations);
            }

            public async Task<bool> AllocationExist(string userId, int leaveTypeId, int period)
            {
                return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                                  && q.LeaveTypeId == leaveTypeId
                                                  && q.Period == period);
            }
            public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
            {
                var leaveAllocations = await _context.LeaveAllocations
                                        .Include(q => q.LeaveType)
                                        .ToListAsync();

                return leaveAllocations;
            }
            public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
            {
                var leaveAlloations = await _context.LeaveAllocations
                                            .Where(q => q.EmployeeId == userId)
                                            .Include(q => q.LeaveTypeId)
                                            .ToListAsync();
                return leaveAlloations;
            }

            public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
            {
                var leaveAllocation = await _context.LeaveAllocations
                            .Include (q => q.LeaveType)
                            .FirstOrDefaultAsync(q => q.Id == id);
               
                return leaveAllocation;
            }

            public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
            {
                return await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                                    && q.LeaveTypeId == leaveTypeId);
                    
            }
        }
}