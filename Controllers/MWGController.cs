using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetShitDoneBackend.Models;
using GetShitDoneBackend.Services;

namespace GetShitDoneBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectItemController : ControllerBase
    {
        private readonly ProjectItemService _data;

        public ProjectItemController(ProjectItemService dataFromService) {
            _data = dataFromService;
        }



        // Add a new MWG to table
        [HttpPost("AddMWG")]
        public bool AddMWG(MWGModel newMWG)
        {
            return _data.AddMWG(newMWG);
        }

        // Get all MWGModels from table
        [HttpGet("GetAllMWG")]
        public IEnumerable<MWGModel> GetAllMWG()
        {
            return _data.GetAllMWG();
        }

        // Get a MWG by MWGId
        [HttpGet("GetMWGById/{Id}")]
        public MWGModel GetMWGById(int id)
        {
            return _data.GetMWGById(id);
        }

        // Get a LIST of MWG by UserId
        [HttpGet("GetMWGByUserId/{UserId}")]
        public IEnumerable<MWGModel> GetMWGByUserId(int userId)
        {
            return _data.GetMWGByUserId(userId);
        }

        // Get a MWG by the GroupName 
        [HttpGet("GetMWGByGroupName/{GroupName}")]
        public MWGModel GetMWGByGroupName(string groupName)
        {
            return _data.GetMWGByGroupName(groupName);
        }

        // Get a MWG by the GroupCreatorId 
        [HttpGet("GetMWGByGroupCreatorId/{GroupCreaterId}")]
        public MWGModel GetMWGByGroupCreatorId(string groupCreaterId)
        {
            return _data.GetMWGByGroupName(groupCreaterId);
        }

        // Get all membersId of MWG by MWGId
        [HttpGet("GetMembersIdOfMWG/{MWGId}")]
        public MWGModel GetMembersIdOfMWG(string MWGId)
        {
            return _data.GetMembersIdOfMWG(MWGId);
        }

        // Get SuggestedMovies by MWGId
        [HttpGet("GetSuggestedMoviesByMWGId/{MWGId}")]
        public MWGModel GetSuggestedMoviesByMWGId(string MWGId)
        {
            return _data.GetSuggestedMoviesByMWGId(MWGId);
        }


        // Get all soft deleted ProjectItems 
        [HttpGet("GetDeletedProjectItems")]
        public IEnumerable<MWGModel> GetDeletedMWG()
        {
            return _data.GetDeletedMWG();
        }

        // Update MWG
        [HttpPost("UpdateMWG")]
        public bool UpdateMWG(MWGModel updatedMWG)
        {
            return _data.UpdateMWG(updatedMWG);
        }

        // Soft delete a MWG
        [HttpPost("DeleteMWG")]
         public bool DeleteMWG(MWGModel deletedMWG)
        {
           return _data.DeleteMWG(deletedMWG);
        }
    }
}