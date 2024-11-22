using System;

namespace PetPals.Model
{
    public class ItemDonation : DonationClass
    {
        public ItemDonation(string donorName, decimal? amount, string donationType, string donationItem, DateTime donationDate)
            : base(donorName, amount, donationType, donationItem, donationDate)
        {
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Item donation of {DonationItem} received from {DonorName} on {DonationDate:MM/dd/yyyy}.");
        }
    }
}
