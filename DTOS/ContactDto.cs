using System;
using System.Collections.Generic;

namespace SYSMCLTD_API.DTOS
{
    public class ContactDto : BaseEntityDto
    {
        public string FullName { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public int? CustomerId { get; set; }        
    }
}
