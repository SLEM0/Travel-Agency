namespace OOP.Entities
{
    public class AgencyEntry
    {
        public delegate void LoginEventHandler();
        public event LoginEventHandler? LoginEvent;
        public delegate void LoginEventHandler1();
        public event LoginEventHandler? ClientLoginEvent;
        public List<Client> Clients { get; } = [];
        string AdminLogin = "Login";
        string AdminPassword = "Password";

        public void Register(string password, string firstName, string lastName, string email)
        {
            Client? client = Clients.Find(c => c.Email == email);
            if (client != null)
            {
                Console.WriteLine("There is already a user with this login");
            }
            else
            {
                Client newClient = new(password, firstName, lastName, email);
                Clients.Add(newClient);
            }
        }

        public Client? Login(string email, string password)
        {
            if (email == AdminLogin && password == AdminPassword)
            {
                LoginEvent?.Invoke();
            }
            else
            {
                Client? client = Clients.Find(c => c.Email == email && c.Password == password);
                if (client != null)
                {
                    ClientLoginEvent?.Invoke();
                    return client;
                }
                else
                {
                    Console.WriteLine("Invalid login or password");
                }
            }
            return null;
        }

        public void ChangeCredentials(string login, string password)
        {
            AdminLogin = login;
            AdminPassword = password;
        }
    }
}