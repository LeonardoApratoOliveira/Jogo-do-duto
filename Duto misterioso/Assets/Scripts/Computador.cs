using UnityEngine;

public class Computador : MonoBehaviour
{
    [SerializeField] private CameraScript cS;
    [SerializeField] private GameObject meuCanvas;


    private void OnMouseDown()
    {
        meuCanvas.SetActive(true);
        cS.cameraTravada = true;
    }

    private void Start()
    {
        meuCanvas.SetActive(false);
    }
}
