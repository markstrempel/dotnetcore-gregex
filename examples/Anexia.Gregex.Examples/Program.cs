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

var prefixMatches = matcher.FindMatches(anyAtLeastOnce, ['a', 'a', 'a']).ToArray();
Console.WriteLine($"Found: {prefixMatches.Length} matches for at least one any.");
Console.WriteLine(string.Join("\n", prefixMatches.AsEnumerable()));
