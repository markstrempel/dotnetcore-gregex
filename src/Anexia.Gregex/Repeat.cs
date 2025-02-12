// ------------------------------------------------------------------------------------------
//  <copyright file = "Repeat.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

internal record Repeat<T>(IGregex<T> Gregex, int? Times): IGregex<T>
{
    public IMatch<T>? CreateMatch(T element)
    {
        if (Gregex.CreateMatch(element) is { } match)
        {
            return new RepeatMatch<T>(Gregex, match, Times);
        }

        return null;
    }
}