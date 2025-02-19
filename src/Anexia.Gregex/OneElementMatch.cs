// ------------------------------------------------------------------------------------------
//  <copyright file = "OneElementMatch.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

internal record OneElementMatch<T>(T Element) : IMatch<T>
{
    public bool IsCompletable() => true;

    public Match<T> Finish() => new([Element]);

    public bool IsExtendable(T nextElement) => false;
    
    public IEnumerable<IMatch<T>> Extend(T nextElement)
    {
        throw new InvalidOperationException();
    }
}