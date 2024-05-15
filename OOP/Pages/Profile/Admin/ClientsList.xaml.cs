using OOP.Entities;
using System.Collections.ObjectModel;

namespace OOP;

public partial class ClientsList : ContentPage
{
    public List<Client> Clients { get; set; }

    public ClientsList(AgencyEntry agencyEntry)
	{
		InitializeComponent();
        Clients = agencyEntry.Clients;
        BindingContext = this;
    }
}