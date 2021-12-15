using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Domain
{
    public abstract class ResponseBase<T>
    {
        public T Data { get; set; }

    }
}
