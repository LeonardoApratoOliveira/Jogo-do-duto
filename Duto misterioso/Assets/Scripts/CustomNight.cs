using UnityEngine;
using TMPro;
public class CustomNight : MonoBehaviour
{
    [SerializeField] public int difficultD;
    [SerializeField] public float difficultP;
    [SerializeField] public int difficultC;
    [SerializeField] TextMeshProUGUI tD;
    [SerializeField] TextMeshProUGUI tP;
    [SerializeField] TextMeshProUGUI tC;
    [SerializeField] GameObject escolheDificuldade;
    [SerializeField] public int taEmQualCena;
    public bool taNoNightmare = false;


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        taEmQualCena = 0;
    }
    public void Update()
    {
        if (taEmQualCena == 1)
        {
            escolheDificuldade = GameObject.FindWithTag("Dificuldade");
        }
        if(taEmQualCena == 2)
        {
            Destroy(gameObject);
        }
    }

    public void AddD()
    {
        difficultD++;
        if (difficultD >= 10)
        {
            difficultD = 10;
        }
        UID();
    }
    public void RemD()
    {
        difficultD--;
        
        if (difficultD <= 0)
        {
            difficultD = 0;
        }UID();
    }

    public void AddP()
    {
        difficultP++;
        
        if (difficultP >= 10)
        {
            difficultP = 10;
        }UIP();
    }
    public void RemP()
    {
        difficultP--;
        
        if (difficultP <= 0)
        {
            difficultP = 0;
        }UIP();
    }

    public void AddC()
    {
        difficultC++;
        
        if (difficultC >= 10)
        {
            difficultC = 10;
        }UIC();
    }
    public void RemC()
    {
        difficultC--;
        
        if (difficultC <= 0)
        {
            difficultC = 0;
        }UIC();
    }

    public void UID()
    {
        tD.text = $"{difficultD}";
    }

    public void UIP()
    {
        tP.text = $"{difficultP}";
    }

    public void UIC()
    {
        tC.text = $"{difficultC}";
    }



}
