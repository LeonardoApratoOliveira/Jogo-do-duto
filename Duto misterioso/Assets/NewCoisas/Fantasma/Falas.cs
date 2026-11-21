using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falas : MonoBehaviour
{
    public string[] dialagos;
    [SerializeField] AudioSource aS;
    public float timer;
    public float timer2;
    public TextMeshProUGUI tMP;
    private void Start()
    {
        StartCoroutine(Indo());
    }

    IEnumerator Indo()
    {
        foreach (var textos in dialagos) 
        {
            yield return new WaitForSeconds(timer2);
            foreach (var letras in textos)
            {
                tMP.text += letras.ToString();
                if (letras == ' ')
                {
                    timer = 0;
                }
                else { aS.Play(); timer = 0.1f; }
                yield return new WaitForSeconds(timer);
            }
            yield return new WaitForSeconds(timer2);
            tMP.text = string.Empty;
        }
        SceneManager.LoadScene("Menu");
    }
}
