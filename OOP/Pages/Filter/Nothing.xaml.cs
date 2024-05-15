namespace OOP;

public partial class Nothing : ContentPage
{
	public Nothing(string text1, string text2, string png)
	{
        InitializeComponent();
		Label1.Text = text1;
		Label2.Text = text2;
		MyImage.Source = png;
	}
}