using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator
{
    public class HealthCalculator
    {
        public double countBMI(double height, double weight)
        {
            if (height <= 0)
                throw new ArgumentException("Invalid value! Height must be greater than zero!");
            if (weight <= 0)
                throw new ArgumentException("Invalid value! Weight must be greater than zero!");
            if (height > 300)
                throw new ArgumentException("Invalid value! The height you entered is too high!");
            if (weight > 300)
                throw new ArgumentException("Invalid value! The weight you entered is too high!");
            double BMI = Math.Floor(weight / Math.Pow((height / 100), 2) * 100.0) / 100.0;
            return BMI;
        }

        public String showResultText(double BMI)
        {
            String resultText = "";
            if (BMI < 16)
                resultText = "You're starved! Immediately contact with doctor!";
            else if (BMI >= 16 && BMI < 17)
                resultText = "You're skinny! Contact with doctor!";
            else if (BMI >= 17 && BMI < 18.5)
                resultText = "You're underweight! Take care of Your health!";
            else if (BMI >= 18.5 && BMI < 25)
                resultText = "Congratulations! You're weight is proper!";
            else if (BMI >= 25 && BMI < 30)
                resultText = "You're overweight! Take care of Your health!";
            else if (BMI >= 30 && BMI < 35)
                resultText = "You have I class of obesity! Contact with doctor!";
            else if (BMI >= 35 && BMI < 40)
                resultText = "You have II class of obesity! Contact with doctor!";
            else if (BMI >= 40)
                resultText = "You have extreme obesity. Immediately contact with doctor!";
            return resultText;
        }

        public double countBMRWoman(int age, double height, double weight)
        {
            if (age <= 0)
                throw new ArgumentException("Invalid value! Age must be greater than zero!");
            if (height <= 0)
                throw new ArgumentException("Invalid value! Height must be greater than zero!");
            if (weight <= 0)
                throw new ArgumentException("Invalid value! Weight must be greater than zero!");
            if (age > 120)
                throw new ArgumentException("Invalid value! The age you entered is too high!");
            if (height > 300)
                throw new ArgumentException("Invalid value! The height you entered is too high!");
            if (weight > 300)
                throw new ArgumentException("Invalid value! The weight you entered is too high!");
            double BMR = Math.Floor(((9.99 * weight) + (6.25 * height) - (4.92 * age) - 161) * 100.0) / 100.0;
            return BMR;

        }
        public double countBMRMan(int age, double height, double weight)
        {
            if (age <= 0)
                throw new ArgumentException("Invalid value! Age must be greater than zero!");
            if (height <= 0)
                throw new ArgumentException("Invalid value! Height must be greater than zero!");
            if (weight <= 0)
                throw new ArgumentException("Invalid value! Weight must be greater than zero!");
            if (age > 120)
                throw new ArgumentException("Invalid value! The age you entered is too high!");
            if (height > 300)
                throw new ArgumentException("Invalid value! The height you entered is too high!");
            if (weight > 300)
                throw new ArgumentException("Invalid value! The weight you entered is too high!");
            double BMR = Math.Floor(((9.99 * weight) + (6.25 * height) - (4.92 * age) + 5) * 100.0) / 100.0;
            return BMR;
        }
    }
}
