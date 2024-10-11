// ------------------------------------------------------------------------------------------
//  <copyright file = "IsTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Test;

public static class IsTestData
{
    public static TheoryData<Is<bool>, bool, IMatch<bool>?> CreateMatchTestData()
    {
        return new TheoryData<Is<bool>, bool, IMatch<bool>?>()
        {
            { new Is<bool>(true), true, new OneElementMatch<bool>(true) },
            { new Is<bool>(true), false, null },
            { new Is<bool>(false), true, null },
            { new Is<bool>(false), false, new OneElementMatch<bool>(false) },
        };
    }
}