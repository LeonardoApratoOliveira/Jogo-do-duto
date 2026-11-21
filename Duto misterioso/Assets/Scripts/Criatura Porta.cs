using UnityEngine;

public class CriaturaPorta : MonoBehaviour
{
    public bool ligado = false;
    [SerializeField] private Animator animator;
    [SerializeField] public float _timer;
    [SerializeField] private float _timerAnim;
    [SerializeField] public float cooldown;
    [SerializeField] private int usosLuz;
    [SerializeField] private int limiteLuz;
    [SerializeField] public bool luzFunciona = true;
    public float trocarFase;
    public int fases;
    public bool death = false;
    public float difficult;
    public bool desative = false;
    public AudioSource aS;
    public ParticleSystem pS;
    public int numeroGuardado;
    public int limite;
    public CriaturaDuto cD;
    private void OnMouseDown()
    {
       
        if (usosLuz >= limiteLuz)
        {
            aS.pitch = 2;
        }
        if (luzFunciona == true && _timerAnim >= 2f)
        {
            ligado = true;
            
            _timerAnim = 0;
            _timer = 0;
            usosLuz++;
            aS.Play();
            animator.Play("Fase" + $"{fases}"); 
        }
        if (luzFunciona == false )
        {
            pS.Play();
        }
        
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        _timerAnim += Time.deltaTime;
        if (usosLuz >= limiteLuz && luzFunciona == true)
        {
            luzFunciona = false;
            fases--;
            _timer = 0;
            animator.Play("FaseIdle");
        }

        if(_timer >= cooldown && luzFunciona == false)
        {
            _timer = 0;
            usosLuz = 0;
            aS.pitch = 1;
            luzFunciona = true;
            _timerAnim = 2;
        }

        if (ligado == false)
        {
            animator.Play("FaseIdle");
        }
        if (_timerAnim >= 0.9f)
        {     
            ligado = false;
        }
        if (_timer >= trocarFase && desative == false)
        {
            _timer = 0;
            RolarNumero();
            usosLuz = 0;
        }
        if(fases > 3)
        {
            cD.gOP.SetActive(false);
            cD.aS.volume = 0;
            death = true;
        }
        if (fases < 0) { fases = 0; }

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void RolarNumero()
    {
        numeroGuardado = Random.Range(0, 100);
        trocarFase = Random.Range(3, 5);
        if(numeroGuardado <= difficult)
        {
            limite++;
            if(limite >= 2)
            {
                fases++;
                limite = 0;
            }
        }
    }

}
