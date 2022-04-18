using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class UserDatailsServece
    {
        UserDetailRepository userDetailRepository;
        public UserDatailsServece()
        {
            userDetailRepository = new UserDetailRepository();
        }
        public bool CAddUserDetail(UserDetail _userDetail)
        {
            if (_userDetail != null)
                return userDetailRepository.AddUserDetail(_userDetail);
            else throw new Exception("Please check your user detail.");
        }
        public bool CUpdateUserDetails(UserDetail _userDetail)
        {

            if (_userDetail != null)
            {
                return userDetailRepository.UpdateUserDetail(_userDetail);
            }
            else throw new Exception("Please check your user detail.");
        }
        public UserDetail GetUserDetailByID(int _userID)
        {
            if (_userID > 0)
                return userDetailRepository.GetUserDetailByID(_userID);
            else throw new Exception("Please check your UserID.");
        }
    }
}
