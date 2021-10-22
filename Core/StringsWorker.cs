using System.Linq;

namespace Core
{
    public interface IStringUtility
    {
        string Transform(string originalString);

        string[] TransformAll(string[] allStrings);
    }

    public class StringsWorker
    {
        private readonly IStringUtility _stringUtility;

        public StringsWorker(IStringUtility stringUtility)
            => _stringUtility = stringUtility;

        public string[] TransformArray(string[] items)
            => _stringUtility.TransformAll(items);

        public string[] TransformSingleItems(string[] items)
            => items.Select(i => _stringUtility.Transform(i)).ToArray();

        public string TransformString(string originalString)
            => _stringUtility.Transform(originalString);
    }
}