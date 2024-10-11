// ------------------------------------------------------------------------------------------
//  <copyright file = "Match.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public interface IMatch<T>
{
    bool IsFinishable();
    Match<T> Finish();

    bool IsExtendable(T nextElement);

    IMatch<T> Extend(T nextElement);
}