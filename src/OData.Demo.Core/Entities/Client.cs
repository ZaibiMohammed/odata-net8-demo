namespace OData.Demo.Core.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        private Client() { } // For EF Core

        private Client(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public static Client Create(string name, string email, string phone)
        {
            return new Client(name, email, phone);
        }

        public void Update(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}