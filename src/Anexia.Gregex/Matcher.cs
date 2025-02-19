// ------------------------------------------------------------------------------------------
//  <copyright file = "Matcher.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


using System.Collections.Immutable;

namespace Anexia.Gregex;

/// <summary>
/// Class that matches sequences and expressions.
///
/// <seealso cref="IGregex{T}"/> <seealso cref="Match{T}"/>
/// </summary>
/// <typeparam name="T">The type of the elements that can be matched.</typeparam>
public sealed class Matcher<T>
{
    /// <summary>
    /// Executes the given <paramref name="gregex"/> against the sequence <paramref name="elements"/>. 
    /// </summary>
    /// <param name="gregex">The expression to execute.</param>
    /// <param name="elements">The elements to process.</param>
    /// <typeparam name="TInput">The type of the elements in <paramref name="elements"/>.</typeparam>
    /// <returns>A sequence of all matches.</returns>
    public IEnumerable<Match<T>> FindMatches<TInput>(IGregex<T> gregex, IEnumerable<TInput> elements) where TInput : T
    {
        IImmutableList<IMatch<T>> partialMatches = ImmutableList<IMatch<T>>.Empty;
        
        foreach (var element in elements)
        {
            partialMatches = ProcessPartialMatches(partialMatches, element).ToImmutableArray();
            
            var potentialMatch = gregex.CreateMatch(element);

            if (potentialMatch is not null)
            {
                partialMatches = partialMatches.Add(potentialMatch);
            }

            foreach (var partialMatch in partialMatches)
            {
                if (partialMatch.IsCompletable())
                {
                    yield return partialMatch.Finish();
                }
            }
        }
    }

    private static IEnumerable<IMatch<T>> ProcessPartialMatches<TInput>(IReadOnlyCollection<IMatch<T>> partialMatches,
        TInput element) where TInput : T =>
        partialMatches.Where(match => match.IsExtendable(element)).SelectMany(match => match.Extend(element));
}