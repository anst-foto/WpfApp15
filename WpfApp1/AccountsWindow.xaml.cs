using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1;

public partial class AccountsWindow : Window
{
    private readonly IEnumerable<Account> _accounts;
    
    public AccountsWindow()
    {
        InitializeComponent();
        
        _accounts = GetAccounts();
        Accounts.ItemsSource = _accounts;
    }
    
    private static IEnumerable<Account> GetAccounts()
    {
        var json = File.ReadAllText("accounts.json");
        return JsonSerializer.Deserialize<IEnumerable<Account>>(json) ?? throw new Exception("Failed to deserialize accounts");
    }

    private void Accounts_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var account = Accounts.SelectedItem as Account;
        
        InputId.Text = account?.Id.ToString() ?? string.Empty;
        InputLogin.Text = account?.Login ?? string.Empty;
        InputPassword.Text = account?.Password ?? string.Empty;
        InputRole.Text = account?.Role ?? string.Empty;
    }
}