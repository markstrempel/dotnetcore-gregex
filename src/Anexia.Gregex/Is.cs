// ------------------------------------------------------------------------------------------
//  <copyright file = "Equals.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex;

public record Is<T>(T Value) : IGregex<T>
{
    public IMatch<T>? CreateMatch(T element)
    {
        if (Equals(Value, element))
        {
            return new IsMatch<T>(element);
        }

        return null;
    }
}