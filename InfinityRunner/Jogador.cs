using FFImageLoading.Maui;

namespace InfinityRunner
{
    public delegate void CallBack();
    public class Jogador:Animation
    {
        public Jogador(CachedImageView a): base(a)
        {
            for(int numero = 1; numero <= 5; numero++)
                Animation1.Add($"andar{numero.ToString("D2")}.png");

            for(int numero2 = 1; numero2 <= 2; numero2++)
                Animation2.Add($"morto{numero2.ToString("D2")}.png");
            SetAnimationActive(1);
        }

        public void Morto()
        {
            Loop = false;
            SetAnimationActive(2);
        }

        public void Run()
        {
            Loop = true;
            SetAnimationActive(1);
            StartGame();
        }

    }
}