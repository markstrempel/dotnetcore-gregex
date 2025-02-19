// ------------------------------------------------------------------------------------------
//  <copyright file = "RepeatMatchTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Test;

public sealed class RepeatMatchTest
{
    [Theory]
    [MemberData(nameof(RepeatMatchTestData.IsCompletableExamples), MemberType = typeof(RepeatMatchTestData))]
    public void IsCompletable<T>(IMatch<T> match, bool isCompletable)
    {
        var actualIsCompletable = match.IsCompletable();
        
        Assert.Equal(isCompletable, actualIsCompletable);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.FinishExamples), MemberType = typeof(RepeatMatchTestData))]
    public void Finish<T>(IMatch<T> match, Match<T> expectedMatch)
    {
        var actualMatch = match.Finish();
        
        Assert.Equal(expectedMatch, actualMatch);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.IsExtendableExamples), MemberType = typeof(RepeatMatchTestData))]
    public void IsExtendable<T>(IMatch<T> match, T element, bool expectedIsExtendable)
    {
        var actualIsExtendable = match.IsExtendable(element);
        
        Assert.Equal(expectedIsExtendable, actualIsExtendable);
    }

    [Theory]
    [MemberData(nameof(RepeatMatchTestData.ExtendExamples), MemberType = typeof(RepeatMatchTestData))]
    public void Extend<T>(IMatch<T> match, T element, IEnumerable<IMatch<T>> expectedMatch)
    {
        var actualMatch = match.Extend(element);
        
        Assert.Equal(expectedMatch, actualMatch);
    }
}