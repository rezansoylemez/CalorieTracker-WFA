using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class FoodService
    {
        FoodRepository foodRepository;
        public FoodService()
        {
            foodRepository = new FoodRepository();
        }
        public List<Food> GetFoodsCheck()
        {
            List<Food> foods = foodRepository.GetFoods();
            if (foods != null)
            {
                return foods;
            }
            else throw new Exception("Please check your UserID.");
        }
        public List<Food> GetFoodsByTextCheck(string text)
        {
            List<Food> foods = foodRepository.GetFoodsByText(text);
            if (foods != null)
            {
                return foods;
            }
            else throw new Exception("Please check your text.");
        }
        public Food GetByFoodIdCheck(int foodID)
        {
            Food food = foodRepository.GetByFoodId(foodID);
            if (food != null)
            {
                return food;
            }
            else throw new Exception("Please check your FoodID.");
        }
        bool CheckFood(Food _food)
        {
            if (string.IsNullOrWhiteSpace(_food.FoodName) || string.IsNullOrWhiteSpace(_food.Protein.ToString())
                 || string.IsNullOrWhiteSpace(_food.CategoryID.ToString()) || string.IsNullOrWhiteSpace(_food.Calorie.ToString()))
                return false;
            else
                return true;
        }
        public void Insert(Food food)
        {
            if (CheckFood(food) == false)
                throw new Exception("Inserting food failed.");
            else if (CheckFood(food) == true)
                  foodRepository.Insert(food); 
        }
        public bool Update(Food _food)
        {
            
            if (_food != null && CheckFood(_food)!=false)
            {
                return foodRepository.Update(_food);
            }
            else
                throw new Exception("Please choose a food in food list.");
        }
        public bool Delete(Food _food)
        {
            
            if (_food.FoodID > 0||_food.CategoryID>0 || CheckFood(_food)==true)
            {
                return foodRepository.Delete(_food);
            }
            else
                throw new Exception("Please choose a food in food list.");
        }
        public bool InsertFoodCategory(FoodCategory _foodCategory)
        {
            if (_foodCategory.Description == null || _foodCategory.CategoryName == null)
            {
                throw new Exception("Inserting food category failed.");
            }
            else return foodRepository.InsertFoodCategory(_foodCategory);
        }
        public List<FoodCategory> GetFoodCategories()
        {
            return foodRepository.GetFoodCategories();
        }
        
    }
}
