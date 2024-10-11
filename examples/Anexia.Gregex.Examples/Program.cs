using Anexia.Gregex;

var fooBar = "FooBarFooBarFoo".ToCharArray();

var twoOs = Gregex.Is('o').Times(2);

var anyChar = Gregex.Any<char>();

var matcher = new Matcher<char>();

var oMatches = matcher.FindMatches(twoOs, fooBar).ToArray();

Console.WriteLine($"Found: {oMatches.Length} os.");
Console.WriteLine(string.Join("\n", oMatches.AsEnumerable()));

var anyMatches = matcher.FindMatches(anyChar, fooBar).ToArray();

Console.WriteLine($"Found: {anyMatches.Length} matches for any.");
Console.WriteLine(string.Join("\n", anyMatches.AsEnumerable()));

var anyAtLeastOnce = Gregex.Is('a').AtLeastOnce();

var anyAtLeastOnceMatches = matcher.FindMatches(anyAtLeastOnce, ['a', 'a', 'a']).ToArray();
Console.WriteLine($"Found: {anyAtLeastOnceMatches.Length} matches for at least one any.");
Console.WriteLine(string.Join("\n", anyAtLeastOnceMatches.AsEnumerable()));

var oFollowedByB = Gregex.Is('o').FollowedBy(Gregex.Is('B'));

var oFollowedByBMatches = matcher.FindMatches(oFollowedByB, fooBar).ToArray();
Console.WriteLine($"Found: {oFollowedByBMatches.Length} matches for oB.");
Console.WriteLine(string.Join("\n", oFollowedByBMatches.AsEnumerable()));

var anyThinkBeforeF = Gregex.Pattern(Gregex.Any<char>(), Gregex.Is('F'));

var anyThinkBeforeFMatches = matcher.FindMatches(anyThinkBeforeF, fooBar).ToArray();
Console.WriteLine($"Found: {anyThinkBeforeFMatches.Length} matches for *F.");
Console.WriteLine(string.Join("\n", anyThinkBeforeFMatches.AsEnumerable()));
