using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carta : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EsperarParaSair());
    }

    IEnumerator EsperarParaSair()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Menu");
    }
}
