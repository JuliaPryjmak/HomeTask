using MainProject.Helpers;
using MainProject.Pages;

namespace MainProject.Context
{
    public class BaseContext
    {
        public UserHelpers UserHelpers { get; }
        public HomePage HomePage { get; }
        public LoginPage LoginPage { get; }
        public TrackingDataPage TrackingDataPage { get; }

        public BaseContext(UserHelpers userHelpers, HomePage homePage, LoginPage loginPage, TrackingDataPage trackingDataPage)
        {
            UserHelpers = userHelpers;
            HomePage = homePage;
            LoginPage = loginPage;
            TrackingDataPage = trackingDataPage;
        }
    }
}
