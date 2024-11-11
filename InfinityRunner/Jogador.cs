namespace InfinityRunner
{
    public class Jogador:Animation
    {
        public Jogador(Image a): base(a)
        {
            for(int numero = 1; numero <= 5; numero++)
                Animation1.Add($"andar{numero.ToString("D2")}.png");

            for(int numero2 = 1; numero2 <= 2; numero2++)
                Animation2.Add($"morto{numero2.ToString("D2")}.png");
        }

    }
}