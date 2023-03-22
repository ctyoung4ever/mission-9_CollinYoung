using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Models
{
    public interface PurchaseRepository
    {
        IQueryable<Purchase> Purchase { get; }
        public void SavePurchase(Purchase purchase);
    }
}
