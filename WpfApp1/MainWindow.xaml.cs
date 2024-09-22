using System.IO;
using System.Text.Json;
using System.Windows;

namespace WpfApp1;

public partial class MainWindow : Window
{
    private IEnumerable<Account> _accounts;
    
    public MainWindow()
    {
        InitializeComponent();
        
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            _accounts = GetAccounts();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
    {
        if (!_accounts.Any(account =>
                account.Login == InputLogin.Text && account.Password == InputPassword.Text))
        {
            MessageBoxShow("Неверный логин или пароль");
            return;
        }
        
        MessageBoxShow("Авторизация прошла успешно");
        ClearInputs();
    }

    private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
    {
        ClearInputs();
    }

    private void ClearInputs()
    {
        InputLogin.Clear();
        InputPassword.Clear();
    }

    private void MessageBoxShow(string message)
    {
        MessageBox.Show(
            caption:"Авторизация",
            messageBoxText:message);
    }

    private IEnumerable<Account> GetAccounts()
    {
        var json = File.ReadAllText("accounts.json");
        return JsonSerializer.Deserialize<IEnumerable<Account>>(json) ?? throw new Exception("Failed to deserialize accounts");
    }
}