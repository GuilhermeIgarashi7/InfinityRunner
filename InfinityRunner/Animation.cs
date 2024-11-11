namespace InfinityRunner

{
public class Animation
{
    protected List<String> Animation1 = new List<String>();

    protected List<String> Animation2 = new List<String>();

    protected List<String> Animation3 = new List<String>();

    protected bool Loop = true;

    protected int AnimationActive = 1;

    protected Image compImage;


//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    private bool  Stopped = true;

    private int ActualFrame = 1;
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    

    public Animation (Image image)
    {
        compImage = image;
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
            NomeDoArquivo = Animation1[AnimationActive];
            AnimationHeight = Animation1.Count;
        }
        else if (AnimationActive == 2)
        {
            NomeDoArquivo = Animation2[AnimationActive];
            AnimationHeight = Animation2.Count;            
        }
        else if (AnimationActive == 3)
        {
            NomeDoArquivo = Animation3[AnimationActive];
            AnimationHeight = Animation3.Count;            
        }

        compImage.Source = ImageSource.FromFile(NomeDoArquivo);
        ActualFrame ++;

        if (ActualFrame >= AnimationHeight)
        {
            if(Loop)
            {
                ActualFrame = 0;
            }
        }
    }
    
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 


}

}