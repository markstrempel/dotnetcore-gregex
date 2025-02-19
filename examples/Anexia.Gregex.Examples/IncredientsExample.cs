// ------------------------------------------------------------------------------------------
//  <copyright file = "IncredientsExample.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

namespace Anexia.Gregex.Examples;

public static class IncredientsExample
{
    public static void Main()
    {
        var list = new List<IRecipeIngredient>()
        {
            new Chocolate(200),
            new Flour(50),
            new Milk(150),
            new Chocolate(120),
            new Chocolate(100),
            new Flour(200),
            new Milk(150),
            new Chocolate(70),
            new Milk(100),
            new Flour(250),
            new Milk(100),
        };

        var grex = Gregex.TypeOf<IRecipeIngredient, Milk>().FollowedBy(Gregex.Any<IRecipeIngredient>().AtLeastOnce())
            .FollowedBy(Gregex.TypeOf<IRecipeIngredient, Milk>());

        var matcher = new Matcher<IRecipeIngredient>();

        var matches = matcher.FindMatches(grex, list);

        Console.WriteLine(string.Join(Environment.NewLine, matches));
    }
    
    interface IRecipeIngredient
    {
        public int Quantity { get; }
    }

    private class Chocolate(int quantity) : IRecipeIngredient
    {
        public int Quantity { get; } = quantity;
        public override string ToString() => $"{Quantity}g Chocolate";
    }

    private class Flour(int quantity) : IRecipeIngredient
    {
        public int Quantity { get; } = quantity;
        public override string ToString() => $"{Quantity}g Flour";
    }

    private class Milk(int quantity) : IRecipeIngredient
    {
        public int Quantity { get; } = quantity;
        public override string ToString() => $"{Quantity}g Milk";
    }
}