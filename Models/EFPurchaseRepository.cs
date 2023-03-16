using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Models
{
    public class EFPurchaseRepository : PurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Purchase> Purchase => context.Books.Include(x => x.Lines);

        public void SavePurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
