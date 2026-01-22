namespace Payroll.Application.Interfaces.IRepository
{
    public interface IAttendanceRecordRepository
    {
        Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(Guid employeeId);
        Task AddAsync(AttendanceRecord entity);
    }
}
