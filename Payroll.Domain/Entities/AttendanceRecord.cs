public class AttendanceRecord
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }
    public required Employee Employee { get; set; }

    public DateTime WorkDate { get; set; }
    public decimal HoursWorked { get; set; }
    public decimal OvertimeHours { get; set; }
}
