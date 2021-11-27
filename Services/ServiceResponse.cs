using SYSMCLTD_API.DTOS;
using System.Collections.Generic;

namespace SYSMCLTD_API.Services
{
    public class ServiceResponse<T> // where T : BaseEntity,IEnumerable<BaseEntity>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;

    }
}
