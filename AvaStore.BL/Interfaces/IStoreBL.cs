using AvaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaStore.BL.Interfaces
{
    /// <summary>
    /// Store interface.
    /// </summary>
    public interface IStoreBL
    {
        /// <summary>
        /// Add a pen drive to the store products.
        /// </summary>
        /// <remarks>
        /// No duplicity allowed (in order to brand and model). This method validates it.
        /// </remarks>
        /// <param name="store">Store.</param>
        /// <param name="penDrive">Pen drive.</param>
        /// <returns>True if the item was added.</returns>
        bool AddPenDrive(Store store, PenDrive penDrive);

        /// <summary>
        /// Validate if a pen drive exists in the store (in order to brand and model).
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="brand">Brand.</param>
        /// <param name="model">Model.</param>
        /// <returns>True if the item already exists.</returns>
        bool ExistPenDrive(Store store, string brand, string model);

        /// <summary>
        /// Validate if a pen drive exists in the store (in order to brand and model).
        /// </summary>
        /// <param name="store">Store.</param>
        /// <param name="penDrive">Pen drive.</param>
        /// <returns>True if the item already exists.</returns>
        bool ExistPenDrive(Store store, PenDrive penDrive);

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
        bool CalculateTotalPrice(Store store, List<PenDrive> penDrives, out decimal? total);

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
        bool CalculateTotalPrice(Store store, List<Phone> phones, out decimal? total);

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
        bool CalculateTotalPrice(Store store, List<Refrigerator> refrigerators, out decimal? total);

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
        bool CalculateTotalPrice<T>(Store store, List<T> items, out decimal? total);

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
        bool CalculateTotalPrice(Store store, List<Product> items, out decimal? total);

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
        string ShowAllProducts(Store store);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="store">Store.</param>
        /// <returns>Return all products in a list.</returns>
        IEnumerable<Product> GetAllProducts(Store store);
    }
}
