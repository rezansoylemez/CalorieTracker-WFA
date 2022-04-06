using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class UserInfoService
    {
        UserInfoRepository userInfoRepository;
        TicTacRepository ticTacRepo;
        public UserInfoService()
        {
            userInfoRepository = new UserInfoRepository();
            ticTacRepo = new TicTacRepository();
        }
        public int AddMess(UserInfo _info)
        {
            if (_info.MessageComment != null )
            {
                return userInfoRepository.AddMess(_info);
            }
            else
                throw new Exception("Please check your message.");
        }
        public List<UserInfo> ShowMess(int _userID)
        {
            if (_userID > 0)
                return userInfoRepository.ShowMess(_userID);
            else
                throw new Exception("Please check your message.");
        }
        public bool UpdateTicTac(TicTac _ticTac)
        {
            if (_ticTac.YourTurn != null)
            {
                return ticTacRepo.UpdateUserTicTac(_ticTac);
            }
            else throw new Exception("Please check your message.");
        }
        public TicTac FindByID(int _ticTac)
        {
            if (_ticTac > 0)
                return ticTacRepo.GetByFoodID(_ticTac);
            else
                throw new Exception("Please check your message.");
        }
        public TicTac GetTicTac(int _userID)
        {
            if (_userID > 0)
                return ticTacRepo.ShowTicTacString(_userID);
            else
                throw new Exception("Please check your message.");
        }
    }
}
