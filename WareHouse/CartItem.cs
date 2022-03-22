using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse
{
    public class CartItem
    {
        public List<Product> products;

        public CartItem()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].code == product.code)
                {
                    return;
                }
            }
            products.Add(product);
        }

        public void DeleteProductFromCart(string code)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].code == code)
                {
                    products.RemoveAt(i);
                    return;
                }
            }
        }

        public void DeleteProductFromCartOnName(string name)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].name == name)
                {
                    products.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
