// ------------------------------------------------------------------------------------------
//  <copyright file = "Gregex.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex;

public static class Gregex
{
    public static IGregex<T> Is<T>(T element) => new Is<T>(element);

    public static IGregex<T> Times<T>(this IGregex<T> gregexToRepeat, int numberOfTimes) =>
        new Repeat<T>(gregexToRepeat, numberOfTimes);
    
    public static IGregex<T> AtLeastOnce<T>(this IGregex<T> gregexToRepeat) =>
        new Repeat<T>(gregexToRepeat, null);
    
    public static IGregex<T> Any<T>() => new Any<T>();
}