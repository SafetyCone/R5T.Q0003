using System;

using R5T.F0078;


namespace R5T.Q0003
{
    public static class Instances
    {
        public static ICliOperator CliOperator { get; } = F0078.CliOperator.Instance;
        public static IExplorations Explorations { get; } = Q0003.Explorations.Instance;
    }
}