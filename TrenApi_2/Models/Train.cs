namespace TrenApi_2.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Carriage> Carriages { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }

}
