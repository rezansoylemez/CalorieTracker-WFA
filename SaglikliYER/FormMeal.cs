//using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerNTier.BLL.Services;
using YerNTier.Model.Entities;
using YerNTier.Model.Enums;

namespace SaglikliYER
{
    public partial class FormMeal : Form
    {
        MealService mealService;
        FoodService foodService;
        public FormMeal()
        {
            InitializeComponent();
            mealService = new MealService();
            foodService = new FoodService();
        }
        int userID;
        string language;
        public FormMeal(int _userID,string _language)
        {
            InitializeComponent();
            userID = _userID;
            mealService = new MealService();
            foodService = new FoodService();
            language = _language;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems[0].Tag == null)
                {
                    if (language == "Eng") MessageBox.Show("Please choose a food.");
                    else if (language == "Tr") MessageBox.Show("Lütfen bir yemek seçin.");
                    return;
                }
                Food food2 = foodService.GetByFoodIdCheck((int)cmbFood.SelectedValue);
                int k = 0;
                if ((Portion)cmbPortion.SelectedIndex == Portion.Gram)
                {
                    k = 1;
                }
                else if ((Portion)cmbPortion.SelectedIndex == Portion.Portion400gr) k = 400;
                else
                {
                    MessageBox.Show("Please choose a portion.");
                    return;
                }
                if (nudQuantity.Value == 0)
                {
                    MessageBox.Show("Please increase the quantity.");
                    return;
                }
                if ((Portion)cmbPortion.SelectedIndex == Portion.Gram) k = 1;
                else k = 400;
                EatenFood food = new EatenFood();
                food.FoodID = food2.FoodID;
                food.EatenCategoryID = food2.CategoryID;
                food.EatenFoodName = food2.FoodName;
                food.EatenPortion = (Portion)cmbPortion.SelectedIndex;
                food.EatenQuantity = (decimal)nudQuantity.Value;
                food.EatenProtein = (k * food.EatenQuantity * food2.Protein) / 100;
                food.EatenColorie = (k * food.EatenQuantity * food2.Calorie) / 100;
                mealService.Update((int)listView1.SelectedItems[0].Tag, food);

                if (language == "Eng") MessageBox.Show("Food is updated.");
                else if (language == "Tr") MessageBox.Show("Yemek güncellendi");
                FillListview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Meal meal = new Meal();
                meal.DUserID = userID;
                if (comboBox1.SelectedItem == null)
                {
                    if (language == "Eng") MessageBox.Show("Please choose a meal.");
                    else if (language == "Tr") MessageBox.Show("Lütfen bir yemek seçin.");
                    return;
                }
                meal.MealName = comboBox1.SelectedItem.ToString();
                meal.MealDate = dtpMealDate.Value;
                mealService.Insert(meal);
                if(language == "Eng") MessageBox.Show("Meal is added.");
                else if (language == "Tr") MessageBox.Show("Öğün Eklendi");
                lbDoldur();
                cmbDoldur();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FormMeal_Load(object sender, EventArgs e)
        {
            switch (language)
            {
                case "Eng":
                    label9.Text = "Meal Name :";
                    label8.Text = "Meal Date :";
                    label13.Text = "Food :";
                    label10.Text = "Portion :";
                    label11.Text = "Quantity :";
                    groupBox4.Text = "Meal";
                    grpFood.Text = "Food";
                    this.Text = "Meal";
                    break;
                case "Tr":
                    label9.Text = "Öğün Adı :";
                    label8.Text = "Öğün Tarihi :";
                    label13.Text = "Yiyecek :";
                    label10.Text = "Porsiyon :";
                    label11.Text = "Miktar :";
                    groupBox4.Text = "Öğün";
                    grpFood.Text = "Yiyecek";
                    this.Text = "Öğün";
                    break;
            }
            cmbPortion.Items.Add(Portion.Portion400gr);
            cmbPortion.Items.Add(Portion.Gram);
            lbDoldur();
            cmbDoldur();
            listBox1.SelectedIndex = -1;
            cmbFood.SelectedIndex = 0;
        }

        private void cmbDoldur()
        {
            List<Food> foods = new List<Food>();
            foods = foodService.GetFoodsCheck();
            cmbFood.DataSource = foods;
            cmbFood.DisplayMember = "FoodName";
            cmbFood.ValueMember = "FoodID";
        }

