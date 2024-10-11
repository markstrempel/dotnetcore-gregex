using Anexia.Gregex;

var testList = "FooBarFooBarFoo".ToCharArray();

var gregex = Gregex.Is('o').Times(2);

var matcher = new Matcher<char>();

var matches = matcher.FindMatches(gregex, testList).ToArray();

Console.WriteLine($"Found: {matches.Length} matches.");
Console.WriteLine(string.Join("\n", matches.AsEnumerable()));