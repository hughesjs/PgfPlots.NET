using PgfPlotsSdk.Public.ElementDefinitions.Options;
using PgfPlotsSdk.Public.ElementDefinitions.Plots;

namespace PgfPlotsSdk.Public.ElementDefinitions.Wrappers;

public class PgfPlotDefinition
{
    public PgfPlotDefinition(AxisOptions axisOptions)
    {
        AxisOptions = axisOptions;
        PlotDefinitions = new();
    }

    public PgfPlotDefinition(AxisOptions axisOptions, List<PlotDefinition> plotDefinitions)
    {
        AxisOptions = axisOptions;
        PlotDefinitions = plotDefinitions;
    }

    public AxisOptions AxisOptions { get; }
    public List<PlotDefinition> PlotDefinitions { get; }
}