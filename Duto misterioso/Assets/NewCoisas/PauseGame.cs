using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public int quanClique;
    [SerializeField] GameObject Pausado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Pause());
            Pausado.SetActive(true);
            quanClique++;
        }
        if(quanClique == 2)
        {
            StartCoroutine(IndoMenu());
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(8);
        quanClique = 0;
        Pausado.SetActive(false);
    }
    [SerializeField] GameObject fadeOut;
    IEnumerator IndoMenu()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
