// ------------------------------------------------------------------------------------------
//  <copyright file = "RepeatMatchTestData.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

using System.Collections.Immutable;
using Moq;

namespace Anexia.Gregex.Test;

public static class RepeatMatchTestData
{
    public static TheoryData<IMatch<bool>, bool> IsCompletableExamples()
    {
        var subExpressionMock = new Mock<IGregex<bool>>();
        var completablePartialMatchMock = new Mock<IMatch<bool>>();
        completablePartialMatchMock.Setup(match => match.IsCompletable()).Returns(true);
        var notCompletablePartialMatchMock = new Mock<IMatch<bool>>();
        notCompletablePartialMatchMock.Setup(match => match.IsCompletable()).Returns(false);
        
        return new TheoryData<IMatch<bool>, bool>
        {
            { new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, 1) , true },
            { new RepeatMatch<bool>(subExpressionMock.Object, notCompletablePartialMatchMock.Object, 1) , false },
            { new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, null) , true },
            { new RepeatMatch<bool>(subExpressionMock.Object, notCompletablePartialMatchMock.Object, null) , false },
            { new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, 2) , false },
            {
                new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, 2,
                    ImmutableList.Create(new Match<bool>([true]))),
                true
            },
            {
                new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, 2,
                    ImmutableList.Create(new Match<bool>([true]), new Match<bool>([true]))),
                false
            },
            { new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, null) , true },
            {
                new RepeatMatch<bool>(subExpressionMock.Object, completablePartialMatchMock.Object, null,
                    ImmutableList.Create(new Match<bool>([true]), new Match<bool>([true]))),
                true
            },
        };
    }

    public static TheoryData<IMatch<bool>, Match<bool>> FinishExamples()
    {
        var subExpressionMock = new Mock<IGregex<bool>>();
        var finishablePartialMatchMock = new Mock<IMatch<bool>>();
        finishablePartialMatchMock.Setup(match => match.Finish()).Returns(new Match<bool>([true]));

        return new TheoryData<IMatch<bool>, Match<bool>>()
        {
            {
                new RepeatMatch<bool>(subExpressionMock.Object, finishablePartialMatchMock.Object, 1),
                new Match<bool>([true])
            },
            {
                new RepeatMatch<bool>(subExpressionMock.Object, finishablePartialMatchMock.Object, 1,
                    ImmutableList.Create(new Match<bool>([false]))),
                new Match<bool>([false, true])
            }
        };
    }
    
    public static TheoryData<IMatch<bool>, bool, bool> IsExtendableExamples()
    {
        var matchingTrueExpressionMock = new Mock<IGregex<bool>>();
        matchingTrueExpressionMock.Setup(gregex => gregex.CreateMatch(true)).Returns(new Mock<IMatch<bool>>().Object);
        var onTrueExtendablePartialMatchMock = new Mock<IMatch<bool>>();
        onTrueExtendablePartialMatchMock.Setup(match => match.IsExtendable(true)).Returns(true);
        
        var notExtendableCompletableMatchMock = new Mock<IMatch<bool>>();
        notExtendableCompletableMatchMock.Setup(match => match.IsCompletable()).Returns(true);
        
        var notExtendableNotFinishableMatchMock = new Mock<IMatch<bool>>();

        return new TheoryData<IMatch<bool>, bool, bool>
        {
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueExtendablePartialMatchMock.Object, 1),
                true, true
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, notExtendableCompletableMatchMock.Object, 1),
                true, false
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, notExtendableCompletableMatchMock.Object, 2),
                true, true
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, notExtendableNotFinishableMatchMock.Object, 2),
                true, false
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, notExtendableNotFinishableMatchMock.Object, 2),
                false, false
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueExtendablePartialMatchMock.Object, 2),
                false, false
            }
        };
    }

    public static TheoryData<IMatch<bool>, bool, IEnumerable<IMatch<bool>>> ExtendExamples()
    {
        var onTrueMatch = new Mock<IMatch<bool>>(MockBehavior.Strict).Object;
        
        var matchingTrueExpressionMock = new Mock<IGregex<bool>>(MockBehavior.Strict);
        matchingTrueExpressionMock.Setup(gregex => gregex.CreateMatch(true)).Returns(onTrueMatch);
        
        var onTrueExtendablePartialMatchMock = new Mock<IMatch<bool>>(MockBehavior.Strict);
        onTrueExtendablePartialMatchMock.Setup(match => match.IsCompletable()).Returns(true);
        onTrueExtendablePartialMatchMock.Setup(match => match.Finish()).Returns(new Match<bool>([true]));
        onTrueExtendablePartialMatchMock.Setup(match => match.IsExtendable(true)).Returns(true);
        onTrueExtendablePartialMatchMock.Setup(match => match.Extend(true)).Returns([onTrueMatch]);
        
        var notExtendableButFinishableMatchMock = new Mock<IMatch<bool>>();
        notExtendableButFinishableMatchMock.Setup(match => match.IsCompletable()).Returns(true);
        notExtendableButFinishableMatchMock.Setup(match => match.Finish()).Returns(new Match<bool>([true]));
        
        return new TheoryData<IMatch<bool>, bool, IEnumerable<IMatch<bool>>>()
        {
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueExtendablePartialMatchMock.Object, 2),
                true,
                [
                    new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueMatch, 2),
                    new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueMatch, 2,
                        ImmutableList.Create(new Match<bool>([true])))
                ]
            },
            {
                new RepeatMatch<bool>(matchingTrueExpressionMock.Object, notExtendableButFinishableMatchMock.Object, 2),
                true,
                [new RepeatMatch<bool>(matchingTrueExpressionMock.Object, onTrueMatch, 2,
                    ImmutableList.Create(new Match<bool>([true])))]
            }
        };
    }
}