using Humanizer;
namespace psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class StringExtensions {

    public static string ToSnakeCase(this string text) {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator enumerator)
        {
            if(!enumerator.MoveNext()) yield break; //stop iteration and exit the iterator block
            yield return char.ToLower(enumerator.Current);
            
            while(enumerator.MoveNext())
                if (char.IsUpper(enumerator.Current))
                {
                    yield return '_';
                    yield return char.ToLower(enumerator.Current);
                }
                else
                {
                    yield return enumerator.Current;
                }
            
        }
    }

    public static string ToPlural(this string text) {
        return text.Pluralize(false);
    }
    
}