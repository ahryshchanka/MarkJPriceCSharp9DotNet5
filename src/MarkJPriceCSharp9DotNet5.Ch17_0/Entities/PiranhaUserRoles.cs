namespace MarkJPriceCSharp9DotNet5.Ch17_0.Entities
{
    public partial class PiranhaUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual PiranhaRoles Role { get; set; }
        public virtual PiranhaUsers User { get; set; }
    }
}