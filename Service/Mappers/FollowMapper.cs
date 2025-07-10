using Application.DTOs;
using DataAccess.Models;

namespace Application.Mappers;

public static class FollowMapper
{
    // Map FollowDto to Follow (Model)
    public static Follow ToModel(this FollowDto dto)
    {
        return new Follow
        {
            FollowerId = dto.FollowerId,
            FolloweeId = dto.FolloweeId
        };
    }
}