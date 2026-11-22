using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public int diminuidorPontos;
    public bool cameraTravada = false;
    public float tempoParaMexer;
    public float posicaoX = 0;
    [SerializeField] private CanvasCamera cC;
    [SerializeField] private Timer timer;
    [SerializeField] public float _timer;
    [SerializeField] private GameObject piscar;
    [SerializeField] private GameObject easterEgg;
    public int numeroAleatorio;
    public AudioSource aS;
    public AudioSource easterEggSom;
    public bool nigtmare = false;
    [SerializeField] JumpscareActive jA;
    private int numeroGuardado;
    public float cooldown;
    public int limite;
    public CriaturaDuto cD;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        cC.pontos = cC.pontosIniciais;
        piscar.SetActive(false);
        easterEgg.SetActive(false);
        diminuidorPontos = 1;
    }
    public void VoltarAoMenu()
    {
        if (nigtmare == true && timer.timer >= 360 && jA.derrotado == false)
        {
            SceneManager.LoadScene("Final");
        }
        else { SceneManager.LoadScene("Menu"); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && cameraTravada == false && tempoParaMexer >= 0.8f)
        {
            transform.position = new Vector3(posicaoX = posicaoX + 20, 0, -10);
            tempoParaMexer = 0;
            piscar.SetActive(true);
            aS.Play();
            numeroAleatorio = Random.Range(1, 1000);
            if (numeroAleatorio <= 1)
            {
                easterEgg.SetActive(true);
                easterEggSom.Play();
            }
        }
        if (posicaoX > 60) { transform.position = new Vector3(posicaoX = 0, 0, -10);  }

        if (Input.GetKeyDown(KeyCode.A) && cameraTravada == false && tempoParaMexer >= 0.5f)
        {
            
            transform.position = new Vector3(posicaoX = posicaoX - 20, 0, -10);
            tempoParaMexer = 0;
            piscar.SetActive(true);
            aS.Play();
            numeroAleatorio = Random.Range(1, 1000);
            if (numeroAleatorio <= 1)
            {
                easterEgg.SetActive(true);
                easterEggSom.Play();
            }
        }
        if (posicaoX < 0) { transform.position = new Vector3(posicaoX = 60, 0, -10); }

        if (tempoParaMexer >= 0.8f)
        {
            piscar.SetActive(false);
        }
        

        tempoParaMexer += Time.deltaTime;
        _timer += Time.deltaTime;

        if (cC.pontos <= 0 && _timer >= cooldown)
        {
            cC.death = true;
            cD.aS.volume = 0;
            cD.gOP.SetActive(false);
        }

        if (_timer >= cooldown)
        {
            RolarNumero();
            _timer = 0;
        }

        if (cC.pontos >= 10)
        {
            cC.pontos = 10;
        }
        if (cC.pontos <= 0)
        {
            cC.pontos = 0;
        }


        void RolarNumero()
        {
            numeroGuardado = Random.Range(0, 100);
            cooldown = Random.Range(1, 3);
            if (numeroGuardado <= cC.difficult)
            {
                limite++;
                if(limite >= 2)
                {
                    cC.pontos -= diminuidorPontos;
                    limite = 0;
                }
            }
        }

    }
    
}

