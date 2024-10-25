// ------------------------------------------------------------------------------------------
//  <copyright file = "Test.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex;

public record Test<T>(Func<T, bool> Predicate) : IGregex<T>
{
    public IMatch<T>? CreateMatch(T element)
    {
        if (Predicate(element))
        {
            return new OneElementMatch<T>(element);
        }

        return null;
    }
}