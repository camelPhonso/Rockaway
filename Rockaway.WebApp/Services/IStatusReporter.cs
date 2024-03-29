using Rockaway.WebApp.Services;

namespace Roackaway.WebApp.Services;

public interface IStatusReporter
{
	public ServerStatus GetStatus();
}
