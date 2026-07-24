// <copyright file="SyntaxFactsTests.cs" company="GSharp">
// Copyright (C) GSharp Authors. All rights reserved.
// </copyright>

using System;
using System.Linq;
using GSharp.Core.CodeAnalysis.Syntax;
using Xunit;

namespace GSharp.Core.Tests.CodeAnalysis.Syntax;

public class SyntaxFactsTests
{
    [Theory]
    [InlineData("break", SyntaxKind.BreakKeyword)]
    [InlineData("函数", SyntaxKind.FuncKeyword)]
    [InlineData("func", SyntaxKind.FuncKeyword)]
    [InlineData("类", SyntaxKind.ClassKeyword)]
    [InlineData("class", SyntaxKind.ClassKeyword)]
    [InlineData("如果", SyntaxKind.IfKeyword)]
    [InlineData("否则", SyntaxKind.ElseKeyword)]
    [InlineData("否则如果", SyntaxKind.ElseKeyword)]
    [InlineData("真", SyntaxKind.TrueKeyword)]
    [InlineData("假", SyntaxKind.FalseKeyword)]
    [InlineData("包", SyntaxKind.PackageKeyword)]
    [InlineData("导入", SyntaxKind.ImportKeyword)]
    [InlineData("变", SyntaxKind.VarKeyword)]
    [InlineData("定", SyntaxKind.LetKeyword)]
    [InlineData("notAKeyword", SyntaxKind.IdentifierToken)]
    public void GetKeywordKind_ReturnsExpected(string text, SyntaxKind expected)
    {
        Assert.Equal(expected, SyntaxFacts.GetKeywordKind(text));
    }

    [Theory]
    [InlineData(SyntaxKind.PlusToken, "+")]
    [InlineData(SyntaxKind.FuncKeyword, "函数")]
    [InlineData(SyntaxKind.ClassKeyword, "类")]
    [InlineData(SyntaxKind.IfKeyword, "如果")]
    [InlineData(SyntaxKind.ElseKeyword, "否则")]
    [InlineData(SyntaxKind.TrueKeyword, "真")]
    [InlineData(SyntaxKind.FalseKeyword, "假")]
    [InlineData(SyntaxKind.PackageKeyword, "包")]
    [InlineData(SyntaxKind.ImportKeyword, "导入")]
    [InlineData(SyntaxKind.VarKeyword, "变")]
    [InlineData(SyntaxKind.LetKeyword, "定")]
    [InlineData(SyntaxKind.ColonEqualsToken, ":=")]
    [InlineData(SyntaxKind.DotDotToken, "..")]
    public void GetText_ReturnsExpected(SyntaxKind kind, string expected)
    {
        Assert.Equal(expected, SyntaxFacts.GetText(kind));
    }

    [Fact]
    public void GetText_Unknown_ReturnsNull()
    {
        Assert.Null(SyntaxFacts.GetText(SyntaxKind.IdentifierToken));
    }

    [Fact]
    public void GetText_RoundTripsThroughGetKeywordKind()
    {
        var keywordKinds = Enum.GetValues<SyntaxKind>()
            .Where(k => k.ToString().EndsWith("Keyword", StringComparison.Ordinal));
        foreach (var kind in keywordKinds)
        {
            var text = SyntaxFacts.GetText(kind);
            Assert.NotNull(text);
            Assert.Equal(kind, SyntaxFacts.GetKeywordKind(text));
        }
    }

    [Fact]
    public void GetBinaryOperatorKinds_AreNonZeroPrecedence()
    {
        var ops = SyntaxFacts.GetBinaryOperatorKinds().ToArray();
        Assert.NotEmpty(ops);
        Assert.All(ops, k => Assert.True(k.GetBinaryOperatorPrecedence() > 0));
    }

    [Fact]
    public void GetUnaryOperatorKinds_AreNonZeroPrecedence()
    {
        var ops = SyntaxFacts.GetUnaryOperatorKinds().ToArray();
        Assert.NotEmpty(ops);
        Assert.All(ops, k => Assert.True(k.GetUnaryOperatorPrecedence() > 0));
    }
}
