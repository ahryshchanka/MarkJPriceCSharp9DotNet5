using System.Collections.Generic;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaUsers
    {
        public PiranhaUsers()
        {
            PiranhaUserClaims = new HashSet<PiranhaUserClaims>();
            PiranhaUserLogins = new HashSet<PiranhaUserLogins>();
            PiranhaUserRoles = new HashSet<PiranhaUserRoles>();
            PiranhaUserTokens = new HashSet<PiranhaUserTokens>();
        }

        public string Id { get; set; }
        public long AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public long EmailConfirmed { get; set; }
        public long LockoutEnabled { get; set; }
        public string LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public long PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public long TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<PiranhaUserClaims> PiranhaUserClaims { get; set; }
        public virtual ICollection<PiranhaUserLogins> PiranhaUserLogins { get; set; }
        public virtual ICollection<PiranhaUserRoles> PiranhaUserRoles { get; set; }
        public virtual ICollection<PiranhaUserTokens> PiranhaUserTokens { get; set; }
    }
}