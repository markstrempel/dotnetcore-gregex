// ------------------------------------------------------------------------------------------
//  <copyright file = "TimesExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Examples;

/// <summary>
/// Example of how to use the <see cref="Gregex.Times{T}"/> method to match an element multiple times.
/// </summary>
public static class TimesExample
{
    public static void Main()
    {
        var listOfStringWithOneStringRepeated = new List<string>() 
        {
            "Hello", "World", "Hello", "Hello", "Hello"
        };

        var twoTimesHello = Gregex.Is("Hello").Times(2);

        var matcher = new Matcher<string>();

        var matches = matcher.FindMatches(twoTimesHello, listOfStringWithOneStringRepeated);
        
        Console.WriteLine(string.Join(Environment.NewLine, matches));
    }
}