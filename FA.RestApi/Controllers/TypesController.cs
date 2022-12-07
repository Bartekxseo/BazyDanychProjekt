using FA.Services.Models;
using FA.Services.Type;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly ITypeService typeService;
        public TypesController(ITypeService _typeService)
        {
            typeService = _typeService;
        }

        [HttpPatch("addLikedMovieType")]
        public void addLikedMovieType(int userId,int typeId)
        {
            try
            {
                typeService.addLikedMovieType(userId,typeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }
        [HttpPatch("addDislikedMovieType")]
        public void addDislikedMovieType(int userId, int typeId)
        {
            try
            {
                typeService.addDislikedMovieType(userId, typeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }

        }
        [HttpDelete("removeLikedMovieType")]
        public void removeLikedMovieType(int userId, int typeId)
        {
            try
            {
                typeService.removeLikedMovieType(userId, typeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }

        }
        [HttpDelete("removeDislikedMovieType")]
        public void removeDislikedMovieType(int userId, int typeId)
        {
            try
            {
                typeService.removeDislikedMovieType(userId , typeId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }

        }

        [HttpGet("getAllMovieTypes")]
        public List<TypeInfo> getAllMovieTypes()
        {
            try
            {
                return typeService.getAllMovieTypes();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }
        [HttpGet("getLikedMovieTypes")]
        public List<TypeInfo> getLikedMovieTypes(int userId)
        {
            try
            {
                return typeService.getLikedMovieTypes(userId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }
        [HttpGet("getDislikedMovieTypes")]
        public List<TypeInfo> getDislikedMovieTypes(int userId)
        {
            try
            {
                return typeService.getDislikedMovieTypes(userId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw new Exception("", ex);
            }
        }

    }
}
