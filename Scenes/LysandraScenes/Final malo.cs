using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finalmalo : MonoBehaviour
{
    [Header("Corazones")]
    public GameObject[] corazones;

    [Header("Configuración de Fondo")]
    public GameObject fondoNormal;
    public GameObject fondoDañado;

    [Header("Limpieza de Interfaz")]

    public GameObject contenidoAcertijo;

    [Header("UI Siguiente Nivel")]
    public GameObject botonSiguiente, botonContinuar;

    public static int vidasRestantes = 4;
    private bool yaSeActivoElFinal = false;

    void Start()
    {
        vidasRestantes = 4;
        yaSeActivoElFinal = false;
        ActualizarCorazonesVisuales();

        if (fondoNormal) fondoNormal.SetActive(true);
        if (fondoDañado) fondoDañado.SetActive(false);
        if (botonSiguiente) botonSiguiente.SetActive(false);


        if (contenidoAcertijo) contenidoAcertijo.SetActive(true);
    }


    void ActivarSecuenciaFinal()
    {
        yaSeActivoElFinal = true;

        // 1. DESACTIVAMOS la interfaz vieja para que no estorbe
        if (contenidoAcertijo)
            contenidoAcertijo.SetActive(false);

        // 2. Cambiamos las imágenes de fondo
        if (fondoNormal) fondoNormal.SetActive(false);
        if (fondoDañado) fondoDañado.SetActive(true);

        // 3. Activamos el botón "Siguiente"
        if (botonSiguiente)
        {
            botonSiguiente.SetActive(true);
            botonSiguiente.transform.SetAsLastSibling();
        }
    }

    void ActualizarCorazonesVisuales()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null)
                corazones[i].SetActive(i < vidasRestantes);
        }
    }

    public void RestarVida()
    {
        if (yaSeActivoElFinal) return;

        if (vidasRestantes > 0)
        {
            vidasRestantes--;
            ActualizarCorazonesVisuales();

            if (vidasRestantes <= 2)
            {
                ActivarSecuenciaFinal();
            }
        }
    }

    /// <summary>
    /// Si en el último acertijo fallas pero tienes más de 2 vidas (de 4),
    /// cuenta como exito y debe aparecer el botón de continuar.
    /// </summary>
    public void ActivarBotonContinuar()
    {
        if (vidasRestantes >= 3)
        {
            botonContinuar.SetActive(true);
        }
    }

    public void ClosingStoryScene()
    {
        PlayerPrefs.SetInt("EsFinalBueno", vidasRestantes >= 3 ? 1 : 0);
        Debug.Log(string.Format("Claves: EsFinalBueno= {0}", vidasRestantes >= 3 ? 1 : 0));
        PlayerPrefs.Save();
        SceneManager.LoadScene("ClosingStoryScene");
    }
}