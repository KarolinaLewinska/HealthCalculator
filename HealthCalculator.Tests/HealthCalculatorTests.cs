using NUnit.Framework;
using System;
using System.Collections.Generic;
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

            [Test]
            public void countBMI_HeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(0, 120));
                    ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(-50, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMI_WeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, 0));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, -50));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMI_HeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! The height you entered is too high!"),
                    delegate {
                        cal.countBMI(301, 120);
                    });
            }

            [Test]
            public void countBMI_WeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! The weight you entered is too high!"),
                    delegate {
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

            [TestCase(145, 55, "You're overweight! Take care of Your health!")]
            [TestCase(170, 72.25, "You're overweight! Take care of Your health!")]
            [TestCase(170, 60, "Congratulations! You're weight is proper!")]
            [TestCase(10, 60, "You have extreme obesity. Immediately contact with doctor!")]
            [TestCase(180, 55, "You're skinny! Contact with doctor!")]
            [TestCase(180, 100, "You have I class of obesity! Contact with doctor!")]
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

            [Test]
            public void countBMR_AgetLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(0, 120, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(0, 120, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(-50, 120, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(-50, 120, 120));

                Assert.That(ex.Message == "Invalid value! Age must be greater than zero!");

            }

            [Test]
            public void countBMR_HeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, 0, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 0, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, -120, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, -120, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMR_WeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(20, 120, 0));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 120, 0));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 120, -120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(20, 120, -120));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMR_AgeTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(121, 120, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(121, 120, 120));

                Assert.That(ex.Message == "Invalid value! The age you entered is too high!");
            }

            [Test]
            public void countBMR_HeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(50, 301, 120));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(50, 301, 120));

                Assert.That(ex.Message == "Invalid value! The height you entered is too high!");
            }

            [Test]
            public void countBMR_WeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRWoman(50, 120, 301));
                ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMRMan(50, 120, 301));

                Assert.That(ex.Message == "Invalid value! The weight you entered is too high!");
            }

            [Test]
            public void countBMR_HeightDoubleWeightDouble_Calculated()
            {
                double BMRW = cal.countBMRWoman(23,150.5, 50.5);
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

            [OneTimeTearDown]
            public void tearDown()
            {
                cal = null;
            }
        }
    }
}
