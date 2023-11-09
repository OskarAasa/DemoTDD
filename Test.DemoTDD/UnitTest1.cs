using DemoTDD;
using Xunit;

namespace Test.DemoTDD
{
    public class UnitTest1
    {

        [Fact]
        public void TestPersonNr()
        {
            //Arrange
            var verifyPn = new VerifyPersonNr();
            bool checkTrue;
            bool checkFalse;
            //Act
            checkTrue = verifyPn.ValidPersonNr("061010-3525");
            checkFalse = verifyPn.ValidPersonNr("061010-3521");
            //Assert
            Assert.True(checkTrue);
            Assert.False(checkFalse);
        }

        [Fact]
        public void TestSubract()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.Subtract(5, 2);
            //Assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void TestAdd()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.Add(10, 5);
            //Assert
            Assert.Equal(15, result);
        }
        [Fact]
        public void TestMultiply()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var result = calculator.Multiply(5,5);
            //Assert
            Assert.Equal(25, result);
        }
    }
}