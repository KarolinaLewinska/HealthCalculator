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
                Assert.AreEqual(Math.Round(BMI, 2), BMIResult);
            }

            [Test]
            public void countBMI_HeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(0, 120));

                Assert.That(ex.Message == "Invalid value! Height must be greater than zero!");
            }

            [Test]
            public void countBMI_WeightLessThanOrEqualZero_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, 0));

                Assert.That(ex.Message == "Invalid value! Weight must be greater than zero!");
            }

            [Test]
            public void countBMI_HeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(350, 120));

                Assert.That(ex.Message == "Invalid value! The height you entered is too high!");
            }

            [Test]
            public void countBMI_WeightTooHigh_Exception()
            {
                var ex = Assert.Throws<ArgumentException>(
                    () => cal.countBMI(120, 350));

                Assert.That(ex.Message == "Invalid value! The weight you entered is too high!");
            }

            [TestCase(145, 55, "You're overweight! Take care of Your health!")]
            [TestCase(170, 60, "Congratulations! You're weight is proper!")]
            [TestCase(10, 60, "You have extreme obesity. Immediately contact with doctor!")]
            [TestCase(180, 55, "You're skinny! Contact with doctor!")]
            [TestCase(180, 100, "You have I class of obesity! Contact with doctor!")]
            public void countBMI_DifferentTips_Calculated(double height, double weight, String BMIResultText)
            {
                double BMI = cal.countBMI(height, weight);
                String BMITips = cal.showResultText(BMI);
                Assert.AreEqual(BMITips, BMIResultText);
            }

            //testy na różne inty i double

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

            [Test]
            public void countBMR_AgetLessThanOrEqualZero_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! Age must be greater than zero!"),
                    delegate {
                        cal.countBMRWoman(0, 120, 120);
                        cal.countBMRMan(0, 120, 120);
                    });
            }

            [Test]
            public void countBMR_HeightLessThanOrEqualZero_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! Height must be greater than zero!"),
                    delegate {
                        cal.countBMRWoman(20, 0, 120);
                        cal.countBMRMan(20, 0, 120);
                    });
            }

            [Test]
            public void countBMR_WeightLessThanOrEqualZero_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! Weight must be greater than zero!"),
                    delegate {
                        cal.countBMRWoman(20,120, 0);
                        cal.countBMRMan(20, 120, 0);
                    });
            }

            [Test]
            public void countBMR_AgeTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                    .And.Message.EqualTo("Invalid value! The age you entered is too high!"),
                    delegate {
                        cal.countBMRWoman(150, 120, 120);
                        cal.countBMRMan(150, 120, 120);
                    });
            }

            [Test]
            public void countBMR_HeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                   .And.Message.EqualTo("Invalid value! The height you entered is too high!"),
                   delegate {
                       cal.countBMRWoman(50, 350, 120);
                       cal.countBMRMan(50, 350, 120);
                   });
            }

            [Test]
            public void countBMR_WeightTooHigh_Exception()
            {
                Assert.Throws(Is.TypeOf<ArgumentException>()
                   .And.Message.EqualTo("Invalid value! The weight you entered is too high!"),
                   delegate {
                       cal.countBMRWoman(50, 120, 350);
                       cal.countBMRMan(50, 120, 350);
                   });
            }
        }
    }
}