        void FillListview()
        {
            if (listBox1.SelectedIndex != -1)
            {
                listView1.Items.Clear();
                int selMealID = Convert.ToInt32(listBox1.SelectedValue);
                Meal meal = mealService.GetByMealId(selMealID);
                foreach (EatenFood item in meal.EatenFoods)
                {
                    ListViewItem listView = new ListViewItem();
                    listView.Tag = item.EatenFoodID;
                    listView.Text = meal.MealName;
                    listView.SubItems.Add(item.EatenFoodName);
                    listView.SubItems.Add(item.EatenPortion.ToString());
                    listView.SubItems.Add(item.EatenQuantity.ToString());
                    listView.SubItems.Add(meal.MealDate.ToString());
                    listView1.Items.Add(listView);
                }
            }
        }

        private void lbDoldur()
        {
            List<Meal> meals = new List<Meal>();
            meals = mealService.GetByDate(dateTimePicker1.Value,userID);
            listBox1.DataSource = meals;
            listBox1.DisplayMember = "MealName";
            listBox1.ValueMember = "MealID";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lbDoldur();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedValue == null)
                {
                    if (language == "Eng") MessageBox.Show("Please choose a meal from meal list.");
                    else if (language == "Tr") MessageBox.Show("Lütfen yemek listesinden bir yemek seçin.");
                    return;
                }
                int selMealID = (int)listBox1.SelectedValue;
                Meal meal = mealService.GetByMealId(selMealID);
                Food food2 = foodService.GetByFoodIdCheck((int)cmbFood.SelectedValue);
                int k = 0;
                if ((Portion)cmbPortion.SelectedIndex == Portion.Gram)
                {
                    k = 1;
                }
                else if ((Portion)cmbPortion.SelectedIndex == Portion.Portion400gr) k = 400;
                else
                {
                    if(language=="Eng") MessageBox.Show("Please choose a portion.");
                    else if (language=="Tr") MessageBox.Show("Lütfen Porsiyon seçiniz");
                    return;
                }
                if (nudQuantity.Value == 0)
                {
                    if (language == "Eng") MessageBox.Show("Please increase the quantity.");
                    else if (language == "Tr") MessageBox.Show("Lütfen Miktar bilgisini giriniz.");
                    return;
                }
                if ((Portion)cmbPortion.SelectedIndex == Portion.Gram) k = 1;
                else k = 400;
                EatenFood food = new EatenFood();
                food.FoodID = food2.FoodID;
                food.EatenCategoryID = food2.CategoryID;
                food.EatenFoodName = food2.FoodName;
                food.EatenPortion = (Portion)cmbPortion.SelectedIndex;
                food.EatenQuantity = (decimal)nudQuantity.Value;
                food.EatenProtein = (k * food.EatenQuantity * food2.Protein) / 100;
                food.EatenColorie = (k * food.EatenQuantity * food2.Calorie) / 100;
                mealService.AddFoodsToMeals(meal, food);
                if (language == "Eng") MessageBox.Show("Food is added.");
                else if (language == "Tr") MessageBox.Show("Yiyecek Eklendi");
                lbDoldur();
                cmbDoldur();
                FillListview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFood.SelectedIndex == 0)
                {
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Rezan Söylemez\Desktop\SaglikliYER\tavuk.jpg");
                }
                else
                {
                    Food food = foodService.GetByFoodIdCheck((int)cmbFood.SelectedValue);
                    if (food.FoodImage != null) pictureBox1.Image = Image.FromFile(food.FoodImage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillListview();
        }

        private void btnMealDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue != null)
            {
                Meal meal = mealService.GetByMealId(Convert.ToInt32(listBox1.SelectedValue));
                mealService.CDelete(meal);
                if (language == "Eng") MessageBox.Show("Meal is deleted");
                else if (language == "Tr") MessageBox.Show("Öğün Silindi");
                lbDoldur();
                listView1.Items.Clear();
            }
        }
        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EatenFood eatenFood = mealService.GetByEatenFoodId((int)listView1.SelectedItems[0].Tag);
            mealService.Delete(eatenFood);
            if (language == "Eng") MessageBox.Show("Food is deleted");
            else if (language == "Tr") MessageBox.Show("Yiyecek Silindi");
            FillListview();
        }

        private void FormMeal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void btnBackk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
