// ------------------------------------------------------------------------------------------
//  <copyright file = "OneElementMatch.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public record OneElementMatch<T>(T Element) : IMatch<T>
{
    public bool IsFinishable() => true;

    public Match<T> Finish() => new([Element]);

    public bool IsExtendable(T nextElement) => false;
    public IMatch<T> Extend(T nextElement)
    {
        throw new InvalidOperationException();
    }
}