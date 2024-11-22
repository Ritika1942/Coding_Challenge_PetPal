namespace PetPals.Model
{
    public abstract class Donation
    {
        private int _donationID;
        private string? _donorName;
        private string? _donationType;
        private decimal? _donationAmount;
        private string? _donationItem;
        private DateTime _donationDate;
        public int DonationID
        {
            get { return _donationID; }
            set { _donationID = value; }
        }
        public string? DonorName
        {
            get { return _donorName; }
            set { _donorName = value; }
        }
        public string? DonationType
        {
            get { return _donationType; }
            set { _donationType = value; }
        }
        public decimal? DonationAmount
        {
            get { return _donationAmount; }
            set { _donationAmount = value; }
        }
        public string? DonationItem
        {
            get { return _donationItem; }
            set { _donationItem = value; }
        }
        public DateTime DonationDate
        {
            get { return _donationDate; }
            set { _donationDate = value; }
        }
        public abstract void RecordDonation();
        public override string ToString()
        {
            return $"Donation ID: {DonationID}, " +
                   $"Donor Name: {(string.IsNullOrEmpty(DonorName) ? "Not Provided" : DonorName)}, " +
                   $"Donation Type: {(string.IsNullOrEmpty(DonationType) ? "Not Provided" : DonationType)}, " +
                   $"Donation Amount: {(DonationAmount.HasValue ? DonationAmount.Value.ToString("C") : "Not Provided")}, " +
                   $"Donation Item: {(string.IsNullOrEmpty(DonationItem) ? "Not Provided" : DonationItem)}, " +
                   $"Donation Date: {DonationDate.ToString("yyyy-MM-dd")}";
        }
    }

    public class CashDonation : Donation
    {
        public CashDonation(string donorName, decimal donationAmount, DateTime donationDate)
        {
            DonorName = donorName;
            DonationAmount = donationAmount;
            DonationDate = donationDate;
            DonationType = "Cash";
        }
        public override void RecordDonation()
        {
            Console.WriteLine($"Recording cash donation: {ToString()}");
        }
    }
    public class ItemDonation : Donation
    {
        public ItemDonation(string donorName, string donationItem, DateTime donationDate)
        {
            DonorName = donorName;
            DonationItem = donationItem;
            DonationDate = donationDate;
            DonationType = "Item";
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Recording item donation: {ToString()}");
        }
    }
}
