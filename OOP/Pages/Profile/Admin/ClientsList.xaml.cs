using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class ClientsList : ContentPage
{
    public List<Client> Clients { get; set; }

    public ClientsList()
	{
		InitializeComponent();
        Clients = MainPage.MyEntry.Clients;
        BindingContext = this;
    }
}