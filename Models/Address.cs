using System;
using System.Collections.Generic;

namespace SYSMCLTD_API.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
