using AvaStore.BL;
using AvaStore.Functions;
using AvaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            // f.e.: AvaFunctions funcs = new AvaFunctions();

            // TODO: 00. Implement some tests (please, structure them! Create new methods and classes for tests)



            // f.e.: StoreBL storeBl = new StoreBL();

            // TODO: 00. Implement some tests (please, structure them! Create new methods and classes for tests)
            
            SearchIdTest();

            SumPricesTest();

            ShowAllItemsTest();

            AddPendriveTest();

            ExistsPendriveTest();

            CalculateTotalPriceTest();

            ShowAllProductsTest();

            Console.ReadLine();

        }
        
       

        /// <summary>
        /// Test of the SearchId function
        /// </summary>
        static public void SearchIdTest()
        {
            AvaFunctions funcs = new AvaFunctions();
            List<string> idList = new List<string>();
            idList.Add("1");
            idList.Add("2");
            idList.Add("3");
            idList.Add("4");
            idList.Add("5");
            idList.Add("6");
            idList.Add("7");


            if (funcs.SearchId(idList, "3"))
            {
                Console.WriteLine("Encontrado");
            }
            else
            {
                Console.WriteLine("No encontrado");
            }

        }

        /// <summary>
        /// Test of the SumPrices function
        /// </summary>
        static public void SumPricesTest()
        {
            AvaFunctions funcs = new AvaFunctions();
            List<decimal> prices = new List<decimal>();
            prices.Add(7);
            prices.Add(8);
            prices.Add(3);
            prices.Add(4);
            prices.Add(2);
            prices.Add(6);
            
            Console.WriteLine(funcs.SumPrices(prices));
            
        }

        /// <summary>
        /// Test of the ShowAllItemsTest function
        /// </summary>
        static public void ShowAllItemsTest()
        {
            AvaFunctions funcs = new AvaFunctions();
            List<Item> itemList = new List<Item>();

            Item item1 = new Item();
            item1.ID = "1";
            item1.Price = 34;

            Item item2 = new Item();
            item2.ID = "2";
            item2.Price = 15;

            Item item3 = new Item();
            item3.ID = "3";
            item3.Price = 19;

            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);

            Console.WriteLine(funcs.ShowAllItems(itemList));
            
        }

        /// <summary>
        /// Test of the AddPenDrive function
        /// </summary>
        static public void AddPendriveTest()
        {
            StoreBL storeBL = new StoreBL();
            Store store = new Store();
            
            store.Name = "PenStore1";
            store.ID = "1";
            
            PenDrive pendrive1 = new PenDrive();

            if (storeBL.AddPenDrive(store, pendrive1))
            {
                Console.WriteLine("Pendrive added.");
            }
            else
            {
                Console.WriteLine("There was a problem adding the pendrive.");
            }

            storeBL.AddPenDrive(store, pendrive1);
        }

        /// <summary>
        /// Test of the ExistsPendriveTest function
        /// </summary>
        static public void ExistsPendriveTest()
        {
            StoreBL storeBL = new StoreBL();
            Store store = new Store();

            store.Name = "PenStore1";
            store.ID = "1";

            PenDrive pendrive1 = new PenDrive();
            pendrive1.Brand = "brand1";
            pendrive1.Model = "model1";
            PenDrive pendrive2 = new PenDrive();
            PenDrive pendrive3 = new PenDrive();

            storeBL.AddPenDrive(store, pendrive1);
            storeBL.AddPenDrive(store, pendrive2);
            storeBL.AddPenDrive(store, pendrive3);

            if (storeBL.ExistPenDrive(store, "brand1", "model"))
            {
                Console.WriteLine("The pen exist");

            }
            else
            {
                Console.WriteLine("The pen doesn't exist");
            }


        }

        /// <summary>
        /// Test of the CalculateTotalPriceTest function.
        /// </summary>
        static public void CalculateTotalPriceTest()
        {
            StoreBL storeBL = new StoreBL();
            Store store = new Store();

            decimal? sum = 0;

            store.Name = "PenStore1";
            store.ID = "1";

            PenDrive pendrive1 = new PenDrive();
            pendrive1.Brand = "brand1";
            pendrive1.Model = "model1";
            pendrive1.Price = 34;
            PenDrive pendrive2 = new PenDrive();
            pendrive2.Brand = "Brand2";
            pendrive2.Price = 26;
            PenDrive pendrive3 = new PenDrive();
            pendrive3.Brand = "Brand3";
            pendrive3.Price = 40;
            PenDrive pendrive4 = new PenDrive();
            pendrive4.Brand = "Brand4";
            pendrive4.Price = 76;

            storeBL.AddPenDrive(store, pendrive1);
            storeBL.AddPenDrive(store, pendrive2);
            storeBL.AddPenDrive(store, pendrive3);
            storeBL.AddPenDrive(store, pendrive4);


            if (storeBL.CalculateTotalPrice(store, store.Products.Pendrives, out sum))
            {
                Console.WriteLine("Successfully Calculated.");
            }
            else
            {
                Console.WriteLine("Not so successfully calculated.");
            }

            
            Console.WriteLine("Suma:" + sum.ToString());
            

        }

        static public void ShowAllProductsTest()
        {
            StoreBL storeBL = new StoreBL();
            Store store = new Store();

            PenDrive pen1 = new PenDrive();
            pen1.Memory = 500;
            pen1.Model = "Kingston";
            pen1.Price = 20;

            PenDrive pen2 = new PenDrive();
            pen2.Memory = 300;
            pen2.Model = "HP";
            pen2.Price = 17;

            Phone pho1 = new Phone();
            pho1.Inches = 30;
            pho1.Model = "HP";
            pho1.Price = 17;

            Phone pho2 = new Phone();
            pho2.Inches = 30;
            pho2.Model = "HP";
            pho2.Price = 17;

            Refrigerator ref1 = new Refrigerator();
            ref1.Brand = "Samsung";
            ref1.Capacity = 50;
            ref1.Price = 430;

            Refrigerator ref2 = new Refrigerator();
            ref2.Brand = "Fujitsu";
            ref2.Capacity = 100;
            ref2.Price = 600;

            store.Products.Pendrives.Add(pen1);
            store.Products.Pendrives.Add(pen2);
            store.Products.Phones.Add(pho1);
            store.Products.Phones.Add(pho1);
            store.Products.Refrigerators.Add(ref1);
            store.Products.Refrigerators.Add(ref2);


            Console.WriteLine(storeBL.ShowAllProducts(store));
        }



    }
}



