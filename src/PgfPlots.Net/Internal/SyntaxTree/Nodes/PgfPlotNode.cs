namespace PgfPlots.Net.Internal.SyntaxTree.Nodes;

internal class PgfPlotNode : SyntaxNode
{
    protected override string BeforeChildren  => """
                                                 \begin{tikzpicture}
                                                 
                                                 """;

    protected override string BetweenChildren => string.Empty;
    protected override string AfterChildren => """
                                               
                                               \end{tikzpicture}
                                               """;
}