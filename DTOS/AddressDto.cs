using System;
using System.Collections.Generic;

namespace SYSMCLTD_API.DTOS
{
    public class AddressDto : BaseEntityDto
    {           
        public string City { get; set; }
        public string Street { get; set; }
        public int? CustomerId { get; set; }        
    }
}
