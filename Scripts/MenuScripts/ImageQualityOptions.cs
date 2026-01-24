using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImageQualityOptions : MonoBehaviour
{
    public TMP_Dropdown dropdownCalidad;
    private const string PrefCalidad = "NivelCalidad";

    void Start()
    {
        // 1. Configurar el Dropdown con los nombres de QualitySettings
        dropdownCalidad.ClearOptions();
        List<string> opciones = new List<string>(QualitySettings.names);
        dropdownCalidad.AddOptions(opciones);

        // 2. Cargar la calidad guardada o usar la actual por defecto
        // Si no existe la clave "NivelCalidad", usa el nivel actual
        int calidadGuardada = PlayerPrefs.GetInt(PrefCalidad, QualitySettings.GetQualityLevel());

        // 3. Aplicar la calidad al juego y al Dropdown
        ActualizarCalidad(calidadGuardada);
        dropdownCalidad.value = calidadGuardada;
        dropdownCalidad.RefreshShownValue();

        // 4. Asignar el evento de cambio
        dropdownCalidad.onValueChanged.AddListener(CambiarCalidad);
    }

    public void CambiarCalidad(int indice)
    {
        ActualizarCalidad(indice);

        // Guardar la elección permanentemente
        PlayerPrefs.SetInt(PrefCalidad, indice);
        PlayerPrefs.Save(); // Asegura que se escriba en el disco

        Debug.Log("Calidad guardada: " + QualitySettings.names[indice]);
    }

    private void ActualizarCalidad(int indice)
    {
        // Cambia el nivel de calidad del motor
        QualitySettings.SetQualityLevel(indice, true);
    }
}
