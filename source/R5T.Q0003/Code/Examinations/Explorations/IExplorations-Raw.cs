using System;
using System.Threading.Tasks;

using CliWrap;

using R5T.F0078.Extensions;
using R5T.T0141;


namespace R5T.Q0003.Raw
{
	[ExplorationsMarker]
	public partial interface IExplorations : IExplorationsMarker
	{
        /// <summary>
        /// Test run npm in CliWrap.
        /// </summary>
        /// <returns></returns>
		public async Task N_001()
		{
            await Cli.Wrap("npm")
                .WithArguments("install -y")
                .WithWorkingDirectory(@"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0006.Private\Source\D8S.W0006\")
                .WithConsoleOutput()
                .WithConsoleError()
                .ExecuteAsync();
        }
	}
}