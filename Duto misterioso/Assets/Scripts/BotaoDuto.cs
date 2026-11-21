using System.Collections;
using UnityEngine;

public class BotaoDuto : MonoBehaviour
{
    [SerializeField] CriaturaDuto cD;
    [SerializeField] CriaturaPorta CriaturaPorta;
    [SerializeField] private float _timer;
    public float timerQuebrar;
    public float timerConsertar;
    public float criaturaSair;
    public Animator animator;
    public bool fechado = false;
    public bool quebrado = false;
    public int pontosDuto;
    public int limiteDuto;
    public AudioSource aS;
    public ParticleSystem pS;
    [SerializeField] private CameraScript cS;

    private void OnMouseDown()
    {
        
        if (fechado == false && quebrado == false)
        {
            fechado = true;
            aS.Play();
            cD.aS.volume = 0.2f;
            pontosDuto++;
            cD.desative = true;
            cD.gOP.SetActive(false);
        }
        
    }

    private void OnMouseUp() 
    {
        animator.Play("DutoAbrindo");
        if (fechado == true)
        {
            cD.aS.volume = 1f;
            aS.Play();
            cD.desative = false; 
        }
        fechado = false;
        

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timerQuebrar || pontosDuto >= limiteDuto)
        {
            aS.pitch = 2;
        }

        if (_timer >= timerQuebrar || pontosDuto >= limiteDuto)
        {
            animator.Play("DutoAbrindo");
            quebrado = true;
            fechado = false;
            pontosDuto = 0;
            _timer = 0;
            pS.Play();
            aS.Play();
            cD.desative = false;
            cD.desative2 = false;
            cD.aS.volume = 1f;
            timerQuebrar = timerQuebrar * 3;
        }

        if (fechado == true && quebrado == false)
        {
            animator.Play("DutoFechando");

            if (cS.posicaoX != 40)
            {
                fechado = false;
                animator.Play("DutoAbrindo");
                aS.Play();
                cD.desative = false;
                cD.aS.volume = 1f;
            }
        }

        if (fechado == true && _timer >= criaturaSair && cD.eyes == true)
        {
            cD._timer = 0;
            cD.aS.Stop();
            cD.eyes = false;
            cD.taAqui = false;
            cD.desative2 = false;
        }
        else if (fechado == false && quebrado == false)
        {
            _timer = 0;
        }

        if(quebrado == true && _timer >= timerConsertar)
        {
            _timer = 0;
            pS.Stop();
            timerQuebrar = timerQuebrar / 3;
            aS.volume = 1f;
            aS.pitch = 1;
            quebrado = false;
        }
        
    }
    private void Start()
    {
        animator.Play("IdleAberto");
        animator = GetComponent<Animator>();
    }

}
