// ------------------------------------------------------------------------------------------
//  <copyright file = "Gregex.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

/// <summary>
/// Methods for creating gregex expressions.
/// </summary>
public static class Gregex
{
    /// <summary>
    /// Creates an expression that matches if an element is equal to the given value.
    /// </summary>
    /// <param name="expectedValue">The value to match.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches exactly <paramref name="expectedValue"/>.</returns>
    public static IGregex<T> Is<T>(T expectedValue) => new Test<T>(element => Equals(expectedValue, element));

    /// <summary>
    /// Creates an expression that matches all (sub-) sequences that match <paramref name="gregexToRepeat"/>
    /// consecutively for <paramref name="numberOfTimes"/> times.
    /// </summary>
    /// <param name="gregexToRepeat">The expression to repeat.</param>
    /// <param name="numberOfTimes">How often the expression should match.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>A new expression that checks for consecutive matches.</returns>
    public static IGregex<T> Times<T>(this IGregex<T> gregexToRepeat, int numberOfTimes) =>
        new Repeat<T>(gregexToRepeat, numberOfTimes);

    /// <summary>
    /// Creates an expression that matches if the given expression is repeated at least once.
    /// </summary>
    /// <param name="gregexToRepeat">The expression that has to match at least once.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches if <paramref name="gregexToRepeat"/> matches at least once.</returns>
    public static IGregex<T> AtLeastOnce<T>(this IGregex<T> gregexToRepeat) =>
        new Repeat<T>(gregexToRepeat, null);

    /// <summary>
    /// Creates an expression that matches any element of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches any element of type <typeparamref name="T"/>.</returns>
    public static IGregex<T> Any<T>() => new Any<T>();

    /// <summary>
    /// Creates an expression that matches when the first expression is immediately followed by the second expression.
    /// </summary>
    /// <param name="first">The first expression to be matched.</param>
    /// <param name="second">The second expression that follows the first expression.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches sequences that contain <paramref name="first"/> before
    /// <paramref name="second"/>.</returns>
    public static IGregex<T> FollowedBy<T>(this IGregex<T> first, IGregex<T> second) => new Pair<T>(first, second);

    /// <summary>
    /// Creates an expression that matches a sequence of expressions in the specified order.
    /// </summary>
    /// <param name="first">The first expression in the sequence to be matched.</param>
    /// <param name="exps">The subsequent expressions in the sequence to follow the first expression.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches a sequence of expressions in the specified order, starting with
    /// <paramref name="first"/> and followed by <paramref name="exps"/>.</returns>
    public static IGregex<T> Pattern<T>(IGregex<T> first, params IGregex<T>[] exps)
        => exps.Aggregate(first, (lastExpression, nextExpression) => lastExpression.FollowedBy(nextExpression));

    /// <summary>
    /// Creates an expression that matches elements based on the provided predicate function.
    /// </summary>
    /// <param name="testFunction">A function to determine if an element matches.</param>
    /// <typeparam name="T">The type of elements that can be matched.</typeparam>
    /// <returns>An expression that matches elements satisfying the provided <paramref name="testFunction"/>.</returns>
    public static IGregex<T> Test<T>(Func<T, bool> testFunction) => new Test<T>(testFunction);

    /// <summary>
    /// Creates an expression that matches if an element is of the specified subtype.
    /// </summary>
    /// <typeparam name="TElements">The base type of elements that can be matched.</typeparam>
    /// <typeparam name="TSubtype">The specific subtype of the elements to match.</typeparam>
    /// <returns>An expression that matches elements of type <typeparamref name="TSubtype"/>.</returns>
    public static IGregex<TElements> TypeOf<TElements, TSubtype>() where TSubtype : TElements =>
        new Test<TElements>(element => element is TSubtype);
}