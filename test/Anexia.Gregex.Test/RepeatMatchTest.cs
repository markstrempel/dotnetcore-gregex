// ------------------------------------------------------------------------------------------
//  <copyright file = "RepeatMatchTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Test;

public sealed class RepeatMatchTest
{
    [Theory]
    [MemberData(nameof(RepeatMatchTestData.IsFinishableExamples), MemberType = typeof(RepeatMatchTestData))]
    public void IsFinishable<T>(RepeatMatch<T> match, bool isFinishable)
    {
        var actualIsFinishable = match.IsFinishable();
        
        Assert.Equal(isFinishable, actualIsFinishable);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.FinishExamples), MemberType = typeof(RepeatMatchTestData))]
    public void Finish<T>(RepeatMatch<T> match, Match<T> expectedMatch)
    {
        var actualMatch = match.Finish();
        
        Assert.Equal(expectedMatch, actualMatch);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.IsExtendableExamples), MemberType = typeof(RepeatMatchTestData))]
    public void IsExtendable<T>(RepeatMatch<T> match, T element, bool expectedIsExtendable)
    {
        var actualIsExtendable = match.IsExtendable(element);
        
        Assert.Equal(expectedIsExtendable, actualIsExtendable);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.ExtendExamples), MemberType = typeof(RepeatMatchTestData))]
    public void Extend<T>(RepeatMatch<T> match, T element, IMatch<T> expectedMatch)
    {
        var actualMatch = match.Extend(element);
        
        Assert.Equal(expectedMatch, actualMatch);
    }
}