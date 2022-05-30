namespace EC.Common.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<string> BirthDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
    }
}
