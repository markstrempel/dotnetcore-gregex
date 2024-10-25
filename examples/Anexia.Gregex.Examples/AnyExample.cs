// ------------------------------------------------------------------------------------------
//  <copyright file = "AnyExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------


namespace Anexia.Gregex.Examples;

/// <summary>
/// Example for how to use the <see cref="Gregex.Any{T}"/> method for matching any element.
/// </summary>
public static class AnyExample
{
    public static void Main()
    {
        var listOfWords = new List<string>()
        {
            "Hello",
            "World",
            "This",
            "Is",
            "A",
            "Test",
            "For",
            "Any",
            "Regex"
        };
        var anyString = Gregex.Any<string>();

        var matcher = new Matcher<string>();

        var matches = matcher.FindMatches(anyString, listOfWords);
        
        Console.WriteLine(string.Join(Environment.NewLine, matches));

    }
}