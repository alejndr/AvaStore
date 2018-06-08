namespace AvaStore.Models
{

    /// <summary>
    /// Enum for the SaleType property.
    /// </summary>
    public enum SaleType
    {
        All, Online, Physical
    }

    /// <summary>
    /// Product class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Nullable price. 
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Saletype, only admits: Online, Physical or All. By default its set to All.
        /// </summary>
        public SaleType SaleType
        { get; set; }

    }
}
