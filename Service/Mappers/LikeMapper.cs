using Application.DTOs;
using DataAccess.Models;

namespace Application.Mappers;

public static class LikeMapper
{
    // Map LikeDto to Like (Model)
    public static Like ToModel(this LikeDto dto)
    {
        return new Like
        {
            PostId = dto.PostId,
            UserId = dto.UserId
        };
    }
}