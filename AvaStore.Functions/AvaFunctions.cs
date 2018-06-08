using System.Collections.Generic;
using System.Text;

namespace AvaStore.Functions
{
    /// <summary>
    /// Some functions.
    /// </summary>
    public class AvaFunctions
    {
        /// <summary>
        /// Validate if a ID exist in a list of IDs.
        /// </summary>
        /// <remarks>
        /// Assumption: The string empty value can be a list value, but no null values are allowed.
        /// </remarks>
        /// <param name="idList">ID list.</param>
        /// <param name="id">ID.</param>
        /// <returns>True if item was found.</returns>
        public bool SearchId(List<string> idList, string id)
        {

            bool containsID = false;

            try
            {

                if (idList != null && id != null)
                {
                    if (idList.Contains(id))
                    {
                        containsID = true;
                    }
                }
                
            }
            catch 
            {
                
            }

            return containsID;
        }

        /// <summary>
        /// Sum all the prices of a price list.
        /// </summary>
        /// <remarks>
        /// Assumption: All list items have a value.
        /// </remarks>
        /// <param name="priceList">Price list.</param>
        /// <returns>Sum.</returns>
        public decimal SumPrices(List<decimal> priceList)
        {
            decimal sum=0;

            try
            {
                if (priceList.Count > 0)
                {
                    foreach (decimal actual in priceList)
                    {
                        sum = sum + actual;
                    }
                }
            }
            catch
            {
                
            }

            
            
            return sum;
        }
        
        /// <summary>
        /// Sum all the prices of a item list.
        /// </summary>
        /// <remarks>
        /// Assumption: All items of the list must have a price.
        /// </remarks>
        /// <param name="itemList">Item list.</param>
        /// <returns>Prices sum</returns>
        public decimal SumPrices(List<Item> itemList)
        {
            decimal sum = 0;

            try
            {
                if (itemList.Count > 0)
                {
                    foreach (Item item in itemList)
                    {
                        sum = sum + item.Price;
                    }
                }
            }
            catch 
            {
                
            }
            
            return sum;
        }

        /// <summary>
        /// Show all items.
        /// If a item has neither ID nor price, the item will not be shown.
        /// If a item only has one of its properties filled, it will be shown and the null property
        /// will be shown as empty.
        /// </summary>
        /// <remarks>
        /// Example:
        /// ID: id1 | Price: price1
        /// ID: id2 | Price: price2
        /// ID: id3 | Price: 
        /// ID:     | Price: price4
        /// ID: idN | Price: priceN
        /// </remarks>
        /// <param name="itemList">Item list.</param>
        /// <returns>String with all items and its properties.</returns>
        public string ShowAllItems(List<Item> itemList)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                if (itemList.Count > 0 )
                {
                    foreach (Item item in itemList)
                    {
                        if (item.ID != null)
                        {
                            sb.AppendFormat("ID: {0} | Price: {1}", item.ID, item.Price);
                            sb.AppendLine();
                        }
                        else
                        {
                            sb.Append("");
                            sb.AppendLine();
                        }
                        
                    }
                }
            }
            catch 
            {
                
            }
            
            return sb.ToString();
        }
        
    }
}
