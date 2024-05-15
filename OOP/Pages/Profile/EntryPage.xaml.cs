using OOP.Entities;

namespace OOP;

public partial class EntryPage : ContentPage
{
    private readonly Agency _agency;
    private readonly AgencyEntry _agencyEntry;
    private readonly IDbService _dbService;
    public EntryPage(Agency agency, AgencyEntry agencyEntry, IDbService dbService)
	{
		InitializeComponent();
        _agency = agency;
        _agencyEntry = agencyEntry;
        _dbService = dbService;
        agencyEntry.LoginEvent += AdminEntry;
        agencyEntry.ClientLoginEvent += ClientEntry;
        agencyEntry.InvalidEvent += Invalid;
    }
    private void Ok_Button_Clicked(object sender, EventArgs e)
    {
        _agencyEntry.Login(Email.Text, Password.Text);
    }
    public async void AdminEntry()
    {
        await Navigation.PopAsync();
        var tabBar = Shell.Current.FindByName<TabBar>("TabBarName");
        var tab1 = tabBar.Items[1];
        tab1.Items.Clear();
        if (_agencyEntry.AllBooking().Count == 0)
            tab1.Items.Add(new ShellContent { Content = new Nothing("Пока нет заказов", "ни один клиент не заказал тур", "icon_qwerty.png") });
        else
            tab1.Items.Add(new ShellContent { Content = new BookingList(_agencyEntry) });
        var tab2 = tabBar.Items[3];
        tab2.Items.Clear();
        tab2.Items.Add(new ShellContent { Content = new AdminProfile(_agency, _agencyEntry, _dbService) });
    }
    public async void ClientEntry()
    {
        await Navigation.PopAsync();
        var tabBar = Shell.Current.FindByName<TabBar>("TabBarName");
        var tab1 = tabBar.Items[1];
        tab1.Items.Clear();
        if (_agencyEntry.CurrentUser is Client client && client.Bookings.Count == 0)
            tab1.Items.Add(new ShellContent { Content = new Nothing("У вас пока нет заказов", "выберите свой первый тур", "icon_qwerty.png") });
        else
            tab1.Items.Add(new ShellContent { Content = new ClientBookings(_agencyEntry) });
        var tab2 = tabBar.Items[3];
        tab2.Items.Clear();
        tab2.Items.Add(new ShellContent { Content = new ClientProfile(_agency, _agencyEntry, _dbService) });
    }
    public void Invalid()
    {
        _ = DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
    }
}