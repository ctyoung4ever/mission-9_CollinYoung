using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission_9_CollinYoung.Models
{
    public class Basket
    {
        public List<BasketLineItem> Item { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book b, int qty)
        {
            BasketLineItem Line = Item.Where(p => p.Book.BookId == b.BookId)
                .FirstOrDefault();

            if (Line == null)
            {
                Item.Add(new BasketLineItem
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book b)
        {
            Item.RemoveAll(p => p.Book.BookId == b.BookId);
        }

        public virtual void ClearBasket()
        {
            Item.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Item.Sum(x => x.Quantity * x.Book.Price);
            return sum;
        }
        
    }

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
