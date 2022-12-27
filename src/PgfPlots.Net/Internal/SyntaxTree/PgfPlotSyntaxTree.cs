using PgfPlots.Net.Internal.SyntaxTree.Nodes;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Axes;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Options;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots;
using PgfPlots.Net.Internal.SyntaxTree.Nodes.Plots.Data;
using PgfPlots.Net.Public.ElementDefinitions;
using PgfPlots.Net.Public.ElementDefinitions.Options;
using PgfPlots.Net.Public.ElementDefinitions.Plots;

namespace PgfPlots.Net.Internal.SyntaxTree;

internal class PgfPlotSyntaxTree
{
    public PgfPlotSyntaxTree(SyntaxNode rootNode)
    {
        RootNode = rootNode;
    }
    
    public PgfPlotSyntaxTree(PgfPlotDefinition definition)
    {
        RootNode = GenerateTree(definition);
    }

    private SyntaxNode GenerateTree(PgfPlotDefinition definition)
    {
        AxisNode axisNode = GenerateNodeWithOptions<AxisNode>(definition.AxisOptions);
        
        List<PlotNode> plotNodes = definition.PlotDefinitions.Select(GeneratePlotNode).ToList();
        axisNode.AddChildren(plotNodes);
        
        PgfPlotNode rootNode = new();
        rootNode.AddChild(axisNode);

        return rootNode;
    }

    private PlotNode GeneratePlotNode(PlotDefinition plotDefinition)
    {
        PlotNode plotNode = GenerateNodeWithOptions<PlotNode>(plotDefinition.PlotOptions);
        RawDataCollectionNode dataCollectionNode = new(plotDefinition.GetData());
        plotNode.AddChild(dataCollectionNode);
        return plotNode;
    }
    
    private TNode GenerateNodeWithOptions<TNode>(OptionsDefinition options) where TNode: SyntaxNode, new()
    {
        TNode node = new();
        OptionsCollectionNode optionsCollectionNode = new(options.GetOptionsDictionary());
        node.AddChild(optionsCollectionNode);
        return node;
    }

    private SyntaxNode RootNode { get; }

    public string GenerateSource() => RootNode.GenerateSource(new()).ToString();
}