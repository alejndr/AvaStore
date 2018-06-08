using System.Collections.Generic;
using System.Linq;

namespace AvaStore.Models
{
    /// <summary>
    /// Products class.
    /// </summary>
    public class Products
    {

        public Products()
        {
            Pendrives = new List<PenDrive>();
            Phones = new List<Phone>();
            Refrigerators = new List<Refrigerator>();

        }

        /// <summary>
        /// Pendrives.
        /// </summary>
        public List<PenDrive> Pendrives
        { get; set; }

        /// <summary>
        /// Phones.
        /// </summary>
        public List<Phone> Phones
        { get; set; }

        /// <summary>
        /// Refrigerators.
        /// </summary>
        public List<Refrigerator> Refrigerators
        { get; set; }

        /// <summary>
        /// Total products available
        /// </summary>
        public int TotalProducts
        {
            get
            {
                return TotalProducts;
            }

            set
            {
                TotalProducts = Pendrives.Count + Phones.Count + Refrigerators.Count;
            }
        }

        /// <summary>
        /// Total of the products available online.
        /// </summary>
        public int TotalOnlineProducts
        {
            get
            {
                return TotalOnlineProducts;
            }

            set
            {
                TotalOnlineProducts = GetTotalOnlineProducts(Pendrives, Phones, Refrigerators);
            }
        }

        /// <summary>
        /// Get the total of the products available online.
        /// </summary>
        /// <param name="Pendrives"></param>
        /// <param name="Phones"></param>
        /// <param name="Refrigerators"></param>
        /// <returns></returns>
        private int GetTotalOnlineProducts(List<PenDrive> Pendrives, List<Phone> Phones, List<Refrigerator> Refrigerators)
        {
            var pendriveQuery = Pendrives.Where(pen => pen.SaleType == SaleType.Online);

            var phonesQuery = Phones.Where(pho => pho.SaleType == SaleType.Online);

            var RefrigeratorsQuery = Refrigerators.Where(refr => refr.SaleType == SaleType.Online);

            int TotalOnline = pendriveQuery.Count() + phonesQuery.Count() + RefrigeratorsQuery.Count();

            return TotalOnline;
        }

    }
}
