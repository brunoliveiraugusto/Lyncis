namespace Lyncis.Identity.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public User(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public void UpdateName(string newName)
        {
            ValidateName(newName);

            Name = newName;
        }

        private static void ValidateName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.");
        }

        private static void ValidateEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be empty.");
        }
    }
}
