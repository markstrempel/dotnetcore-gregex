// ------------------------------------------------------------------------------------------
//  <copyright file = "IGregex.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

/// <summary>
/// Base interface for expressions.
/// </summary>
/// <typeparam name="T">Type of elements that can be matched.</typeparam>
public interface IGregex<T>
{
    IMatch<T>? CreateMatch(T element);
}