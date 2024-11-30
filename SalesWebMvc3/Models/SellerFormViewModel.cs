namespace SalesWebMvc3.Models
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Departments> Departments { get; set; }

    }
}
