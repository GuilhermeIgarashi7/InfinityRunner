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


	protected override void OnSizeAllocated(double width, double heigth)
	{
		base.OnSizeAllocated(width, heigth);
		CorrectWindowSize(width, heigth);
			 
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


}

