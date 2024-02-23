

namespace Core.Entities
{
    public class User : Entity<int>
    {

        //Genel User Fieldları
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Approved { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public User()
        {

        }

        public User(string email, byte[] passwordHash, byte[] passwordSalt, bool approved)
        {
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Approved = approved;
            
        }

        public User(ICollection<UserRole> userRoles)
        {
            UserRoles = userRoles;
        }




        //abc123 => Plain Text olarak sifre tutulmaz.
        //Hashing SHA512,MD5=>ASDFGHER1234
        //Salting=>2. güvenlik önlemi, aynı paralo farklı hash degerlerine sahip olur,güvenliği sağlar.
    }

    
}
