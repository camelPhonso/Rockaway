using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Rockaway.WebApp.Data;
using Shouldly;

namespace Rockaway.WebApp.Tests.Pages;

public class ArtistTests()
{
	[Fact]
	public async Task Artists_Page_Contains_All_Artists()
	{
		await using var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync("/Artists");
		var decodedHtml = WebUtility.HtmlDecode(html);

		using var scope = factory.Services.CreateScope();
		var db = scope.ServiceProvider.GetService<RockawayDbContext>()!;
		var expected = db.Artists.ToList();

		foreach (var artist in expected)
			decodedHtml.ShouldContain(artist.Name);
	}
}
