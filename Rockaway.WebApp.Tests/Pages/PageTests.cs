using System.Net.NetworkInformation;
using System.Reflection;
using System.Text.Json;
using AngleSharp;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Roackaway.WebApp.Services;
using Rockaway.WebApp.Services;
using Shouldly;

namespace Rockaway.WebApp.Tests.Pages;

public class PageTests
{
	[Fact]
	public async Task Index_Page_Returns_Success()
	{
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/");

		response.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Contact_Us_Page_Returns_Success()
	{
		await using var factory = new WebApplicationFactory<Program>();
		using var client = factory.CreateClient();
		using var response = await client.GetAsync("/ContactUs");

		response.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Contact_Us_Page_Has_Correct_Information()
	{
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

	private static readonly JsonSerializerOptions jsonSerializerOptions =
		new(JsonSerializerDefaults.Web);

	private static readonly ServerStatus testStatus =
		new()
		{
			Assembly = "Test Assembly",
			Modified = new DateTimeOffset(2023, 4, 5, 6, 7, 8, TimeSpan.Zero).ToString("O"),
			HostName = "Test Host",
			DateTime = new DateTimeOffset(2024, 5, 6, 7, 8, 9, TimeSpan.Zero).ToString("O"),
			UpTime = "289345",
		};

	private class TestStatusReporter : IStatusReporter
	{
		public ServerStatus GetStatus() => testStatus;
	}

	[Fact]
	public async Task Status_Endpoint_Returns_Status()
	{
		var factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
			builder.ConfigureServices(services =>
			{
				services.AddSingleton<IStatusReporter>(new TestStatusReporter());
			})
		);
		var client = factory.CreateClient();
		var json = await client.GetStringAsync("/status");
		var status = JsonSerializer.Deserialize<ServerStatus>(json, jsonSerializerOptions);

		status.ShouldNotBeNull();
		status.ShouldBeEquivalentTo(testStatus);
	}

	[Theory]
	[InlineData("/", "Rockaway")]
	[InlineData("/privacy", "Privacy Policy")]
	[InlineData("/ContactUs", "Rockaway")]
	public async Task Page_Has_Correct_Title(string url, string title)
	{
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
