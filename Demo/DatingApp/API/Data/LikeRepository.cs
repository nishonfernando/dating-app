using API.Entities;
using API.Interfaces;

namespace API.Data;

public class LikeRepository : ILikeRepository
{
    public void AddLike(UserLike like)
    {
        throw new NotImplementedException();
    }

    public void DeleteLike(UserLike like)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<int>> GetCurrentUserLikeIds(int currentUserId)
    {
        throw new NotImplementedException();
    }

    public Task<UserLike?> GetUserLike(int sourceUserId, int targetUserId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserLike>> GetUserLikes(string predicate, int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveChanges()
    {
        throw new NotImplementedException();
    }
}
