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
            /* Playwright.Selectors.SetTestIdAttribute("test-id"); */

            await Page.GotoAsync("https://webday2023.nicolaiarocci.com");

            throw new ApplicationException("Crash!");

            await Page.GetByTestId("counter").ClickAsync();

            await Page.GetByTestId("clickme").ClickAsync();

            await Expect(Page.GetByTestId("status")).ToHaveTextAsync("Current count: 1");

            await Page.GetByTestId("clickme").ClickAsync();

            await Expect(Page.GetByTestId("status")).ToHaveTextAsync("Current count: 2");

        }
    }
}
