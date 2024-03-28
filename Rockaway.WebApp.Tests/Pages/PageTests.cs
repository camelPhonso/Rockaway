using AngleSharp;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;

namespace Rockaway.WebApp.Tests.Pages;

public class PageTests {
	[Fact]
	public async Task Index_Page_Returns_Success() {
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/");

		response.EnsureSuccessStatusCode();
	}

	// [Fact]
	// public async Task Homepage_Title_Has_Correct_Content()
	// {
	// 	var browsingContext = BrowsingContext.New(Configuration.Default);
	// 	await using var factory = new WebApplicationFactory<Program>();
	// 	var client = factory.CreateClient();
	// 	var html = await client.GetStringAsync("/");
	// 	var dom = await browsingContext.OpenAsync(req => req.Content(html));
	// 	var title = dom.QuerySelector("title");

	// 	title.ShouldNotBeNull();
	// 	title.InnerHtml.ShouldBe("Rockaway");
	// }

	[Fact]
	public async Task Contact_Us_Page_Returns_Success() {
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/ContactUs");

		response.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Contact_Us_Page_Has_Correct_Information() {
		var browsingContext = BrowsingContext.New(Configuration.Default);
		await using var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync("/ContactUs");
		var dom = await browsingContext.OpenAsync(req => req.Content(html));

		var emailShown = dom.QuerySelector("#email-display");

		emailShown.ShouldNotBeNull();
		emailShown.InnerHtml.ShouldBe("fake@email.com");

		var phoneNumberShown = dom.QuerySelector("#phone-display");

		phoneNumberShown.ShouldNotBeNull();
		phoneNumberShown.InnerHtml.ShouldBe("555-666");
	}

	[Theory]
	[InlineData("/", "Rockaway")]
	[InlineData("/privacy", "Privacy Policy")]
	[InlineData("/ContactUs", "Rockaway")]
	public async Task Page_Has_Correct_Title(string url, string title) {
		var browsingContext = BrowsingContext.New(Configuration.Default);
		await using var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync(url);
		var dom = await browsingContext.OpenAsync(req => req.Content(html));

		var titleElement = dom.QuerySelector("title");

		titleElement.ShouldNotBeNull();
		titleElement.InnerHtml.ShouldBe(title);
	}
}