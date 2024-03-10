using Domain.Validations;

namespace Domain.Entities
{
    public sealed class UserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }

        public UserPermission(int userId, int permissionId)
        {
            Validation(userId, permissionId);
        }

        public void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId == 0, "Id de usuário deve ser informado");
            DomainValidationException.When(permissionId == 0, "Id da permissão deve ser informado");

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}