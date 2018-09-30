using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCSPCS.DAL.Entities
{
    public class TotalProject
    {
        private List<CartLine> lineCollections = new List<CartLine>();
        public void AddItem(Product product, int quntity)
        {
            CartLine line = lineCollections
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollections.Add(new CartLine
                {
                    Product = product,
                    Quntity = quntity
                });
            }
            else
            {
                line.Quntity += quntity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollections.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollections.Sum(e => e.Product.Price * e.Quntity);
        }

        public void Clear()
        {
            lineCollections.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollections; }
        }
    }
}
