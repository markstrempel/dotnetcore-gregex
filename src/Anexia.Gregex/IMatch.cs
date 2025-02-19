// ------------------------------------------------------------------------------------------
//  <copyright file = "Match.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

/// <summary>
/// Base interface for partial matches. 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMatch<T>
{
    /// <summary>
    /// Indicates whether the current match is complete.
    /// </summary>
    /// <returns></returns>
    bool IsCompletable();
    
    /// <summary>
    /// Finishes the current partial match and creates a final match.
    /// </summary>
    /// <returns>The complete match.</returns>
    Match<T> Finish();

    /// <summary>
    /// Indicates whether the current match can be extended by <paramref name="nextElement"/>.
    /// </summary>
    /// <param name="nextElement">The next element of the sequencing.</param>
    /// <returns>True if the match can be extended.</returns>
    bool IsExtendable(T nextElement);

    /// <summary>
    /// Extends the current partial match and produces a new (partial) match that includes <paramref name="nextElement"/>.
    /// </summary>
    /// <param name="nextElement">The next element of the sequence.</param>
    /// <returns>The new partial match.</returns>
    IEnumerable<IMatch<T>> Extend(T nextElement);
}