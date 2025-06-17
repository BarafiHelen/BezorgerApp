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
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime PlannedTime { get; set; }
        public Location Location { get; set; }
        public string PhotoUrl { get; set; }
        public string SignatureUrl { get; set; }
    }
}
