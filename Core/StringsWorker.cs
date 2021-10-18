using System;

namespace Core
{
    public interface IStringUtility
    {
        string Transform(string originalString);
    }

    public class StringsWorker
    {
        private readonly IStringUtility _stringUtility;

        public StringsWorker(IStringUtility stringUtility)
            => _stringUtility = stringUtility;

        public string TransformString(string originalString)
        {
            return _stringUtility.Transform(originalString);
        }
    }
}