using UnityEngine;

public class JumpscareActive : MonoBehaviour
{
    public GameObject jumpscareDuto;
    public GameObject jumpscarePorta;
    public GameObject jumpscareCamera;
    public GameObject derrota;
    public CriaturaDuto cD;
    public CriaturaPorta criaturaPorta;
    public CanvasCamera cC;
    public CameraScript cS;
    [SerializeField] private float _timer;
    public bool derrotado = false;
    public AudioSource aS;
    private void Update()
    {
        _timer += Time.deltaTime;
        if(cD.death == true && derrotado == false)
        {
            jumpscareDuto.SetActive(true);
            cC.difficult = 1000;
            cC.pontos = 10;
            criaturaPorta.desative = true;
            cD.desative = true;
            cS.cameraTravada = true;
            _timer = 0;
            derrotado = true;
            aS.Play();
        }
        if (criaturaPorta.death == true && derrotado == false)
        {
            jumpscarePorta.SetActive(true);
            cC.difficult = 1000;
            cC.pontos = 10;
            criaturaPorta.desative = true;
            cD.desative = true;
            cS.cameraTravada = true;
            _timer = 0;
            derrotado = true;
            aS.Play();
        }
        if (cC.death == true && derrotado == false)
        {
            jumpscareCamera.SetActive(true);
            cC.difficult = 1000;
            cC.pontos = 10;
            criaturaPorta.desative = true;
            cD.desative = true;
            cS.cameraTravada = true;
            _timer = 0;
            derrotado = true;
            aS.Play();
            cD.aS.Stop();
        }

        if (_timer >= 1.5f && derrotado == true)
        {
            derrota.SetActive(true);
            jumpscareCamera.SetActive(false);
            jumpscarePorta.SetActive(false);
            jumpscareDuto.SetActive(false);
        }

    }

    private void Start()
    {
        jumpscareCamera.SetActive(false);
        jumpscareDuto.SetActive(false);
        jumpscarePorta.SetActive(false);
        derrota.SetActive(false);
    }
}
