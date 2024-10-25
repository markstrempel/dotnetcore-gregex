// ------------------------------------------------------------------------------------------
//  <copyright file = "IsExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Examples;

/// <summary>
/// Example for matching an element exactly using the <see cref="Gregex.Is{T}"/> method.
/// </summary>
public static class IsExample
{
    public static void Main()
    {
        var listOfWords = new List<string>()
        {
            "Hello",
            "World",
            "This",
            "Is",
            "And",
            "Test",
            "Example",
            "List",
            "With",
            "More",
            "Words",
            "Like",
            "These",
            "And",
            "Those"
        };

        var gregex = Gregex.Is("And");

        var matcher = new Matcher<string>();

        var matches = matcher.FindMatches(gregex, listOfWords);
        
        Console.WriteLine(string.Join(Environment.NewLine, matches));
    }
}