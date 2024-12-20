using FFImageLoading.Maui;

namespace InfinityRunner

{
public class Animation
{
    protected List<String> Animation1 = new List<String>();

    protected List<String> Animation2 = new List<String>();

    protected List<String> Animation3 = new List<String>();

    protected bool Loop = true;

    protected int AnimationActive = 1;


    protected CachedImageView ImageView;


//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private bool  Stopped = true;

    private int ActualFrame = 1;
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    

    public Animation (CachedImageView animacao)
    {
        ImageView = animacao;
    }

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 
    public void Stop()
    {
        Stopped = true;
    }

    public void StartGame()
    {
        Stopped = false;
    }

    public void SetAnimationActive(int a)
    {
        AnimationActive = a;
    }

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public void Desenha()
    {
        if(Stopped)
            return;
        
        string NomeDoArquivo = "";
        int AnimationHeight = 0;

        if (AnimationActive == 1)
        {
            NomeDoArquivo = Animation1[ActualFrame];
            AnimationHeight = Animation1.Count;
        }
        else if (AnimationActive == 2)
        {
            NomeDoArquivo = Animation2[ActualFrame];
            AnimationHeight = Animation2.Count;            
        }
        else if (AnimationActive == 3)
        {
            NomeDoArquivo = Animation3[ActualFrame];
            AnimationHeight = Animation3.Count;            
        }

        ImageView.Source = ImageSource.FromFile(NomeDoArquivo);
        ActualFrame ++;

        if (ActualFrame >= AnimationHeight)
        {
            if(Loop)
            {
                ActualFrame = 0;
            }
            else
            {
                Stopped = true;
                QuandoParar();
            }

        }

    }
    
    public virtual void QuandoParar()
    {

    }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 


}

}