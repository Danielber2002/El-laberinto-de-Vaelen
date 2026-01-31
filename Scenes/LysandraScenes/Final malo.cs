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
    public GameObject botonSiguiente;

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

    public void IrAPuertaMala()
    {
        SceneManager.LoadScene("Puerta Mala");
    }

    void ActualizarCorazonesVisuales()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null)
                corazones[i].SetActive(i < vidasRestantes);
        }
    }

    void Update()
    {
        PlayerPrefs.SetInt("EsFinalBueno", vidasRestantes >= 3 ? 1 : 0);
        PlayerPrefs.Save();
    }
}