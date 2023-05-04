using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EntityFrameworkProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine("Ürün Adı:" + product.ProductName);
            }
        }
    }
}
