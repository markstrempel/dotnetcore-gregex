// ------------------------------------------------------------------------------------------
//  <copyright file = "Match.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex;

/// <summary>
/// Represents a match of an expression.
/// </summary>
/// <param name="Elements">The matched elements.</param>
/// <typeparam name="T">The type of the matched element.</typeparam>
public record Match<T>(IEnumerable<T> Elements)
{
    public virtual bool Equals(Match<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Elements.SequenceEqual(other.Elements);
    }

    public override int GetHashCode() => Elements.GetHashCode();

    public override string ToString() => $"{nameof(Elements)}: [{string.Join(", ", Elements)}]";
}