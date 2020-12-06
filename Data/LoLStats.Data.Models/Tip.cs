namespace LoLStats.Data.Models
{
    public class Tip
    {
        public string Description { get; set; }

        public virtual Champion Champion { get; set; }
    }
}
