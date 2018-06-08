namespace AvaStore.Models
{

    /// <summary>
    /// Store.
    /// </summary>
    public class Store
    {

        public Store()
        {
            Products = new Products();
        }

        /// <summary>
        /// ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Products.
        /// </summary>
        public Products Products { get; set; }
       
    }
}
