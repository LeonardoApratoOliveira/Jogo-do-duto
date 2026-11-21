using UnityEngine;

public class Computador : MonoBehaviour
{
    [SerializeField] private CameraScript cS;
    [SerializeField] private GameObject meuCanvas;
    [SerializeField] private AudioSource aS;


    private void OnMouseDown()
    {
        meuCanvas.SetActive(true);
        cS.cameraTravada = true;
        aS.Play();
    }

    private void Start()
    {
        meuCanvas.SetActive(false);
    }
}
