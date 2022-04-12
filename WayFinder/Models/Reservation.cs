using System;

namespace WayFinder.Models
{
    public class Reservation : Virtual<int>
    {
        public new int Id { get; set; }
        public int TripId { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string ConfirmationNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public new DateTime CreatedAt { get; set; }
        public new DateTime UpdatedAt { get; set; }



    }



}