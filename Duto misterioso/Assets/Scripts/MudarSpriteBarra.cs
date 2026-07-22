using Unity.VisualScripting;
using UnityEngine;

public class MudarSpriteBarra : MonoBehaviour
{
    [SerializeField] private CanvasCamera cC;
    [SerializeField] private SpriteRenderer sR;
    [SerializeField] private Sprite[] sprites;
    
    void Update()
    {
        for (int i = 0; i <= cC.pontos; i++)
        {   
            sR.sprite = sprites[i];
        }
    }
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }
}
