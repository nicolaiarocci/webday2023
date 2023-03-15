using Microsoft.Playwright.NUnit;

namespace test
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task MyTest()
        {
            /* Playwright.Selectors.SetTestIdAttribute("test-id"); */

            _ = await Page.GotoAsync("http://localhost:5041/");

            await Page.GetByTestId("counter").ClickAsync();

            await Page.GetByTestId("clickme").ClickAsync();

            await Expect(Page.GetByTestId("status")).ToHaveTextAsync("Current count: 1");

            await Page.GetByTestId("clickme").ClickAsync();

            await Expect(Page.GetByTestId("status")).ToHaveTextAsync("Current count: 2");

        }
    }
}
