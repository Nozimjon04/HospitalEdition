
namespace PharmacyEditon.Models
{
    public class Medicine
    {
        public int ID { get; set; }
        public  int Count { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }

    }
}
