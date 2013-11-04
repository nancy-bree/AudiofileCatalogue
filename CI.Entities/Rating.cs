using System.ComponentModel.DataAnnotations;

namespace CI.Entities
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public int AudiofileID { get; set; }
        public int UserID { get; set; }
        public byte Vote { get; set; }
    }
}