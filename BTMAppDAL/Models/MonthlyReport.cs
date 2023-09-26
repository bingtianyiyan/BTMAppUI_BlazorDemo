namespace DAL.Models
{
	public class MonthlyReport
	{
		public int Month { get; set; }
        public decimal? TotalAmount { get; set; }
        public int ProductCounts { get; set; }
	}
}
