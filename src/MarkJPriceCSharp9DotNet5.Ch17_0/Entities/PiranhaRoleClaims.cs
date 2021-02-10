namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaRoleClaims
    {
        public long Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string RoleId { get; set; }

        public virtual PiranhaRoles Role { get; set; }
    }
}