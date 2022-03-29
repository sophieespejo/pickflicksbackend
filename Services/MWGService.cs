using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pickflicksbackend.Models;
using pickflicksbackend.Models.DTO;
using pickflicksbackend.Services;
using pickflicksbackend.Services.Context;

namespace pickflicksbackend.Services
{
    public class MWGService
    {
        private readonly DataContext _context;
        public MWGService(DataContext context)
        {
            _context = context;
        }

        public bool AddMWG(MWGModel newMWGModel)
        {
            bool result = false;
            bool doesMWGExist = _context.MWGInfo.SingleOrDefault(MWG => MWG.Id == newMWGModel.id)!=null;
            if(!doesCohortExist)
            {
                _context.Add(newMWGModel);
                result= _context.SaveChanges() != 0;
            }
            return result;
        }

        public IEnumerable<MWGModel> GetAllMWG()
        {
            return _context.MWGInfo;
        }

        public MWGModel GetMWGById(int id)
        {
            return _context.MWGInfo.SingleOrDefault(item => item.Id == id);
        }

        public MWGModel GetMWGByMWGName(string MWGName)
        {
            return _context.MWGInfo.SingleOrDefault(item => item.MWGName == MWGName);
        }

        public IEnumerable<MWGModel> GetAllCreatedMWGByUserId(int userId)
        {
            return _context.MWGInfo.Where(item => item.GroupCreatorId);
        }

        public List<MWGModel> GetAllMWGAUserIsMemberOf(int userId)
        {
            //"Tag1, Tag2, Tag3,Tag4"
            List<MWGModel> AllMWGWithMemberId = new List<MWGModel>();//[]
            var allMWG = GetAllMWG().ToList();//{Tag:"Tag1, Tag2",Tag:"Tag2",Tag:"tag3"}
            for(int i=0; i < allMWG.Count; i++)
            {
                MWGModel Group = allMWG[i];//{Tag:"Tag1, Tag2"}
                var groupArr = Group.MembersId.Split(",");//["Tag1","Tag2"]
                for(int j = 0; j < groupArr.Length; j++)
                {   //Tag1 j = 0
                    //Tag2 j = 1
                    if(groupArr[j].Contains(userId))
                    {// Tag1               Tag1
                        AllMWGWithMemberId.Add(Group);//{Tag:"Tag1, Tag2"}
                    }
                }
            }
            return AllMWGWithMemberId;
        }

        public bool EditMWGName(string? oldMWGName, string? updatedMWGName)
        {
            bool result=false;
            MWGModel foundMWG = GetMWGByMWGName(oldMWGName);
            if(foundMWG != null)
            {
                foundMWG.MWGName = updatedMWGName;
                _context.Update<MWGModel>(foundMWG);
                result = _context.SaveChanges()!=0;
            }
            return result;        
        }

        // Hopefully this works
        public bool AddMemberToMWG(int MWGId, int newMemberId)
        {
            bool result=false;
            MWGModel foundMWG = GetMWGById(MWGId);
            if(foundMWG != null)
            {
                // Append the new userId into the string
                foundMWG.MembersId += newMemberId + ',';
                _context.Update<MWGModel>(foundMWG);
                result = _context.SaveChanges()!=0;
            }
            return result;        
        }

        public bool AddUserSuggestedMovies(int MWGId, string? newMovie)
        {
            bool result=false;
            MWGModel foundMWG = GetMWGById(MWGId);
            if(foundMWG != null)
            {
                // Append the new userId into the string
                foundMWG.UserSuggestedMovies += newMovie + ',';
                _context.Update<MWGModel>(foundMWG);
                result = _context.SaveChanges()!=0;
            }
            return result;        
        }

        public bool DeleteByMWGName(string? MWGName)
        {
            bool result = false;
            MWGModel foundMWG = GetMWGByMWGName(MWGName);
            if(foundMWG != null)
            {
                foundMWG.IsDeleted =!foundMWG.IsDeleted;
                _context.Update<MWGModel>(foundMWG);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }

        public bool DeleteByMWGId(int MWGId)
        {
            bool result = false;
            MWGModel foundMWG = GetMWGByMWGName(MWGName);
            if(foundMWG != null)
            {
                foundMWG.IsDeleted =!foundMWG.IsDeleted;
                _context.Update<MWGModel>(foundMWG);
                result = _context.SaveChanges()!=0;
            }
            return result;
        }
    }
}