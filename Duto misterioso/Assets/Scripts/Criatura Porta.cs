using UnityEngine;

public class CriaturaPorta : MonoBehaviour
{
    public bool ligado = false;
    public Sprite[] sprites;
    private SpriteRenderer sR;
    [SerializeField] private float _timer;
    public float trocarFase;
    public int fases;
    public float timerDeaft;
    public bool death = false;
    public bool pertoDeMatar = false;
    public float seSalvar;

    private void OnMouseEnter()
    {
        if(ligado == false)
        {
            ligado = true;
            for (int i = 0; i <= fases; i++)
            {
                if (i == fases)
                {
                    sR.sprite = sprites[i+1];
                }
            }
        }
    }

    private void OnMouseExit()
    {
        sR.sprite = sprites[0];
        ligado = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer>= trocarFase && pertoDeMatar == false)
        {
            fases++;
            _timer = 0;
            
        }

        if (fases == 3 && pertoDeMatar == false)
        {
            pertoDeMatar = true;
            _timer = 0;
            
        }

        if (_timer >= timerDeaft && pertoDeMatar == true)
        {
            death = true;
            Debug.Log("Morte");
        }
        else if (_timer >= seSalvar && ligado == true && pertoDeMatar == true)
        {
            ligado = false;
            pertoDeMatar = false;
            fases = 0;
            sR.sprite = sprites[0];
            _timer = 0;
        }


    }
    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }
}
