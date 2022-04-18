using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using YerNTier.DAL.Repositories;
using YerNTier.Model.Entities;

namespace YerNTier.BLL.Services
{
    public class MealService
    {
        MealRepository mealRepository;
        public MealService()
        {
            mealRepository = new MealRepository();
        }
        public Meal AddFoodsToMeals(Meal _meal, EatenFood _Efood)
        {
            if (_meal != null)
            {
                if (_Efood != null)
                {
                    return mealRepository.AddFoodsToMeals(_meal, _Efood);
                }
                else throw new Exception("Please check your eaten food.");
            }
            else throw new Exception("Please check your meal.");
        }
        public Meal GetByMealId(int _mealID)
        {
            if (_mealID >= 0)
            {
                Meal meal = mealRepository.GetByMealId(_mealID);
                return meal;
            }
            else throw new Exception("Please choose a meal from meal list.");
        }
        public List<Meal> GetById(int _userID)
        {
            List<Meal> meals = new List<Meal>();

            if (_userID > 0)
            {
                meals = mealRepository.GetByUserId(_userID);
            }
            else
            {
                throw new Exception("Please check your UserID.");
            }
            return meals;
        }
        void CheckMeal(Meal _meal)
        {
            if (string.IsNullOrWhiteSpace(_meal.MealName) || string.IsNullOrWhiteSpace(_meal.MealDate.ToString())
                ) throw new Exception("Please check your meal.");
        }
        public bool Insert(Meal _meal)
        {
            CheckMeal(_meal);
            return mealRepository.Insert(_meal);
        }
        public bool CDelete(Meal _meal)
        {
            CheckMeal(_meal);
            if (_meal.DUserID > 0)
            {
                return mealRepository.Delete(_meal);
            }
            else throw new Exception("Please check your mealID.");
        }
        public List<Meal> GetDailyByUserID(int _userID)
        {
            if (_userID > 0)
                return mealRepository.GetMealsForDailyByUserId(_userID);
            else throw new Exception("Please check your UserID.");
        }

        public List<Meal> GetWeeklyByUserID(int _userID)
        {
            if (_userID > 0)
                return mealRepository.GetMealsForWeekByUserId(_userID);
            else throw new Exception("Please check your UserID.");
        }
        public List<Meal> GetMonthByUserID(int _userID)
        {
            if (_userID>0)
                return mealRepository.GetMealsForMonthByUserId(_userID);
            else throw new Exception("Please check your UserID.");
        }
        public List<Meal> GetByDate(DateTime date,int _userID)
        {
            if (_userID > 0)
                return mealRepository.GetByDate(date, _userID);
            else throw new Exception("Please check your date.");     
        }
        public EatenFood GetByEatenFoodId(int _eatenFoodID)
        {
            if (_eatenFoodID > 0)
                return mealRepository.GetByEatenFoodId(_eatenFoodID);
            else throw new Exception("Please choose a food from meal list.");
        }
        public bool Update(int eatenFoodID,EatenFood _eatenFood)
        {
            if (_eatenFood != null)
                return mealRepository.Update(eatenFoodID,_eatenFood);
            else throw new Exception("Please choose a food from meal list.");
        }
        
        public bool Delete(EatenFood _eatenFood)
        {
            if (_eatenFood != null)
                return mealRepository.Delete(_eatenFood);
            else throw new Exception("Please choose a food from meal list.");
        }
        public decimal DailyCalorie(int _userID)
        {
            if (_userID > 0)
                return mealRepository.DailyCalorie(_userID);

            else throw new Exception("Please check your UserID.");
        }
        public decimal DailyProtein(int _userID)
        {
            if (_userID > 0)
                return mealRepository.DailyProtein(_userID);

            else throw new Exception("Please check your UserID.");
        }
        public decimal MonthlyCalorie(int _userID)
        {
            if (_userID > 0)
                return mealRepository.MonthlyCalorie(_userID);

            else throw new Exception("Please check your UserID.");
        }
        public decimal MonthlyProtein(int _userID)
        {
            if (_userID > 0) 
            return mealRepository.MonthlyProtein(_userID);

            else throw new Exception("Please check your UserID.");
        }
        public decimal WeeklyCalorie(int _userID)
        {
            return mealRepository.WeeklyCalorie(_userID);
        }
        public decimal WeeklyProt(int _userID)
        {
            return mealRepository.WeeklyProt(_userID);
        }
        public string MostEatenFood()
        {
            if (mealRepository.MostEatenFood() != null)
            {
                return mealRepository.MostEatenFood();
            }
            else return " ";
        }
    }
}
