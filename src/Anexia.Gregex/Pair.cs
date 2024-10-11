// ------------------------------------------------------------------------------------------
//  <copyright file = "Pair.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public record Pair<T>(IGregex<T> firstExpression, IGregex<T> secondExpression) : IGregex<T>
{
    public IMatch<T>? CreateMatch(T element)
    {
        if (firstExpression.CreateMatch(element) is { } initialMatch)
        {
            return new RepeatMatch<T>(secondExpression, initialMatch, 2);
        }

        return null;
    }
}