using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.Model.Entities;

namespace YerNTier.DAL.Repositories
{
    public class UserInfoRepository
    {
        YerDBContext context;
        public UserInfoRepository()
        {
            context = new YerDBContext();
        }
        public int AddMess(UserInfo _info)
        {
            context.UserInfos.Add(_info);
            return context.SaveChanges();
        }
        public List<UserInfo> ShowMess(int _userID)
        {
            return context.UserInfos.Where(a => a.DUserID == _userID).ToList();
        }
    }
}
