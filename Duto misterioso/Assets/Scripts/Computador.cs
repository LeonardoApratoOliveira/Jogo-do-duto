using UnityEngine;

public class Computador : MonoBehaviour
{
    [SerializeField] private CameraScript cS;
    [SerializeField] private GameObject meuCanvas;


    private void OnMouseDown()
    {
        meuCanvas.SetActive(true);
        cS.speed = 0;
    }

    private void Start()
    {
        meuCanvas.SetActive(false);
    }
}
