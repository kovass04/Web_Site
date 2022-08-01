namespace test_case.Models
{
    public class Check
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Order { get; set; }
        public decimal Price { get; set; }
        public string? Roles { get; set; }
    }
}
