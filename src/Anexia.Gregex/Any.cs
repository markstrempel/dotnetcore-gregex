// ------------------------------------------------------------------------------------------
//  <copyright file = "Any.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public record Any<T>() : IGregex<T>
{
    public IMatch<T> CreateMatch(T element) => new OneElementMatch<T>(element);
}