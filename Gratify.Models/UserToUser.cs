namespace Gratify.Domain
{
    public class UserToUser
    {
        public User Following { get; set; }
        public string FollowingId { get; set; }
        public User Follower { get; set; }
        public string FollowerId { get; set; }
    }
}