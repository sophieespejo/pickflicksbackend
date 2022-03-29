using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pickflicksbackend.Models;
using pickflicksbackend.Services;

namespace pickflicksbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MWGController : ControllerBase
    {
        private readonly MWGService _data;

        public MWGController(MWGService dataFromService) {
            _data = dataFromService;
        }

        // Create a MWG by MWGModel (will return a bool)
        [HttpPost("AddMWG")]
        public bool AddMWG(MWGModel newMWG)
        {
            return _data.AddMWG(newMWG);
        }

        // Get all MWGs from table (will return a collection)
        [HttpGet("GetAllMWG")]
        public IEnumerable<MWGModel> GetAllMWG()
        {
            return _data.GetAllMWG();
        }

        // Get a MWG by the specific id (will return MWGModel)
        [HttpGet("GetMWGById/{id}")]
        public MWGModel GetMWGById(int id)
        {
            return _data.GetMWGById(id);
        }

        // Get a MWG by the MWGName (will return MWGModel)
        [HttpGet("GetMWGByMWGName/{WGName}")]
        public MWGModel GetMWGByMWGName(string? MWGName)
        {
            return _data.GetMWGByMWGName(MWGName);
        }

        // Get all the MWGs a user created by userId (will return a collection of MWGModels)
        [HttpGet("GetAllCreatedMWGByUserId/{userId}")]
        public IEnumerable<MWGModel> GetAllCreatedMWGByUserId(int userId)
        {
            return _data.GetAllCreatedMWGByUserId(userId);
        }

        // Get all the MWGs a user is a member of by userId (will return a collection of MWGModels)
        [HttpGet("GetAllMWGAUserIsMemberOf/{userId}")]
        public IEnumerable<MWGModel> GetAllMWGAUserIsMemberOf(int userId)
        {
            return _data.GetAllMWGAUserIsMemberOf(userId);
        }

        // Edit a MWG name (will return a bool)
        [HttpPost("EditMWGName/{oldMWGName}/{updatedMWGName}")]
        public bool EditMWGName(string? oldMWGName, string? updatedMWGName)
        {
            return _data.EditMWGName(oldMWGName, updatedMWGName);
        }


        // Add a members to MWG only the GrouoCreator can do this (will return a bool)
        [HttpPost("AddMemberToMWG/{MWGId}/{newMemberId}")]
        public bool AddMemberToMWG(int MWGId, int newMemberId)
        {
            return _data.AddMemberToMWG(MWGId, newMemberId);
        }

        // Add a user suggested movie to a MWG (will return a bool)
        [HttpPost("AddUserSuggestedMovies/{MWGId}/{newMovie}")]
        public bool AddUserSuggestedMovies(int MWGId, string? newMovie)
        {
            return _data.AddUserSuggestedMovies(MWGId, newMovie);
        }

        // Delete a MWG by MWGName (will return a bool)
        [HttpPost("DeleteByMWGName/{MWGName}")]
        public bool DeleteByMWGName(string? MWGName)
        {
            return _data.DeleteByMWGName(MWGName);
        }

        // Delete a MWG by id of MWG (will return a bool)
        [HttpPost("DeleteByMWGId/{MWGId}")]
        public bool DeleteByMWGId(int MWGId)
        {
            return _data.DeleteByMWGId(MWGId);
        }
    }
}