using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.Model.Entities;

namespace YerNTier.DAL.Repositories
{
    public class UserRepository
    {
        YerDBContext dbContext;
        PasswordRepository passwordRepository;
        public UserRepository()
        {
            dbContext = new YerDBContext();
            passwordRepository = new PasswordRepository();
        }
        public DUser CheckByUserIdAndPassId(string _email,string _pass)
        {
            DUser dUser = dbContext.DUsers.Where(x => x.Email == _email).FirstOrDefault();
            if (dUser != null)
            {
                Password password = passwordRepository.GetActivePassword(dUser.DUserID);
                if (password.PasswordText == _pass)
                {
                    return dUser;
                }
                else
                {
                    return null;
                }
            }
            else return null;
        }
        
        public int AddUser(DUser _duser)
        {
            dbContext.DUsers.Add(_duser);
            return dbContext.SaveChanges();
        }
        public void userUpdateForLevel(int userID, DUser dUser)
        {
            DUser oldUser = GetUserByUserID(userID);
            oldUser.Level = dUser.Level;
            dbContext.SaveChanges();
        }
        public List<DUser> GetUserForChallenge(string _wish)
        {
            return dbContext.DUsers.Where(a=>a.Wish==_wish).ToList();
        }
        public List<DUser> GetUserForChallengeAndKey(string _wish,string text)
        {
            return dbContext.DUsers.Where(a => a.Wish == _wish && a.Email.Contains(text)).ToList();
        }
        public DUser GetUserByUserID(int _userID)
        {
            DUser dUser = dbContext.DUsers.Find(_userID);
            return dUser;
        }
        public List<string> GetUsersEmail()
        {
            return dbContext.DUsers.Select(a=>a.Email).ToList();
        }
    }
}
