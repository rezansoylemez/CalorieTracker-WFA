using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class UserService
    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }
        public DUser CheckLogin(string _email, string _pass)
        {
            if (_email != "")
            {
                if (_pass != "")
                {
                    return userRepository.CheckByUserIdAndPassId(_email, _pass);
                }
                else throw new Exception("Please check your password.");
            }
            else throw new Exception("Please check your email.");
        }
        public int AddUser(DUser _user)
        {
            if (_user != null)
                return userRepository.AddUser(_user);
            else
                throw new Exception("Please check your User.");
        }
        public List<DUser> GetUserForChallenge(string _wish)
        {
            if (_wish != "")
            {
                return userRepository.GetUserForChallenge(_wish);
            }
            else throw new Exception("Please check your wish.");
        }
        public List<DUser> GetUserForChallengeAndKey(string _wish, string _text)
        {
            if (_wish != "")
            {
                if (_text != "")
                {
                    return userRepository.GetUserForChallengeAndKey(_wish, _text);
                }
                else throw new Exception("Please check your text.");
            }
            else throw new Exception("Please check your wish.");
        }
        public DUser GetUserByUserID(int _userID)
        {
            if (_userID > 0)
                return userRepository.GetUserByUserID(_userID);
            else
                throw new Exception("Please check your userID.");
        }
        public void userUpdateForLevel(int userID, DUser dUser)
        {
            userRepository.userUpdateForLevel(userID, dUser);
        }
        
        public bool UserEmailIfExist(string _email)
        {
            bool sonuc= false;
            List<string> list = userRepository.GetUsersEmail();
            if (list.Contains(_email))
            {
                throw new Exception("This email already exist.");
                return sonuc;
            }
            else
            {
                sonuc = true;
                return sonuc;
            }
        }
    }
}
