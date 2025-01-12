﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using YerNTier.Model.Entities;
using YerNTier.Model.Enums;

namespace YerNTier.DAL.Strategy
{
    public class YerStrategy:CreateDatabaseIfNotExists<YerDBContext>
    {
        protected override void Seed(YerDBContext yerDBcontext)
        {
            // database oluşturulurken yapılacaklar
            FoodCategory foodCategory = new FoodCategory
            {
                CategoryName = "Sebzeler",
                Description = "Sebzeleri içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory);
            FoodCategory foodCategory2 = new FoodCategory
            {
                CategoryName = "Meyveler",
                Description = "Meyveleri içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory2);
            FoodCategory foodCategory3 = new FoodCategory
            {
                CategoryName = "Etler",
                Description = "Etleri içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory3);
            FoodCategory foodCategory4 = new FoodCategory
            {
                CategoryName = "Kuruyemişler",
                Description = "Kuruyemişler içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory4);
            FoodCategory foodCategory5 = new FoodCategory
            {
                CategoryName = "Kahvaltılık",
                Description = "Kahvaltılıkları içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory5);
            FoodCategory foodCategory6 = new FoodCategory
            {
                CategoryName = "Atıştırmalık",
                Description = "Atıştırmalık içerir."
            };
            yerDBcontext.FoodCategories.Add(foodCategory6);

            yerDBcontext.SaveChanges();

            Food food = new Food()
            {
                FoodName = "Tavuk",
                Calorie = 239,
                Protein = 27,
                CategoryID = 3,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\tavuk.jpg"
            };
            yerDBcontext.Foods.Add(food);

            Food food1 = new Food()
            {
                FoodName = "Havuç",
                Calorie = 41,
                Protein = 1,
                CategoryID = 1,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\havuç.jpg"

            };
            yerDBcontext.Foods.Add(food1);

            Food food2 = new Food()
            {
                FoodName = "Elma",
                Calorie = 52,
                Protein = 0,
                CategoryID = 2,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\elma.jpg"

            };
            yerDBcontext.Foods.Add(food2);

            Food food3 = new Food()
            {
                FoodName = "Fındık",
                Calorie = 628,
                Protein = 15,
                CategoryID = 4,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\fındık.jpg"
            };
            yerDBcontext.Foods.Add(food3);

            Food food4 = new Food()
            {
                FoodName = "Badem",
                Calorie = 598,
                Protein = 19,
                CategoryID = 4,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\badem.jpg"
            };
            yerDBcontext.Foods.Add(food4);

            Food food5 = new Food()
            {
                FoodName = "Kaju",
                Calorie = 550,
                Protein = 18,
                CategoryID = 4,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\kaju.jpg"
            };
            yerDBcontext.Foods.Add(food5);

            Food food6 = new Food()
            {
                FoodName = "Tavuk Göğsü",
                Calorie = 110,
                Protein = 25,
                CategoryID = 3,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\tavukgöğsü.jpg"
            };
            yerDBcontext.Foods.Add(food6);

            Food food7 = new Food()
            {
                FoodName = "Tavuk Pirzola",
                Calorie = 146,
                Protein = 19,
                CategoryID = 3,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\tavukpirzola.jpg"
            };
            yerDBcontext.Foods.Add(food7);

            Food food8 = new Food()
            {
                FoodName = "Fıstık",
                Calorie = 567,
                Protein = 26,
                CategoryID = 4,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\fıstık.jpg"
            };
            yerDBcontext.Foods.Add(food8);

            Food food9 = new Food()
            {
                FoodName = "Brokoli",
                Calorie = 26,
                Protein = 3,
                CategoryID = 1,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\brokoli.jpg"
            };
            yerDBcontext.Foods.Add(food9);

            Food food10 = new Food()
            {
                FoodName = "Patlıcan",
                Calorie = 61,
                Protein = 1,
                CategoryID = 1,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\patlıcan.jpg"
            };
            yerDBcontext.Foods.Add(food10);

            Food food11 = new Food()
            {
                FoodName = "Portakal",
                Calorie = 101,
                Protein = 1,
                CategoryID = 2,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\portakal.jpg"
            };
            yerDBcontext.Foods.Add(food11);

            Food food12 = new Food()
            {
                FoodName = "Kiraz",
                Calorie = 63,
                Protein = 1,
                CategoryID = 2,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\kiraz.jpg"
            };
            yerDBcontext.Foods.Add(food12);

            Food food13 = new Food()
            {
                FoodName = "Muz",
                Calorie = 88,
                Protein = 1,
                CategoryID = 2,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\muz.jpg"
            };
            yerDBcontext.Foods.Add(food13);
            Food food14 = new Food()
            {
                FoodName = "Süzme Peynir",
                Calorie = 100,
                Protein = 11,
                CategoryID = 5,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\beyazPeynir.jpg"
            };
            yerDBcontext.Foods.Add(food14);

            Food food15 = new Food()
            {
                FoodName = "Göğermiş Peynir",
                Calorie = 304,
                Protein = 15,
                CategoryID = 5,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\GögermisPeynir.jpg"
            };
            yerDBcontext.Foods.Add(food15);

            Food food16 = new Food()
            {
                FoodName = "Haşlanmış Yumurta",
                Calorie = 155,
                Protein = 13,
                CategoryID = 6,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\HaslanmisYumurta.jpg"
            };
            yerDBcontext.Foods.Add(food16);

            Food food17 = new Food()
            {
                FoodName = "Çilek Reçeli",
                Calorie = 278,
                Protein = 1,
                CategoryID = 6,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\CilekReceli.jpg"
            };
            yerDBcontext.Foods.Add(food17);

            Food food18 = new Food()
            {
                FoodName = "Ketçaplı Patates Cipsi",
                Calorie = 537,
                Protein = 6,
                CategoryID = 7,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\ketcapliPatatesCips.jpg"
            };
            yerDBcontext.Foods.Add(food18);

            Food food19 = new Food()
            {
                FoodName = "Çikolatalı Gofret",
                Calorie = 594,
                Protein = 18,
                CategoryID = 7,
                Portion = Portion.Gram,
                Quantity = 100,
                FoodImage = @"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\cikolataliGofret.jpg"
            };
            yerDBcontext.Foods.Add(food19);

            yerDBcontext.SaveChanges();
        }
    }
}
