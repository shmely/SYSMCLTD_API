using System;

namespace SYSMCLTD_API.DTOS
{
    public abstract class BaseEntityDto
    {
        public int? Id { get; set; }
        public bool IsDeleted { get; set; }=false;
        public DateTime? Created { get; set; }
    }
}
