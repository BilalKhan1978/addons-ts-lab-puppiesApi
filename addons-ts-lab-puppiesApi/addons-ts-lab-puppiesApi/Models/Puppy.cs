namespace addons_ts_lab_puppiesApi.Models
{
    public class Puppy
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
