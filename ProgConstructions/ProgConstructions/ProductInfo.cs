using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class ProductInfo
    {
        public static ProductInfo[] GetStore() {
            var items = new[] {
                new ProductInfo {Name = "Mac's coffee", Description = "Coffee with TEETH", NumberInStock = 24},
                new ProductInfo {Name = "Milky coffee", Description = "Coffee with milk", NumberInStock = 100},
                new ProductInfo {Name = "Pure silk tofu", Description = "Bland as possible", NumberInStock = 120},
                new ProductInfo {Name = "Cruchy pops", Description = "Chees and papper", NumberInStock = 2},
                new ProductInfo {Name = "RipOff water", Description = "From the tap of your wallet", NumberInStock = 100},
                new ProductInfo {Name = "Classic Valpo Pizza", Description = "With pizza =)", NumberInStock = 73}
            };
            return items;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberInStock { get; set; }

        public override string ToString() {
            return $" Name = {Name}, Description = {Description}, Number in stock = {NumberInStock} ";
        }
    }
}
