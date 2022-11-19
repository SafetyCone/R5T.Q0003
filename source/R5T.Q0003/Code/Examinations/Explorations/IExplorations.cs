using System;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CliWrap;

using R5T.F0078;
using R5T.T0141;


namespace R5T.Q0003
{
	[ExplorationsMarker]
	public partial interface IExplorations : IExplorationsMarker
	{
		/// <summary>
		/// Test error in input arguments to the executable.
		/// </summary>
		public async Task Command05()
		{
			var output = new StringBuilder();

			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			var command = Cli.Wrap("where")
				//.WithConsoleOutput()
				//.WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
				.WithStandardOutputPipe(PipeTarget.Merge(
					F0078.CliOperator.Instance.Get_ConsolePipeTarget(),
					PipeTarget.ToStringBuilder(output)))
				.WithConsoleError()
				.WithArguments("x")
				;

			try
			{
				var gettingResult = command.ExecuteAsync(cancellationToken);

				Console.WriteLine($"{gettingResult.ProcessId}: ProcessId");

				try
                {
					var result = await gettingResult;

					var resultText = Instances.CliOperator.FormatResult(result);

					Console.WriteLine(resultText);
                }
				catch (CliWrap.Exceptions.CommandExecutionException commandExecutionException)
                {
					Console.WriteLine(commandExecutionException);
				}
			}
			catch (Win32Exception win32Exception)
			{
				Console.WriteLine(win32Exception);
			}

			Console.WriteLine(output);
		}

		/// <summary>
		/// Test error in finding executable.
		/// </summary>
		public async Task Command04()
		{
			var output = new StringBuilder();

			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			var command = Cli.Wrap("where2")
				//.WithConsoleOutput()
				//.WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
				.WithStandardOutputPipe(PipeTarget.Merge(
					F0078.CliOperator.Instance.Get_ConsolePipeTarget(),
					PipeTarget.ToStringBuilder(output)))
				.WithConsoleError()
				.WithArguments("dotnet")
				;

			try
            {
				var gettingResult = command.ExecuteAsync(cancellationToken);

				Console.WriteLine($"{gettingResult.ProcessId}: ProcessId");

				var result = await gettingResult;

				var resultText = Instances.CliOperator.FormatResult(result);

				Console.WriteLine(resultText);
            }
			catch(Win32Exception win32Exception)
            {
				Console.WriteLine(win32Exception);
            }

			Console.WriteLine(output);
		}

		/// <summary>
		/// Test multiple output pipes.
		/// </summary>
		public async Task Command03()
		{
			var output = new StringBuilder();

			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			var gettingResult = Cli.Wrap("where")
				//.WithConsoleOutput()
                //.WithStandardOutputPipe(PipeTarget.ToStringBuilder(output))
				.WithStandardOutputPipe(PipeTarget.Merge(
					F0078.CliOperator.Instance.Get_ConsolePipeTarget(),
					PipeTarget.ToStringBuilder(output)))
				.WithConsoleError()
				.WithArguments("dotnet")
				.ExecuteAsync(cancellationToken);

			Console.WriteLine($"{gettingResult.ProcessId}: ProcessId");

			var result = await gettingResult;

			var resultText = Instances.CliOperator.FormatResult(result);

			Console.WriteLine(resultText);

			Console.WriteLine(output);
		}

		public async Task SecondCommand()
		{
			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			var gettingResult = Cli.Wrap("where")
				.WithConsoleOutput()
				.WithConsoleError()
				.WithArguments("dotnet")
				.ExecuteAsync(cancellationToken);

			Console.WriteLine($"{gettingResult.ProcessId}: ProcessId");

			var result = await gettingResult;

			var resultText = Instances.CliOperator.FormatResult(result);

			Console.WriteLine(resultText);
		}

		public async Task FirstCommand()
        {
			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			var gettingResult = Cli.Wrap("where")
				.WithStandardErrorPipe(PipeTarget.ToDelegate(Console.WriteLine))
				.WithStandardOutputPipe(PipeTarget.ToDelegate(Console.WriteLine))
				.WithArguments("dotnet")
				.ExecuteAsync(cancellationToken);

			Console.WriteLine($"{gettingResult.ProcessId}: ProcessId");

			var result = await gettingResult;

			var resultText = Instances.CliOperator.FormatResult(result);

			Console.WriteLine(resultText);
		}
	}
}