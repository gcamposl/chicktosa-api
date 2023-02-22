using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public User(string email, string password)
        {
            Validation(email, password);
        }

        public User(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id deve ser maior do que 0!");
            Id = id;
            Validation(email, password);
        }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password deve ser informada!");

            Email = email;
            Password = password;
        }
    }
}