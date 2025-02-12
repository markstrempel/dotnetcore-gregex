// ------------------------------------------------------------------------------------------
//  <copyright file = "TestTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Test;

public static class TestTestData
{
    public static TheoryData<IGregex<bool>, bool, IMatch<bool>?> CreateMatchTestData()
    {
        return new TheoryData<IGregex<bool>, bool, IMatch<bool>?>()
        {
            { new Test<bool>(value => value), true, new OneElementMatch<bool>(true) },
            { new Test<bool>(value => value), false, null },
            { new Test<bool>(value => !value), true, null },
            { new Test<bool>(value => !value), false, new OneElementMatch<bool>(false) },
        };
    }
}