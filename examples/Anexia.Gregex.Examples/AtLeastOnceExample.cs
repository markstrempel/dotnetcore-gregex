// ------------------------------------------------------------------------------------------
//  <copyright file = "AtLeastOnceExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Examples;

/// <summary>
/// Example of how to use the <see cref="Gregex.AtLeastOnce{T}"/> method to match an element at least once.
/// </summary>
public static class AtLeastOnceExample
{
    public static void Main()
    {
        var listOfStringWithOneStringRepeated = new List<string>() 
        {
            "Hello", "World", "Hello", "Hello", "Hello"
        };

        var atLeastOneHello = Gregex.Is("Hello").AtLeastOnce();

        var matcher = new Matcher<string>();

        var matches = matcher.FindMatches(atLeastOneHello, listOfStringWithOneStringRepeated);
        
        Console.WriteLine(string.Join(Environment.NewLine, matches));
    }
}