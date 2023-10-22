using User.Client.Views;

namespace User.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(BrowseParkingTicketsPage), typeof(BrowseParkingTicketsPage));
        }
    }
}