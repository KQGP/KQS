using System.Threading.Tasks;

public class DashboardService
{
    public async Task<DashboardSummary> GetDashboardSummaryAsync()
    {
        return await Task.Run(() =>
        {
            return new DashboardSummary
            {
                TodaySales = 1250.75m,
                MonthlySales = 28750.50m,
                LowStockCount = 8,
                ActiveCustomers = 42
            };
        });
    }
}

public class DashboardSummary
{
    public decimal TodaySales { get; set; }
    public decimal MonthlySales { get; set; }
    public int LowStockCount { get; set; }
    public int ActiveCustomers { get; set; }
}