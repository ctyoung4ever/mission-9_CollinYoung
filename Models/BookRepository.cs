using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Models
{
    public interface BookRepository
    {
        IQueryable<Books> Books {get;}
    }
}
