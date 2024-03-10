using Domain.Validations;

namespace Domain.Entities
{
    // sealed nao pode ser herdada por nenhuma outra classe
    public sealed class Permission
    {
        public int Id { get; set; }
        public string VisualName { get; set; }
        public string PermissionName { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

        public Permission(string visualName, string permissionName)
        {
            Validation(visualName, permissionName);
            UserPermissions = new List<UserPermission>();
        }


        private void Validation(string visualName, string permissionName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(visualName), "nome visual deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(permissionName), "nome permissão deve ser informado");

            VisualName = visualName;
            PermissionName = permissionName;
        }
    }
}