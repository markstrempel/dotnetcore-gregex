// ------------------------------------------------------------------------------------------
//  <copyright file = "TestTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

using Moq;

namespace Anexia.Gregex.Test;

public static class RepeatTestData
{
    public static TheoryData<IGregex<bool>, bool, IMatch<bool>?> CreateMatchTestData()
    {
        var mockSubExpression = new Mock<IGregex<bool>>();
        var mockMatch = new Mock<IMatch<bool>>();
        
        var initialMatch = mockMatch.Object;

        mockSubExpression.Setup(gregex => gregex.CreateMatch(true)).Returns(initialMatch);

        var subExpression = mockSubExpression.Object;
        
        return new TheoryData<IGregex<bool>, bool, IMatch<bool>?>()
        {
            { new Repeat<bool>(subExpression, 2), true, new RepeatMatch<bool>(subExpression, initialMatch, 2) },
            { new Repeat<bool>(subExpression, 2), false, null },
        };
    }
}