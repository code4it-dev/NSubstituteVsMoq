using Core;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class NSubstituteTests : StringWorkerTests
    {
        private IStringUtility mockStringUtils;
        private StringsWorker sut;

        public NSubstituteTests()
        {
            mockStringUtils = Substitute.For<IStringUtility>();
            sut = new StringsWorker(mockStringUtils);
        }

        [Test]
        public override void TransformString_Should_CallTransformer()
        {
            // Arrange
            mockStringUtils.Transform(Arg.Any<string>())
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            mockStringUtils.Received().Transform("hello");
        }

        [Test]
        public override void TransformString_Should_TransformString()
        {
            // Arrange
            mockStringUtils.Transform(Arg.Any<string>())
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            Assert.AreEqual("transformed", newString);
        }
    }
}