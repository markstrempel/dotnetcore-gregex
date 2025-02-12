// ------------------------------------------------------------------------------------------
//  <copyright file = "TestTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Test;

public sealed class TestTest
{
    [Theory]
    [MemberData(nameof(TestTestData.CreateMatchTestData), MemberType = typeof(TestTestData))]
    public void CreateMatch<T>(IGregex<T> testGregex, T value, IMatch<T>? expectedValue)
    {
        var actualMatch = testGregex.CreateMatch(value);
        
        Assert.Equal(expectedValue, actualMatch);
    }
}