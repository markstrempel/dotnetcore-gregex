// ------------------------------------------------------------------------------------------
//  <copyright file = "RepeatTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Test;

public sealed class RepeatTest
{
    [Theory]
    [MemberData(nameof(RepeatTestData.CreateMatchTestData), MemberType = typeof(RepeatTestData))]
    public void CreateMatch<T>(Repeat<T> repeat, T value, IMatch<T>? expectedValue)
    {
        var actualMatch = repeat.CreateMatch(value);
        
        Assert.Equal(expectedValue, actualMatch);
    }
}