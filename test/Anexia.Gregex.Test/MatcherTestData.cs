// ------------------------------------------------------------------------------------------
//  <copyright file = "MatcherTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

using CsCheck;

namespace Anexia.Gregex.Test;

public static class MatcherTestData
{
    public static TheoryData<Matcher<int>, IGregex<int>, IEnumerable<int>, IEnumerable<Match<int>>> FindMatches()
    {
        var matcher = new Matcher<int>();

        var elementValue = 5;
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

    public static TheoryData<Matcher<string>, Gen<(IGregex<string>, IEnumerable<string>)>> MatcherExecutesExpressionWithoutErrorsExamples()
    {
        var maxDepth = 5;
        var maxListLength = 20;
        var maxRepetitions = 10u;
        
        var simpleExpressions = Gen.OneOf(
            Gen.String.Select(Gregex.Is),
            Gen.String[0, 5].Select(prefix => Gregex.Test<string>(str => str.StartsWith(prefix))));

        var higherOrderExpressions = Gen.Recursive<IGregex<string>>((depth, genGregex) =>
        {
            if (depth == maxDepth)
            {
                return simpleExpressions;
            }
            var followedBy = genGregex.SelectMany(firstExpression => genGregex.Select(firstExpression.FollowedBy));
            var atLeastOnce = genGregex.Select(gregex => gregex.AtLeastOnce());
            var times = genGregex.SelectMany(exp =>
                Gen.UInt[0, maxRepetitions].Select(numberOfTimes => exp.Times((int)numberOfTimes)));

            return Gen.OneOf(followedBy, atLeastOnce, times, simpleExpressions);
        });
        
        var stringLists = Gen.String.Array[0, maxListLength];

        var expressionsAndLists =
            higherOrderExpressions.SelectMany(exp => stringLists.Select(strings => (exp, strings.AsEnumerable())));

        return new TheoryData<Matcher<string>, Gen<(IGregex<string>, IEnumerable<string>)>>()
        {
            { new Matcher<string>(), expressionsAndLists }
        };
    }
}