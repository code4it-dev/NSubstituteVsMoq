using Core;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class MoqTests : StringWorkerTests
    {
        private Mock<IStringUtility> mockStringUtils;
        private StringsWorker sut;

        public MoqTests()
        {
            mockStringUtils = new Mock<IStringUtility>();
            sut = new StringsWorker(mockStringUtils.Object);
        }

        [Test]
        public override void TransformString_Should_CallTransformer()
        {
            // Arrange
            mockStringUtils.Setup(_ => _.Transform(It.IsAny<string>()))
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            mockStringUtils.Verify(_ => _.Transform("hello"));
        }

        [Test]
        public override void TransformString_Should_TransformString()
        {
            // Arrange
            mockStringUtils.Setup(_ => _.Transform(It.IsAny<string>()))
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            Assert.AreEqual("transformed", newString);
        }
    }
}