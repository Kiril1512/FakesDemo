using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakesDemo;
using FakesDemo.Fakes;
using Moq;
using Microsoft.QualityTools.Testing.Fakes;

namespace FakesDemoTests
{
    // https://stackoverflow.com/questions/25237971/how-to-write-unit-test-for-private-method-in-c-sharp-using-moq-framework
    // https://developercommunity.visualstudio.com/t/Fakes-Assembly-generating-error-Cannot/1551261?entry=problem&space=8&q=Fakes
    // https://docs.microsoft.com/en-us/visualstudio/test/isolating-code-under-test-with-microsoft-fakes?view=vs-2019

    [TestClass]
    public class FakesDemoTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Should return false, because no behaviour changed

            bool someFlag = SomePublicClass.DoSomething(false);

            Assert.IsFalse(someFlag);

            // Should return true since its mocked and same behaviour setuped

            ISomeClasses someClasses = BuildMockFromInterface();

            bool invertedFlag = someClasses.InvertFlag(true);

            Assert.IsFalse(invertedFlag);

            int someInt = someClasses.ReturnMeSomeInt();

            Assert.AreEqual(5, someInt);

            // Should return always true because the behaviour is changed by fakes

            using (ShimsContext.Create())
            {
                FakesDemo.Fakes.ShimSomePublicClass.DoSomethingBoolean = (value) =>
                {
                    return true;
                };

                bool flag = SomePublicClass.DoSomething(false);

                Assert.IsTrue(flag);
            }

            // Should return always 10 because the behaviour is changed by fakes (internal class)

            using (ShimsContext.Create())
            {
                FakesDemo.Fakes.ShimSomeClasses shimSomeClasses = new ShimSomeClasses();

                shimSomeClasses.ReturnMeSomeInt = () =>
                {
                    return 10;
                };

                SomeClasses classes = shimSomeClasses;

                int someClassesInt = classes.ReturnMeSomeInt();

                Assert.AreEqual(10, someClassesInt);
            }

            // Same but for interface

            using (ShimsContext.Create())
            {
                FakesDemo.Fakes.StubISomeClasses stubISomeClasses = new StubISomeClasses();

                stubISomeClasses.ReturnMeSomeInt = () =>
                {
                    return 10;
                };

                ISomeClasses classes = stubISomeClasses;

                int someClassesInt = classes.ReturnMeSomeInt();

                Assert.AreEqual(10, someClassesInt);
            }
        }

        private ISomeClasses BuildMockFromInterface()
        {
            Mock<ISomeClasses> mock = new Mock<ISomeClasses>();

            mock.Setup(mock => mock.InvertFlag(It.Is<bool>(flag => flag == true))).Returns(false);
            mock.Setup(mock => mock.InvertFlag(It.Is<bool>(flag => flag == false))).Returns(true);
            mock.Setup(mock => mock.ReturnMeSomeInt()).Returns(5);

            return mock.Object;
        }
    }
}
