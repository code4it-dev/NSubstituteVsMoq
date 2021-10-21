using Core;
using NSubstitute;
using NUnit.Framework;
using System;
using NSubstitute.ExceptionExtensions;// Remember this using!

namespace Tests
{
    public class NSubstituteTests : StringWorkerTests
    {
        private IStringUtility nSubsMock;
        private StringsWorker sut;

        public NSubstituteTests()
        {
            nSubsMock = Substitute.For<IStringUtility>();
            sut = new StringsWorker(nSubsMock);
        }

        [SetUp]
        public void Setup()
        {
            nSubsMock.ClearReceivedCalls();
        }

        [Test]
        public override void TransformArray_Should_ThrowException_When_ArrayIsNull()
        {
            nSubsMock.TransformAll((string[])null)
             .Throws(new ArgumentException());

            Assert.Throws<ArgumentException>(() => sut.TransformArray((string[])null));
        }

        [Test]
        public override void TransformSingleItems_Should_ApplyCorrectTransformations()
        {
            nSubsMock.Transform(Arg.Any<string>()).Returns("hello");
            nSubsMock.Transform(Arg.Is<string>(s => s.StartsWith("IT"))).Returns("ciao");

            var result = sut.TransformSingleItems(new string[] { "IT-hey", "FR-salut", "IT-salve" });

            CollectionAssert.AreEquivalent(new string[] { "ciao", "hello", "ciao" }, result);
        }

        [Test]
        public override void TransformSingleItems_Should_TransformEveryItem()
        {
            sut.TransformSingleItems(new string[] { "a", "b", "c" });

            nSubsMock.Received(3).Transform(Arg.Any<string>());
        }

        [Test]
        public override void TransformString_Should_CallTransformer()
        {
            // Arrange
            nSubsMock.Transform(Arg.Any<string>())
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            nSubsMock.Received().Transform("hello");
        }

        [Test]
        public override void TransformString_Should_TransformString()
        {
            // Arrange
            nSubsMock.Transform(Arg.Any<string>())
                .Returns("transformed");

            //Act
            string newString = sut.TransformString("hello");

            //Assert

            Assert.AreEqual("transformed", newString);
        }
    }
}