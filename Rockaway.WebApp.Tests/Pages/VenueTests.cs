using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Rockaway.WebApp.Data;
using Shouldly;

public class VenueTests(){
	[Fact]
	public async Task Venues_Page_Returns_All_Venues(){
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		var html = await client.GetStringAsync("/Venues");
		var decodedHtml = WebUtility.HtmlDecode(html);

		using var scope = factory.Services.CreateScope();
		var db = scope.ServiceProvider.GetService<RockawayDbContext>();
		var expected = db.Venues.ToList();

		foreach (var venue in expected) decodedHtml.ShouldContain(venue.Name);
	}
}