using System;
using System.Collections.Generic;

namespace SYSMCLTD_API.DTOS
{
    public partial class CustomerDto : BaseEntityDto
    {
        public CustomerDto()
        {
            //Addresses = new HashSet<AddressDto>();
            //Contacts = new HashSet<ContactDto>();
        }
        public string Name { get; set; }
        public long CustomerNumber { get; set; }

        public IEnumerable<AddressDto> Addresses { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
    }
}
