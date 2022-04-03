namespace TrenApi_2.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Occupancy { get; set; }

        public override string ToString()
        {
            return "Vagon"+Id;
        }
    }
}
