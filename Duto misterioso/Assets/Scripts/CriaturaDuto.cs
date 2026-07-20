using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class CriaturaDuto : MonoBehaviour
{
    [SerializeField] public List<int> numerosAleatorios = new List<int>();
    public int difficult;
    [SerializeField] private float _timer;
    public float cooldown;
    public int? numeroGuardado;
    public bool eyes = false;
    public float timerDeaft;
    public bool death = false;
    private void Start()
    {
        for (int i = 0; i <= difficult; i++)
        {
            numerosAleatorios.Add(i);
        }
    }
    private void Update()
    {
      
        _timer += Time.deltaTime;
        if (_timer >= cooldown && eyes == false)
        {
            _timer = 0;
            RolarNumero();
        }

        if (numeroGuardado == difficult && eyes == false)
        {
            numerosAleatorios.Clear();
            for (int i = 0; i <= difficult; i++)
            {
                numerosAleatorios.Add(i);
            }
            Debug.LogWarning("ta aqui");
            _timer = 0;
            eyes = true;
        }
        if (eyes == true && _timer >= timerDeaft && death == false)
        {
            death = true;
            Debug.LogErrorFormat("Morte");
        }
    }

    public void RolarNumero()
    {
        int indiceAleatorio = Random.Range(0, numerosAleatorios.Count);
        int rolarNumero = numerosAleatorios[indiceAleatorio];
        numerosAleatorios.RemoveAt(indiceAleatorio);
        numeroGuardado = rolarNumero;
        Debug.Log(numeroGuardado);
    }
}
