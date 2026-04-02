public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public int RoleId { get; set; }
    public Role? Role { get; set; }
    public int IsDeleted { get; set; } = 0;
}