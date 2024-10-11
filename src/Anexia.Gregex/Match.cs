// ------------------------------------------------------------------------------------------
//  <copyright file = "Match.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex;

public record Match<T>(IEnumerable<T> Elements)
{
    public virtual bool Equals(Match<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Elements.SequenceEqual(other.Elements);
    }

    public override int GetHashCode()
    {
        return Elements.GetHashCode();
    }

    public override string ToString()
    {
        return $"{nameof(Elements)}: [{string.Join(", ", Elements)}]";
    }
}