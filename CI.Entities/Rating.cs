using System.ComponentModel.DataAnnotations;

namespace CI.Entities
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }

        public int AudiofileID { get; set; }

        public int UserID { get; set; }

        public virtual Audiofile Audiofile { get; set; }

        public virtual User User { get; set; }
    }
}