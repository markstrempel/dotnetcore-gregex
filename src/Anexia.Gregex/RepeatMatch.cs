// ------------------------------------------------------------------------------------------
//  <copyright file = "RepeatMatch.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

using System.Collections.Immutable;

namespace Anexia.Gregex;

internal record RepeatMatch<T>(
    IGregex<T> SubExpression,
    IMatch<T> PartialMatch,
    int? Times,
    IImmutableList<Match<T>> PreviousMatches) : IMatch<T>
{
    public RepeatMatch(IGregex<T> SubExpression, IMatch<T> PartialMatch, int? Times) : this(SubExpression, PartialMatch,
        Times, ImmutableList<Match<T>>.Empty)
    {
    }

    private bool IsMaxCountReached() => Times != null && PreviousMatches.Count == Times - 1;
    
    public bool IsCompletable() => (Times == null && PartialMatch.IsCompletable()) 
                                  || (PartialMatch.IsCompletable() && IsMaxCountReached());

    public Match<T> Finish()
    {
        var finalMatch = PartialMatch.Finish();
        return new Match<T>(PreviousMatches.Add(finalMatch).SelectMany(match => match.Elements));
    }

    public bool IsExtendable(T nextElement) => PartialMatch.IsExtendable(nextElement) ||
                                               (PartialMatch.IsCompletable() &&
                                                SubExpression.CreateMatch(nextElement) != null &&
                                                !IsMaxCountReached());

    public IEnumerable<IMatch<T>> Extend(T nextElement)
    {
        if (PartialMatch.IsExtendable(nextElement))
        {
            foreach (var match in PartialMatch.Extend(nextElement))
            {
                yield return this with { PartialMatch = match };
            }
        }

        if (PartialMatch.IsCompletable())
        {
            var subExpressionMatch = SubExpression.CreateMatch(nextElement);

            if (subExpressionMatch is not null)
            {
                yield return this with
                {
                    PartialMatch = subExpressionMatch,
                    PreviousMatches = PreviousMatches.Add(PartialMatch.Finish())
                };
            }   
        }
    }

    public virtual bool Equals(RepeatMatch<T>? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return SubExpression.Equals(other.SubExpression) && PartialMatch.Equals(other.PartialMatch) &&
               Times == other.Times && PreviousMatches.SequenceEqual(other.PreviousMatches);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SubExpression, PartialMatch, Times, PreviousMatches);
    }

    public override string ToString()
    {
        return
            $"{nameof(SubExpression)}: {SubExpression}, {nameof(PartialMatch)}: {PartialMatch}, {nameof(Times)}: {Times}, {nameof(PreviousMatches)}: [{string.Join(",", PreviousMatches)}]";
    }
}