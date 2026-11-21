using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificadorDeEasterEggs : MonoBehaviour
{
    [SerializeField] EasterEggs eE1;
    [SerializeField] EasterEggs eE2;
    [SerializeField] EasterEggs eE3;
    [SerializeField] EasterEggs eE4;


    private void Update()
    {
        if (eE1.achou == true && eE2.achou == true && eE3.achou == true && eE4.achou == true)
        {
            StartCoroutine(CenaCarta());
            eE1.achou = false;
        }
    }

    IEnumerator CenaCarta()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Carta");
    }
}
