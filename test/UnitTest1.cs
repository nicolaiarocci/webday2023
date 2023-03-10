using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace test
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task MyTest()
        {
            Playwright.Selectors.SetTestIdAttribute("test-id");

            _ = await Page.GotoAsync("https://webday2023.nicolaiarocci.com/");
            /* await Page.GotoAsync("http://localhost:5041/"); */

            await Page.GetByRole(AriaRole.Link, new() { Name = "Counter" }).ClickAsync();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

            await Expect(Page.GetByTestId("counter")).ToHaveTextAsync("Current count: 1");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Click me" }).ClickAsync();

            await Expect(Page.GetByTestId("counter")).ToHaveTextAsync("Current count: 2");

        }
    }
}
