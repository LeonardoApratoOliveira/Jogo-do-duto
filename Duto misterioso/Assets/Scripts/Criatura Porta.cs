using UnityEngine;

public class CriaturaPorta : MonoBehaviour
{
    public bool ligado = false;
    [SerializeField] private Animator animator;
    [SerializeField] private float _timer;
    [SerializeField] public float cooldown;
    [SerializeField] private int usosLuz;
    [SerializeField] private int limiteLuz;
    [SerializeField] public bool luzFunciona = true;
    public float trocarFase;
    public int fases;
    public bool death = false;
    private int numeroGuardado;
    public int difficult;
    private int max;
    private int min;
    public bool desative = false;

    private void OnMouseDown()
    {
        if (luzFunciona == true && _timer >= cooldown)
        {
            ligado = true;
            _timer = 0;
            usosLuz++;
            for (int i = 0; i <= fases; i++)
            {
                animator.Play("Fase" + $"{i}");
            }
        }
        
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if(usosLuz > limiteLuz && luzFunciona == true)
        {
            luzFunciona = false;
            _timer = 0;
            animator.Play("FaseIdle");
        }

        if(_timer >= 10 && luzFunciona == false)
        {
            _timer = 0;
            usosLuz = 0;
            luzFunciona = true;
        }

        if (ligado == false)
        {
            animator.Play("FaseIdle");
        }
        if (_timer >= 0.9f)
        {     
            ligado = false;
        }
        if (_timer >= trocarFase && desative == false)
        {
            _timer = 0;
            fases++;
        }
        if(fases > 3)
        {
            death = true;
            Debug.Log("morte");
        }

    }
    private void Awake()
    {
        max = difficult;
        min = difficult - 5;
        numeroGuardado = Random.Range(min, max);
        trocarFase = numeroGuardado;
        animator = GetComponent<Animator>();
    }
}
