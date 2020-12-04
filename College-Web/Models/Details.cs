using System.Collections.Generic;

namespace College_Web.Models
{
    public class Details
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();
    }
}
