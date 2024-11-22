﻿using System;

namespace PetPals.Model
{
    public class CashDonation : DonationClass
    {
        public CashDonation(string donorName, decimal? amount, string donationType, string donationItem, DateTime donationDate)
            : base(donorName, amount, donationType, donationItem, donationDate)
        {
        }

        public override void RecordDonation()
        {
            if (Amount.HasValue)
            {
                Console.WriteLine($"Cash donation of {Amount:C} received from {DonorName} for {DonationItem} on {DonationDate:MM/dd/yyyy}.");
            }
            else
            {
                Console.WriteLine($"Cash donation received from {DonorName} for {DonationItem} on {DonationDate:MM/dd/yyyy}.");
            }
        }
    }
}