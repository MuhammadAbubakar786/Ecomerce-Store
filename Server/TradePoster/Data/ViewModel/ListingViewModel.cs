namespace TradePoster.Data.ViewModel
{
	public class ListingViewModel
	{
		public int id { get; set; }
		public string listingTitle { get; set; }
		public string location { get; set; }
		public string description { get; set; }
		public string image { get; set; }
		public string createdDate { get; set; }
		public string expiryDate { get; set; }
		public string category { get; set; }
		public string status { get; set; }
		public string listingType { get; set; }
		public float ListRating { get; set; }
	}
}