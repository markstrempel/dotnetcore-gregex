// ------------------------------------------------------------------------------------------
//  <copyright file = "Matcher.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


using System.Collections.Immutable;

namespace Anexia.Gregex;

public sealed class Matcher<T>
{
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
                if (partialMatch.IsFinishable())
                {
                    yield return partialMatch.Finish();
                }
            }
        }
    }

    private IEnumerable<IMatch<T>> ProcessPartialMatches<TInput>(IReadOnlyCollection<IMatch<T>> partialMatches,
        TInput element) where TInput : T
    {
        return partialMatches.Where(match => match.IsExtendable(element)).Select(match => match.Extend(element));
    }
}