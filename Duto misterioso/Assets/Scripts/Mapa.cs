using UnityEngine;

public class Mapa : MonoBehaviour
{
    public CameraScript cS;
    public Sprite[] sprites;
    public SpriteRenderer sR;
    void Start()
    {
        
    }

    void Update()
    {
        if (cS.posicaoX >= 0)
        {
            sR.sprite = sprites[0];
        }
        if (cS.posicaoX >= 20)
        {
            sR.sprite = sprites[1];
        }
        if (cS.posicaoX >= 40)
        {
            sR.sprite = sprites[2];
        }
        if (cS.posicaoX >= 60)
        {
            sR.sprite = sprites[3];
        }
    }
}
