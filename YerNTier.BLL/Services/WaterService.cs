using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;

namespace YerNTier.BLL.Services
{
    public class WaterService
    {
        WaterRepository waterRepository;
        public WaterService()
        {
            waterRepository = new WaterRepository();
        }
        public int WaterQuantity(int _userID)
        {
            if (_userID > 0)
                return waterRepository.GetWater(_userID);
            else throw new Exception("Please check your UserID.");
        }
        public bool UpdateQuantity(int _userID, int _quantity)
        {
            if (_userID > 0)
            {
                if (_quantity >= 0)
                    return waterRepository.UpdateWater(_userID, _quantity);
                else throw new Exception("Please check your quantity.");
            }
            else throw new Exception("Please check your UserID.");
        }
    }
}
