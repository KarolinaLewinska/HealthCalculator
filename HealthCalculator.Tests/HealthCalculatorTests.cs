﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCalculator.Tests
{
    public class HealthCalculatorTests
    {
        [TestFixture]
        public class HealthCalTests
        {
            HealthCalculator cal;

            [OneTimeSetUp]
            public void setUp()
            {
                cal = new HealthCalculator();
            }

            [OneTimeTearDown]
            public void tearDown()
            {
                cal = null;
            }

            [TestCase(145, 55, 26.15)]
            [TestCase(170, 60, 20.76)]
            [TestCase(120, 20, 13.88)]
            [TestCase(190, 120, 33.24)]
            [TestCase(150, 150, 66.66)]
            public void countBMI_DifferentValues_Calculated(double height, double weight, double BMIResult)
            {
                double BMI = cal.countBMI(height, weight);
                Assert.AreEqual(BMI, BMIResult);
            }

            [TestCase(300, 120, 13.33)]
            [TestCase(150, 300, 133.33)]
            public void countBMI_LimitValues_Calculated(double height, double weight, double BMIResult)
            {
                double BMI = cal.countBMI(height, weight);
                Assert.AreEqual(BMI, BMIResult);
            }

            public static string[] BMIDataTxtFile()
            {
                var path = "C:\\Users\\lewin\\OneDrive\\Pulpit\\BMIData.txt";
                return File.ReadAllLines(path).ToArray();
            }

            [Test, TestCaseSource("BMIDataTxtFile")]
            public void countBMI_testDataTxt_Calculated(string dataLine)
            {
                string[] data = dataLine.Split(' ');
                double height = Convert.ToDouble(data[0]);
                double weight = Convert.ToDouble(data[1]);
                double BMIResult = Convert.ToDouble(data[2]);

                double BMI = cal.countBMI(height, weight);
                Assert.AreEqual(BMI, BMIResult);
            }

            [Test]
            public void countBMI_HeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                () => cal.countBMI(-50, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMI_HeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(0, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMI_WeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, -50));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMI_WeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, 0));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMI_HeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! The height is too high!"),
                    delegate
                    {
                        cal.countBMI(301, 120);
                    });
            }

            [Test]
            public void countBMI_WeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! The weight is too high!"),
                    delegate
                    {
                        cal.countBMI(120, 301);
                    });
            }

            [Test]
            public void countBMI_HeightDoubleWeightDouble_Calculated()
            {
                double BMI = cal.countBMI(150.5, 50.5);
                Assert.AreEqual(BMI, 22.29);
            }

            [Test]
            public void countBMI_HeightIntWeightInt_Calculated()
            {
                double BMI = cal.countBMI(145, 55);
                Assert.AreEqual(BMI, 26.15);
            }

            [Test]
            public void countBMI_HeightIntWeightDouble_Calculated()
            {
                double BMI = cal.countBMI(150, 50.5);
                Assert.AreEqual(BMI, 22.44);
            }

            [Test]
            public void countBMI_HeightDoubleWeightInt_Calculated()
            {
                double BMI = cal.countBMI(150.5, 50);
                Assert.AreEqual(BMI, 22.07);
            }

            [TestCase(145, 55, "You're overweight! Take care of your health!")]
            [TestCase(170, 72.25, "You're overweight! Take care of your health!")]
            [TestCase(170, 60, "Congratulations! Your weight is good!")]
            [TestCase(10, 60, "You have extreme obesity. Immediately contact with doctor!")]
            [TestCase(180, 55, "You're skinny! Contact with the doctor!")]
            [TestCase(180, 100, "You have a I class of obesity! Contact with the doctor!")]
            public void countBMI_DifferentTips_Display(double height, double weight, String BMIResultText)
            {
                double BMI = cal.countBMI(height, weight);
                String BMITips = cal.showResultText(BMI);
                Assert.AreEqual(BMITips, BMIResultText);
            }

            [TestCase(23, 145, 55, 1181.54)]
            [TestCase(37, 170, 60, 1318.86)]
            [TestCase(76, 180, 40, 989.67)]
            public void countBMRWoman_DifferentValues_Calculated(int age, double height, double weight, double BMRResult)
            {
                double BMR = cal.countBMRWoman(age, height, weight);
                Assert.AreEqual(BMR, BMRResult);
            }

            [TestCase(23, 145, 55, 1347.54)]
            [TestCase(37, 170, 60, 1484.86)]
            [TestCase(76, 180, 40, 1155.67)]
            public void countBMRMan_DifferentValues_Calculated(int age, double height, double weight, double BMRResult)
            {
                double BMR = cal.countBMRMan(age, height, weight);
                Assert.AreEqual(BMR, BMRResult);
            }

            [TestCase(120, 145, 55, 704.3)]
            [TestCase(37, 300, 60, 2131.36)]
            [TestCase(76, 180, 300, 3587.08)]
            public void countBMRWoman_LimitValues_Calculated(int age, double height, double weight, double BMRResult)
            {
                double BMR = cal.countBMRWoman(age, height, weight);
                Assert.AreEqual(BMR, BMRResult);
            }

            [TestCase(120, 145, 55, 870.3)]
            [TestCase(37, 300, 60, 2297.36)]
            [TestCase(76, 180, 300, 3753.08)]
            public void countBMRMan_LimitValues_Calculated(int age, double height, double weight, double BMRResult)
            {
                double BMR = cal.countBMRMan(age, height, weight);
                Assert.AreEqual(BMR, BMRResult);
            }
            public static string[] BMRDataCSVFile()
            {
                var path = "C:\\Users\\justy\\OneDrive\\Pulpit\\BMRData.csv";
                return File.ReadAllLines(path).ToArray();
            }

            [Test, TestCaseSource("BMRDataCSVFile")]
            public void countBMRWoman_testDataCSV_Calculated(string dataLine)
            {
                string[] data = dataLine.Split(';');
                int age = Convert.ToInt32(data[0]);
                double height = Convert.ToDouble(data[1]);
                double weight = Convert.ToDouble(data[2]);
                double BMRWomanResult = Convert.ToDouble(data[3]);

                double BMR = cal.countBMRWoman(age, height, weight);
                Assert.AreEqual(BMR, BMRWomanResult);
            }

            [Test, TestCaseSource("BMRDataCSVFile")]
            public void countBMRMan_testDataCSV_Calculated(string dataLine)
            {
                string[] data = dataLine.Split(';');
                int age = Convert.ToInt32(data[0]);
                double height = Convert.ToDouble(data[1]);
                double weight = Convert.ToDouble(data[2]);
                double BMRManResult = Convert.ToDouble(data[4]);

                double BMR = cal.countBMRMan(age, height, weight);
                Assert.AreEqual(BMR, BMRManResult);
            }

            [Test]
            public void countBMRWoman_AgeEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(0, 120, 120));

                Assert.That(ex.Message == "Invalid value! Age must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_AgeLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(-50, 120, 120));

                Assert.That(ex.Message == "Invalid value! Age must be greater than zero!");
            }

            [Test]
            public void countBMRMan_AgeEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(0, 120, 120));

                Assert.That(ex.Message == "Invalid value! Age must be greater than zero!");
            }

            [Test]
            public void countBMRMan_AgeLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(-50, 120, 120));

                Assert.That(ex.Message == "Invalid value! Age must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_HeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, 0, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_HeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, -120, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMRMan_HeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 0, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMRMan_HeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, -120, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_WeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, 120, 0));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_WeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, 120, -120));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMRMan_WeightEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 120, 0));
                
                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMRMan_WeightLessThanZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 120, -120));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMRWoman_AgeTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(121, 120, 120));

                Assert.That(ex.Message == "Invalid value! The age is too high!");
            }

            [Test]
            public void countBMRMan_AgeTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(121, 120, 120));

                Assert.That(ex.Message == "Invalid value! The age is too high!");
            }

            [Test]
            public void countBMRWoman_HeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(50, 301, 120));

                Assert.That(ex.Message == "Invalid value! The height is too high!");
            }

            [Test]
            public void countBMRMan_HeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(50, 301, 120));

                Assert.That(ex.Message == "Invalid value! The height is too high!");
            }

            [Test]
            public void countBMRWoman_WeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(50, 120, 301));

                Assert.That(ex.Message == "Invalid value! The weight is too high!");
            }

            [Test]
            public void countBMRMan_WeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(50, 120, 301));

                Assert.That(ex.Message == "Invalid value! The weight is too high!");
            }

            [Test]
            public void countBMR_HeightDoubleWeightDouble_Calculated()
            {
                double BMRW = cal.countBMRWoman(23, 150.5, 50.5);
                Assert.AreEqual(BMRW, 1170.95);
                double BMRM = cal.countBMRMan(23, 150.5, 50.5);
                Assert.AreEqual(BMRM, 1336.95);
            }

            [Test]
            public void countBMR_HeightIntWeightInt_Calculated()
            {
                double BMRW = cal.countBMRWoman(23, 145, 55);
                Assert.AreEqual(BMRW, 1181.54);
                double BMRM = cal.countBMRMan(23, 145, 55);
                Assert.AreEqual(BMRM, 1347.54);
            }

            [Test]
            public void countBMR_HeightIntWeightDouble_Calculated()
            {
                double BMRW = cal.countBMRWoman(23, 150, 50.5);
                Assert.AreEqual(BMRW, 1167.83);
                double BMRM = cal.countBMRMan(23, 150, 50.5);
                Assert.AreEqual(BMRM, 1333.83);
            }

            [Test]
            public void countBMR_HeightDoubleWeightInt_Calculated()
            {
                double BMRW = cal.countBMRWoman(23, 150.5, 50);
                Assert.AreEqual(BMRW, 1165.96);
                double BMRM = cal.countBMRMan(23, 150.5, 50);
                Assert.AreEqual(BMRM, 1331.96);
            }
        }
    }
}
