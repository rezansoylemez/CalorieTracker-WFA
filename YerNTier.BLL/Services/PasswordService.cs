using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class PasswordService
    {
        PasswordRepository passRepository;
        public PasswordService()
        {
            passRepository = new PasswordRepository();
        }
        public string CheckPasswordText(string _pass)
        {
            if (_pass.Length >= 6 && _pass.Any(Char.IsDigit) && _pass.Any(Char.IsLower) && _pass.Any(char.IsUpper))
                return _pass;
            else
                throw new Exception("Password is weak! Password should have minimum six characters, " +
                    "at least one uppercase, one lowercase characters and one number.");
        }
        public bool AddPassword(Password _pass)
        {
            if (_pass != null)
                return passRepository.AddPass(_pass);
            else
                throw new Exception("Please check your password.");
        }
        public Password GetActivePassword(int _userID)
        {
            if (_userID <= 0) throw new Exception("Please check your UserID");
            return passRepository.GetActivePassword(_userID);
        }
    }
}
