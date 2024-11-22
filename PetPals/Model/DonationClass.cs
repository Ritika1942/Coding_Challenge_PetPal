using System;

namespace PetPals.Model
{
    public abstract class DonationClass
    {
        public string DonorName { get; set; }
        public decimal? Amount { get; set; }
        public string DonationType { get; set; }
        public string DonationItem { get; set; }
        public DateTime DonationDate { get; set; }

        public DonationClass(string donorName, decimal? amount, string donationType, string donationItem, DateTime donationDate)
        {
            DonorName = donorName;
            Amount = amount;
            DonationType = donationType;
            DonationItem = donationItem;
            DonationDate = donationDate;
        }

        public abstract void RecordDonation();
    }
}
