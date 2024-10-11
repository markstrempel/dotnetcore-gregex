// ------------------------------------------------------------------------------------------
//  <copyright file = "IGregex.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public interface IGregex<T>
{
    public IMatch<T>? CreateMatch(T element);
}