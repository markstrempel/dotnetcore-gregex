// ------------------------------------------------------------------------------------------
//  <copyright file = "IsTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Test;

public sealed class IsTest
{
    [Theory]
    [MemberData(nameof(IsTestData.CreateMatchTestData), MemberType = typeof(IsTestData))]
    public void CreateMatch<T>(Is<T> isGregex, T value, IMatch<T>? expectedValue)
    {
        var actualMatch = isGregex.CreateMatch(value);
        
        Assert.Equal(expectedValue, actualMatch);
    }
}