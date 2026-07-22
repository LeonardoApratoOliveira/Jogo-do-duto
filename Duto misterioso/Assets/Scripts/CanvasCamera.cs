using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    [SerializeField] private CameraScript cS;
    [SerializeField] private GameObject meuCanvas;
    public float difficult;
    public int pontos;
    public int pontosIniciais;
    public bool death = false;

    public void Click()
    {
        pontos++;
        cS._timer = 0;
    }

    public void Exit()
    {
        meuCanvas.SetActive(false);
        cS.speed = 15;
    }

}
