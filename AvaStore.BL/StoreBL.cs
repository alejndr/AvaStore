using AvaStore.BL.Interfaces;
using AvaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AvaStore.BL
{

    public class StoreBL : IStoreBL
    {
        // TODO: 11. This class must implement the IStore interface (Interfaces.IStoreBL).
        //           Methods must be implemented by priority:
        //          
        //           bool AddPenDrive(Store store, PenDrive penDrive);
        //           bool ExistPenDrive(Store store, string brand, string model);
        //           bool ExistPenDrive(Store store, PenDrive penDrive);
        //           string ShowAllProducts(Store store);
        //           IEnumerable<Product> GetAllProducts(Store store);
        //           bool CalculateTotalPrice(Store store, List<PenDrive> penDrives, out decimal? total);
        //           bool CalculateTotalPrice(Store store, List<Phone> phones, out decimal? total);
        //           bool CalculateTotalPrice(Store store, List<Refrigerator> refrigerators, out decimal? total);
        //           bool CalculateTotalPrice(Store store, List<Product> items, out decimal? total);
        //           bool CalculateTotalPrice<T>(Store store, List<T> items, out decimal? total);

        /// <summary>
        /// Add a pen drive to the store products.
        /// </summary>
        /// <remarks>
        /// No duplicity allowed (in order to brand and model). This method validates it.
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="penDrive">Pen drive.</param>
        /// <returns>True if the item was added.</returns>
        public bool AddPenDrive(Store store, PenDrive penDrive)
        {
            bool added = false;

            if (!ExistPenDrive(store, penDrive.Brand, penDrive.Model))
            {
                store.Products.Pendrives.Add(penDrive);
                added = true;
            }

            return added;

        }

        /// <summary>
        /// Validate if a pen drive exists in the store (in order to brand and model).
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="brand">Brand.</param>
        /// <param name="model">Model.</param>
        /// <returns>True if the item already exists.</returns>
        public bool ExistPenDrive(Store store, string brand, string model)
        {
            bool exists = false;

            if (store != null)
            {

                var brandQuery = store.Products.Pendrives.Where(pen => pen.Brand == brand);

                var modelQuery = store.Products.Pendrives.Where(pen => pen.Model == model);

                if (brandQuery.Count() > 0 && modelQuery.Count() > 0)
                {
                    exists = true;
                }
            }

            return exists;
        }


        /// <summary>
        /// Validate if a pen drive exists in the store (in order to brand and model).
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="penDrive">Pen drive.</param>
        /// <returns>True if the item already exists.</returns>
        public bool ExistPenDrive(Store store, PenDrive penDrive)
        {
            bool exists = false;

            if (store != null && penDrive != null)
            {

                var brandQuery = store.Products.Pendrives.Where(pen => pen.Brand == penDrive.Brand);

                var modelQuery = store.Products.Pendrives.Where(pen => pen.Model == penDrive.Model);

                if (brandQuery.Count() > 0 && modelQuery.Count() > 0)
                {
                    exists = true;
                }

            }

            return exists;
        }


        /// <summary>
        /// Calculate total price of the items. 
        /// </summary>
        /// <remarks>
        /// Only if all of them have prices (null in other case).
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="penDrives">Pen drive list.</param>
        /// <param name="total">Total price of the items.</param>
        /// <returns>True if total price can be calculated.</returns>
        public bool CalculateTotalPrice(Store store, List<PenDrive> penDrives, out decimal? total)
        {
            bool calculated = false;
            total = 0;
            
            if (store != null)
            {
                if (store.Products.Pendrives == penDrives)
                {

                    var nullCounter = penDrives.Where(nll => nll.Price == null);

                    if (nullCounter.Count() == 0)
                    {
                        total = penDrives.Sum(su => su.Price);
                        calculated = true;
                    }
                    else
                    {
                        total = null;
                    }
                    
                }
            }

            return calculated;
        }


        /// <summary>
        /// Calculate total price of the items. 
        /// </summary>
        /// <remarks>
        /// Only if all of them have prices (null in other case).
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="phones">Phone list.</param>
        /// <param name="total">Total price of the items.</param>
        /// <returns>True if total price can be calculated.</returns>
        public bool CalculateTotalPrice(Store store, List<Phone> phones, out decimal? total)
        {
            bool calculated = false;
            total = 0;
            
            if (store != null)
            {
                if (store.Products.Phones == phones)
                {

                    var nullCounter = phones.Where(nll => nll.Price == null);

                    if (nullCounter.Count() == 0)
                    {
                        total = phones.Sum(su => su.Price);
                        calculated = true;
                    }
                    else
                    {
                        total = null;
                    }

                }
            }

            return calculated;
        }
        

        /// <summary>
        /// Calculate total price of the items. 
        /// </summary>
        /// <remarks>
        /// Only if all of them have prices (null in other case).
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="refrigerators">Refrigerators list.</param>
        /// <param name="total">Total price of the items.</param>
        /// <returns>True if total price can be calculated.</returns>
        public bool CalculateTotalPrice(Store store, List<Refrigerator> refrigerators, out decimal? total)
        {
            bool calculated = false;
            total = 0;
            
            if (store != null)
            {
                if (store.Products.Refrigerators == refrigerators)
                {
                    // Check if there are any null price
                    var nullCounter = refrigerators.Where(nll => nll.Price == null);

                    if (nullCounter.Count() == 0)
                    {
                        total = refrigerators.Sum(su => su.Price);
                        calculated = true;
                    }
                    else
                    {
                        total = null;
                    }

                }
            }

            return calculated;
        }


        /// <summary>
        /// Calculate total price of the items. 
        /// </summary>
        /// <remarks>
        /// Only if all of them have prices (null in other case).
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="items">Item list.</param>
        /// <param name="total">Total price of the items.</param>
        /// <returns>True if total price can be calculated.</returns>
        public bool CalculateTotalPrice<T>(Store store, List<T> items, out decimal? total)
        {
            bool calculated = false;
            total = 0;

            if (store.Products.Pendrives.GetType() == items.GetType() || store.Products.Refrigerators.GetType() == items.GetType() || store.Products.Phones.GetType() == items.GetType())
            {
                var nullCounter = items.Where(nll => nll.GetType().GetProperty("Price").GetValue(nll) == null);

                if (nullCounter.Count() == 0)
                {
                    total = items.Sum(p => (decimal?)p.GetType().GetProperty("Price").GetValue(p));
                    calculated = true;
                }
                else
                {
                    total = null;
                }

            }

            return calculated;
        }
        

        /// <summary>
        /// Calculate total price of the items. 
        /// </summary>
        /// <remarks>
        /// Only if all of them have prices (null in other case).
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="items">Item list.</param>
        /// <param name="total">Total price of the items.</param>
        /// <returns>True if total price can be calculated.</returns>
        public bool CalculateTotalPrice(Store store, List<Product> items, out decimal? total)
        {
            bool calculated = false;
            total = 0;


            var nullCounter = items.Where(nll => nll.Price == null);

            if (nullCounter.Count() == 0)
            {
                total = items.Sum(su => su.Price);
                calculated = true;
            }
            else
            {
                total = null;
            }
            
            return calculated;
        }
        

        /// <summary>
        /// Show all products.
        /// </summary>
        /// <remarks>
        /// Get a string with all products. For each product, all its properties
        /// will be shown. 
        /// If a item has neither ID nor price, the item will not be shown.
        /// If a item only has one of its properties filled, it will be shown and the null property
        /// will be shown as empty.
        /// For example: 
        /// Prop1: val1 | Prop2: val2 | Prop... 
        /// PropN: valN | PropN: valN | Prop... 
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <returns>String with all products and its properties.</returns>
        public string ShowAllProducts(Store store)
        {
            StringBuilder sb = new StringBuilder();
            int penCount = 1;
            int phoneCount = 1;
            int refrigeCount = 1;

            if (store.Products.Pendrives.Count > 0)
            {
                foreach (PenDrive item in store.Products.Pendrives)
                {
                    
                    if (item.Brand != null)
                    {
                        sb.AppendFormat("Pendrive: {0} | Brand: {1}", penCount, item.Brand);
                    }
                    else
                    {
                        sb.AppendFormat("Pendrive: {0} | Brand: X", penCount);
                    }

                    if (item.Model != null)
                    {
                        sb.AppendFormat(" | Model: {0}", item.Model);
                    }
                    else
                    {
                        sb.AppendFormat(" | Model: X");
                    }

                    sb.AppendFormat(" | Memory: {0}", item.Memory);

                    if (item.Price != null)
                    {
                        sb.AppendFormat(" | Price: {0}", item.Price);
                    }
                    else
                    {
                        sb.AppendFormat(" | Price: X");
                    }

                    sb.AppendFormat(" | Sale type: {0}", item.SaleType);
                    sb.AppendLine();
                    penCount++;
                    
                }
                sb.AppendLine();

            }

            if (store.Products.Phones.Count > 0)
            {
                foreach (Phone item in store.Products.Phones)
                {

                    if (item.Brand != null)
                    {
                        sb.AppendFormat("Phone: {0} | Brand: {1}", phoneCount, item.Brand, -200);
                    }
                    else
                    {
                        sb.AppendFormat("Phone: {0} | Brand: X", phoneCount);
                    }

                    if (item.Model != null)
                    {
                        sb.AppendFormat(" | Model: {0}", item.Model);
                    }
                    else
                    {
                        sb.AppendFormat(" | Model: X");
                    }

                    sb.AppendFormat(" | Inches: {0}", item.Inches);

                    if (item.Price != null)
                    {
                        sb.AppendFormat(" | Price: {0}", item.Price);
                    }
                    else
                    {
                        sb.AppendFormat(" | Price: X");
                    }

                    sb.AppendFormat(" | Sale type: {0}", item.SaleType.ToString());
                    sb.AppendLine();
                    phoneCount++;

                }
                sb.AppendLine();
            }

            if (store.Products.Refrigerators.Count > 0)
            {
                foreach (Refrigerator item in store.Products.Refrigerators)
                {

                    if (item.Brand != null)
                    {
                        sb.AppendFormat("Refrigerator: {0} | Brand: {1}", refrigeCount, item.Brand);
                    }
                    else
                    {
                        sb.AppendFormat("Refrigerator: {0} | Brand: X", refrigeCount);
                    }

                    if (item.Model != null)
                    {
                        sb.AppendFormat(" | Model: {0}", item.Model);
                    }
                    else
                    {
                        sb.AppendFormat(" | Model: X");
                    }

                    sb.AppendFormat(" | Capacity: {0}", item.Capacity);

                    if (item.Price != null)
                    {
                        sb.AppendFormat(" | Price: {0}", item.Price);
                    }
                    else
                    {
                        sb.AppendFormat(" | Price: X");
                    }

                    sb.AppendFormat(" | Sale type: {0}", item.SaleType.ToString());
                    sb.AppendLine();
                    refrigeCount++;

                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <returns>Return all products in a list.</returns>
        public IEnumerable<Product> GetAllProducts(Store store)
        {
            IEnumerable<Product> list;
            
            list = store.Products.Pendrives;
            
            list = store.Products.Phones;
            
            list = store.Products.Phones;
            
            return list;
        }
    }

}

