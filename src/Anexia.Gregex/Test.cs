// ------------------------------------------------------------------------------------------
//  <copyright file = "Test.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

internal record Test<T>(Func<T, bool> Predicate) : IGregex<T>
{
    public IMatch<T>? CreateMatch(T element) => Predicate(element) ? new OneElementMatch<T>(element) : null;
}