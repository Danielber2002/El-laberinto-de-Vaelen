using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResolutionOptions : MonoBehaviour
{
    public TMP_Dropdown dropdownResolucion;
    private List<Resolution> resolucionesFiltradas; // Lista limpia para usar en el juego
    private const string PrefFullscreen = "PantallaCompleta";

    void Start()
    {
        ConfigurarResolucion();
    }

    void ConfigurarResolucion()
    {
        dropdownResolucion.ClearOptions();

        // 1. Obtener todas las resoluciones
        Resolution[] todasLasResoluciones = Screen.resolutions;

        // 2. Filtrar usando LINQ:
        // - Agrupamos por ancho y alto.
        // - De cada grupo, seleccionamos la que tenga la mayor tasa de refresco.
        // - Ordenamos de menor a mayor para el menú.
        resolucionesFiltradas = todasLasResoluciones
            .GroupBy(res => new { res.width, res.height })
            .Select(grupo => grupo.OrderByDescending(res => res.refreshRateRatio.value).First())
            .OrderBy(res => res.width)
            .ThenBy(res => res.height)
            .ToList();

        List<string> opciones = new List<string>();
        int indiceResolucionActual = 0;

        for (int i = 0; i < resolucionesFiltradas.Count; i++)
        {
            string opcion = resolucionesFiltradas[i].width + " x " + resolucionesFiltradas[i].height;
            opciones.Add(opcion);

            // Comprobar si es la resolución que el monitor tiene activa ahora
            if (resolucionesFiltradas[i].width == Screen.currentResolution.width &&
                resolucionesFiltradas[i].height == Screen.currentResolution.height)
            {
                indiceResolucionActual = i;
            }
        }

        dropdownResolucion.AddOptions(opciones);
        dropdownResolucion.value = indiceResolucionActual;
        dropdownResolucion.RefreshShownValue();

        dropdownResolucion.onValueChanged.AddListener(CambiarResolucion);
    }

    public void CambiarResolucion(int indice)
    {
        Resolution res = resolucionesFiltradas[indice];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void CambiarPantallaCompleta(bool estado)
    {
        Screen.fullScreen = estado;
        PlayerPrefs.SetInt(PrefFullscreen, estado ? 1 : 0);
        PlayerPrefs.Save();
    }
}
