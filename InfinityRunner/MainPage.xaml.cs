namespace InfinityRunner;



public partial class MainPage : ContentPage
{

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	private bool IsDead = false;

	private bool IsJumping = false;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	const int Fps = 25;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


	private int Speed1 = 0;

	private int Speed2 = 0;

	private int Speed3 = 0;

	private int CharacterSpeed = 0;

	private int WindowWidth = 0;

	private int WindowHeight = 0;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Drawn();
		//o drawn tá só de teste
	}


	protected override void OnSizeAllocated(double width, double heigth)
	{
		base.OnSizeAllocated(width, heigth);
		CorrectWindowSize(width, heigth);
		SpeedCalculate(width);
			 
	}

	void CorrectWindowSize (double width, double heigth)
	{
		foreach (var LayerOne in HorizontalLayer1.Children)
		(LayerOne as Image).WidthRequest = width;

		foreach (var LayerTwo in HorizontalLayer2.Children)
		(LayerTwo as Image).WidthRequest = width;

		foreach (var LayerThree in HorizontalLayer3.Children)
		(LayerThree as Image).WidthRequest = width;

		HorizontalLayer1.WidthRequest = width * 1.5;
		HorizontalLayer2.WidthRequest = width * 1.5;
		HorizontalLayer3.WidthRequest = width * 1.5;

	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void SpeedCalculate(double width)
	{
		Speed1 = (int) (width * 0.001);
		Speed2 = (int) (width * 0.004);
		Speed3 = (int) (width * 0.01);
	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void GerenciaCenarios()
	{
		MoveCenario();
		ManageCenario(HorizontalLayer1);
		ManageCenario(HorizontalLayer2);
		ManageCenario(HorizontalLayer3);	
	}

	private void MoveCenario()
	{
		HorizontalLayer1.TranslationX -= Speed1;
		HorizontalLayer2.TranslationX -= Speed2;
		HorizontalLayer3.TranslationX -= Speed3;
	}

	private void ManageCenario(HorizontalStackLayout horizontal)
	{
		var visualizar = (horizontal.Children.First() as Image);
		if (visualizar.WidthRequest + horizontal.TranslationX < 0)
		{
			horizontal.Children.Remove(visualizar);
			horizontal.Children.Add(visualizar);
			horizontal.TranslationX = visualizar.TranslationX;
		}
	}

	async Task Drawn()
	{
		while (!IsDead)
		{
			GerenciaCenarios();
			await Task.Delay(Fps);
		}
	}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}

