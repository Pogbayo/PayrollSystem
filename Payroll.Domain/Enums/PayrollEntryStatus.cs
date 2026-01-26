namespace Payroll.Domain.Enums
{
    public enum PayrollEntryStatus
    {
        Pending = 1,        // Created but not processed yet
        Processing = 2,     // Payment attempt started
        Paid = 3,           // Successfully paid
        Failed = 4,         // All retries exhausted
    }
}
