namespace Webshop.BLL.Infrastructure.DataTransferObjects
{
    public class EditUserRoleDto
    {
        public Guid Id { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
