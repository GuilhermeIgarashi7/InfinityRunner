using FFImageLoading.Maui;

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

	private int Speed4 = 0;

	private int Speed5 = 0;

	private int Speed6 = 0;	

	private int CharacterSpeed = 0;

	private int WindowWidth = 0;

	private int WindowHeight = 0;

	Jogador jogador;

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	public MainPage()
	{
		InitializeComponent();

		jogador= new Jogador(imgJogador);
		jogador.Run();

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

		foreach (var LayerFour in HorizontalLayer4.Children)
		(LayerFour as Image).WidthRequest = width;

		foreach (var LayerFive in HorizontalLayer5.Children)
		(LayerFive as Image).WidthRequest = width;

		foreach (var Floor in HorizontalChao.Children)
		(Floor as Image).WidthRequest = width;

		HorizontalLayer1.WidthRequest = width * 1.5;
		HorizontalLayer2.WidthRequest = width * 1.5;
		HorizontalLayer3.WidthRequest = width * 1.5;
		HorizontalLayer4.WidthRequest = width * 1.5;
		HorizontalLayer5.WidthRequest = width * 1.5;
		HorizontalLayer6.WidthRequest = width * 1.5;
		HorizontalChao.WidthRequest = width * 1.5;


	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void SpeedCalculate(double width)
	{
		Speed1 = (int) (width * 0.001);
		Speed2 = (int) (width * 0.002);
		Speed3 = (int) (width * 0.004);
		Speed4 = (int) (width * 0.008);
		Speed5 = (int) (width * 0.01);
		Speed6 = (int) (width * 0.003);
		CharacterSpeed = (int) (width * 0.012);
	}

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	private void GerenciaCenarios()
	{
		MoveCenario();
		ManageCenario(HorizontalLayer1);
		ManageCenario(HorizontalLayer2);
		ManageCenario(HorizontalLayer3);
		ManageCenario(HorizontalLayer4);
		ManageCenario(HorizontalLayer5);
		ManageCenario(HorizontalLayer6);
		ManageCenario(HorizontalChao);
	}

	private void MoveCenario()
	{
		HorizontalLayer1.TranslationX -= Speed1;
		HorizontalLayer2.TranslationX -= Speed2;
		HorizontalLayer3.TranslationX -= Speed3;
		HorizontalLayer4.TranslationX -= Speed4;
		HorizontalLayer5.TranslationX -= Speed5;
		HorizontalLayer6.TranslationX -= Speed6;
		HorizontalChao.TranslationX -= CharacterSpeed;
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
			jogador.Desenha();
			GerenciaCenarios();
			await Task.Delay(Fps);
		}
	}
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

}

