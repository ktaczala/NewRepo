
namespace DelegateDemoProject;

public static class MyVariables
{
#pragma warning disable CA2211
    public static bool stopmanual = false;
    public static CancellationTokenSource _cancelSource = new();
#pragma warning restore CA2211
}
