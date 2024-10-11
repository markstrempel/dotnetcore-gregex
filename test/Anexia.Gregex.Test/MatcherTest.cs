namespace Anexia.Gregex.Test;

public class MatcherTest
{
    [Theory]
    [MemberData(nameof(MatcherTestData.FindMatches), MemberType = typeof(MatcherTestData))]
    public void FindMatches<T>(Matcher<T> matcher, IGregex<T> exp, IEnumerable<T> elements, IEnumerable<Match<T>> expectedMatches)
    {
        var actualMatches = matcher.FindMatches(exp, elements);

        Assert.Equal(expectedMatches, actualMatches);
    }
}