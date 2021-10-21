namespace Tests
{
    public abstract class StringWorkerTests
    {
        public abstract void TransformArray_Should_ThrowException_When_ArrayIsNull();

        public abstract void TransformSingleItems_Should_ApplyCorrectTransformations();

        public abstract void TransformSingleItems_Should_TransformEveryItem();

        public abstract void TransformString_Should_CallTransformer();

        public abstract void TransformString_Should_TransformString();
    }
}