namespace Gratify.Domain
{
    public class UserToUser
    {
        public User Following { get; set; }
        public int FollowingId { get; set; }
        public User Follower { get; set; }
        public int FollowerId { get; set; }
    }
}