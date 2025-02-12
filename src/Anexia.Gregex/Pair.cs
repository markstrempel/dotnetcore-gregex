// ------------------------------------------------------------------------------------------
//  <copyright file = "Pair.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

internal record Pair<T>(IGregex<T> FirstExpression, IGregex<T> SecondExpression) : IGregex<T>
{
    public IMatch<T>? CreateMatch(T element)
    {
        if (FirstExpression.CreateMatch(element) is { } initialMatch)
        {
            return new RepeatMatch<T>(SecondExpression, initialMatch, 2);
        }

        return null;
    }
}