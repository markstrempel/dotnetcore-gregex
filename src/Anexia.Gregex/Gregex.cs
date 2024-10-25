// ------------------------------------------------------------------------------------------
//  <copyright file = "Gregex.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public static class Gregex
{
    public static IGregex<T> Is<T>(T expectedValue) => new Test<T>(element => Equals(expectedValue, element));

    public static IGregex<T> Times<T>(this IGregex<T> gregexToRepeat, int numberOfTimes) =>
        new Repeat<T>(gregexToRepeat, numberOfTimes);
    
    public static IGregex<T> AtLeastOnce<T>(this IGregex<T> gregexToRepeat) =>
        new Repeat<T>(gregexToRepeat, null);
    
    public static IGregex<T> Any<T>() => new Any<T>();
    
    public static IGregex<T> FollowedBy<T>(this IGregex<T> first, IGregex<T> second) => new Pair<T>(first, second);

    public static IGregex<T> Pattern<T>(IGregex<T> first, params IGregex<T>[] exps)
        => exps.Aggregate(first, (lastExpression, nextExpression) => lastExpression.FollowedBy(nextExpression));

    public static IGregex<T> Test<T>(Func<T, bool> testFunction) => new Test<T>(testFunction);
}