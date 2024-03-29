using System.Reflection;
using Rockaway.WebApp.Services;

namespace Roackaway.WebApp.Services;

public class StatusReporter : IStatusReporter
{
	private static readonly Assembly assembly = Assembly.GetEntryAssembly()!;

	public ServerStatus GetStatus()
	{
		return new()
		{
			Assembly = assembly.FullName ?? "Assembly.GetEntryAssembly() returned null",
			Modified = new DateTimeOffset(
				File.GetLastWriteTimeUtc(assembly.Location),
				TimeSpan.Zero
			).ToString("O"),
			HostName = Environment.MachineName,
			DateTime = DateTimeOffset.UtcNow.ToString("O"),
			UpTime = Environment.TickCount.ToString(),
		};
	}
};
