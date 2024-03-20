namespace Domain.Authentication
{
    public interface ICurrentUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Permission { get; set; }
    }
}