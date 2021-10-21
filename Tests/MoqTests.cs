using Core;
using Moq;
using NUnit.Framework;
using System;

namespace Tests
{
    public class MoqTests : StringWorkerTests
    {
        private Mock<IStringUtility> moqMock;
        private StringsWorker sut;

        public MoqTests()
        {
            moqMock = new Mock<IStringUtility>();
            sut = new StringsWorker(moqMock.Object);
        }

        [SetUp]
        public void Setup()
        {
            moqMock.Reset();
        }

        [Test]
        public override void TransformArray_Should_ThrowException_When_ArrayIsNull()
        {
            moqMock.Setup(_ => _.TransformAll((string[])null))
             .Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => sut.TransformArray((string[])null));
        }

        [Test]
        public override void TransformSingleItems_Should_ApplyCorrectTransformations()
        {
            moqMock.Setup(_ => _.Transform(It.IsAny<string>())).Returns("hello");
            moqMock.Setup(_ => _.Transform(It.Is<string>(s => s.StartsWith("IT")))).Returns("ciao");

            var result = sut.TransformSingleItems(new string[] { "IT-hey", "FR-salut", "IT-salve" });

            CollectionAssert.AreEquivalent(new string[] { "ciao", "hello", "ciao" }, result);
        }

        [Test]
        public override void TransformSingleItems_Should_TransformEveryItem()
        {
            sut.TransformSingleItems(new string[] { "a", "b", "c" });

            moqMock.Verify(_ => _.Transform(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public override void TransformString_Should_CallTransformer()
        {
            // Arrange
            moqMock.Setup(_ => _.Transform(It.IsAny<string>()))
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            moqMock.Verify(_ => _.Transform("hello"));
        }

        [Test]
        public override void TransformString_Should_TransformString()
        {
            // Arrange
            moqMock.Setup(_ => _.Transform(It.IsAny<string>()))
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            Assert.AreEqual("transformed", newString);
        }
    }
}