using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Corazones")]
    public GameObject[] corazones;

    public static int vidasRestantes = 3;

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
        vidasRestantes = 3;
        ActualizarCorazonesVisuales();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}