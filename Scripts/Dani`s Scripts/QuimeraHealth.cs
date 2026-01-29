using UnityEngine;
using UnityEngine.SceneManagement;

public class QuimeraHealth : MonoBehaviour
{
    [Header("Corazones")]
    public GameObject[] corazones;

    public static int vidasRestantes = 4;

    void Start()
    {
        ActualizarCorazonesVisuales();
    }

    public void RestarVida()
    {
        if (vidasRestantes > 0)
        {
            vidasRestantes--;
            ActualizarCorazonesVisuales(); 

            if (vidasRestantes <= 0)
            {
                GameOver();
            }
        }
    }

    void ActualizarCorazonesVisuales()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidasRestantes)
            {
                corazones[i].SetActive(true);
            }
            else
            {
                corazones[i].SetActive(false);
            }
        }
    }

    public void ReiniciarVidas()
    {
        vidasRestantes = 4;
        ActualizarCorazonesVisuales();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Update()
    {
        if (vidasRestantes >= 3)
        {
            PlayerPrefs.SetInt("EsFinalBueno", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("EsFinalBueno", 0);
            PlayerPrefs.Save();
        }
    }   
}