using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezorgerApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public string CustomerName => Customer?.Name ?? "(Onbekend)";
        public string Address => Customer?.Address ?? "(Geen adres)";

        public string Status { get; set; }    // "Gepland", "Onderweg", "Geleverd", etc.
        public DateTime PlannedTime { get; set; }
       
        public Location Location { get; set; }
        public string PhotoUrl { get; set; }
        public string SignatureUrl { get; set; }

        public bool DeliverySucceeded { get; set; } // Succesvolle levering?
        public DateTime? DeliveredAt { get; set; } // Levertijd

        public Customer Customer { get; set; } // ← Ontvangen van API
    }
}
