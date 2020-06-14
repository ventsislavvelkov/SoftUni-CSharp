namespace Homework.Pages.SeleniumPages
{
    public partial class SeleniumHomePage
    {
        public string CurrentUrl => Driver.Url;

        public string Title => Driver.Title;
    }
}
