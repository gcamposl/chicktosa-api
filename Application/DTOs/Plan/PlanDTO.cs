namespace Application.DTOs.Plan
{
    public class PlanDTO
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public int Id { get; set; }
        public string? PetName { get; set; }
        public decimal? Price { get; set; }
        public string? Race { get; set; }
        public decimal? Weight { get; set; }
    }
}