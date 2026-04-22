using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public partial class RentalCar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public bool IsAvailable { get; set; }

        public RentalCar(string brand, string model, int year, decimal pricePerDay, bool isAvailable)
        {
            Brand = brand;
            Model = model;
            Year = year;
            PricePerDay = pricePerDay;
            IsAvailable = isAvailable;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "Доступен" : "Недоступен";
            return $"{Brand} {Model} ({Year}) - {PricePerDay} руб./день - {status}";
        }
    }
}
