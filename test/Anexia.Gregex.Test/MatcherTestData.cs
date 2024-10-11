// ------------------------------------------------------------------------------------------
//  <copyright file = "MatcherTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Test;

public static class MatcherTestData
{
    public static TheoryData<Matcher<int>, IGregex<int>, IEnumerable<int>, IEnumerable<Match<int>>> FindMatches()
    {
        var matcher = new Matcher<int>();

        var elementValue = 2;
        var expression = Gregex.Is(elementValue);

        return new TheoryData<Matcher<int>, IGregex<int>, IEnumerable<int>, IEnumerable<Match<int>>>()
        {
            { matcher, expression, [], [] },
            { matcher, expression, [1], [] },
            { matcher, expression, [elementValue], [new Match<int>([elementValue])] },
            { matcher, expression, [1, elementValue], [new Match<int>([elementValue])] },
            { matcher, expression, [elementValue, 1], [new Match<int>([elementValue])] },
            { matcher, expression, [1, elementValue, 1], [new Match<int>([elementValue])] },
            { matcher, expression, [elementValue, elementValue], [new Match<int>([elementValue]), 
                new Match<int>([elementValue])] },
        };
    }
}