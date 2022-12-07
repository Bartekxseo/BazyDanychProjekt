using FA.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.Services.Type
{
    public interface ITypeService
    {
        void addLikedMovieType(int userId, int typeId);
        void addDislikedMovieType(int userId, int typeId);
        void removeLikedMovieType(int userId, int typeId);
        void removeDislikedMovieType(int userId, int typeId);

        List<TypeInfo> getAllMovieTypes();
        List<TypeInfo> getDislikedMovieTypes(int userId);
        List<TypeInfo> getLikedMovieTypes(int userId);
    }
}
