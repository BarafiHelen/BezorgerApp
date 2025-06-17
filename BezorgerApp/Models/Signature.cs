using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BezorgerApp.Models
{
    public class Signature
    {
        public string Base64Image { get; set; } // getekende handtekening als string
        public DateTime SignedAt { get; set; }
        public string SignedBy { get; set; }
    }
}
