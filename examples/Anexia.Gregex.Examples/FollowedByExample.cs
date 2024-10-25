// ------------------------------------------------------------------------------------------
//  <copyright file = "FollowedByExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Examples;

/// <summary>
/// Example of how to use the <see cref="Gregex.FollowedBy{T}"/> method to match to consecutive elements.
/// </summary>
public static class FollowedByExample
{
    public static void Main()
    {
        var listOfWords = new List<string>
        {
            "This", "is", "a", "test", "of", "Gregex", "followed", "by", "a",
            "example", "one", "more", "time", "and", "then",
            "we'll", "see", "if", "it's", "working", "This", "is", "not", "a", "test"
        };

        var aTest = Gregex.Is("a").FollowedBy(Gregex.Is("test"));

        var matcher = new Matcher<string>();

        var matches = matcher.FindMatches(aTest, listOfWords);
        
        Console.WriteLine(string.Join(Environment.NewLine, matches));
    }
}