using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogBoxSystem : MonoBehaviour, IPointerClickHandler
{
    [System.Serializable]
    public struct LineaDialogo
    {
        public string nombrePersonaje;
        [TextArea(3, 5)] public string texto;
        public AudioClip sonidoVoz;
        public float velocidad;
    }

    [Header("Configuración de Diálogo")]
    [SerializeField] private List<LineaDialogo> conversacion;
    [SerializeField] private TextMeshProUGUI textoGUI;
    [SerializeField] private TextMeshProUGUI nombreGUI;
    [SerializeField] private AudioSource fuenteAudio;

    private int indiceActual = 0;
    private bool estaEscribiendo = false;
    private bool saltoSolicitado = false;
    private Coroutine corrutinaEscritura;

    void Start()
    {
        if (conversacion.Count > 0)
            IniciarLinea(0);
    }

    void Update()
    {
        // Detectar Tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GestionarAvance();
        }
    }

    // Detectar Clic en el área de texto (si tiene Raycast Target)
    public void OnPointerClick(PointerEventData eventData)
    {
        GestionarAvance();
    }

    // Función pública para llamar desde un BOTÓN de la UI
    public void BotonSiguiente()
    {
        GestionarAvance();
    }

    private void GestionarAvance()
    {
        if (estaEscribiendo)
        {
            saltoSolicitado = true;
        }
        else
        {
            SiguienteLinea();
        }
    }

    private void SiguienteLinea()
    {
        indiceActual++;
        if (indiceActual < conversacion.Count)
        {
            IniciarLinea(indiceActual);
        }
        else
        {
            TerminarDialogo();
        }
    }

    private void IniciarLinea(int indice)
    {
        if (corrutinaEscritura != null) StopCoroutine(corrutinaEscritura);
        corrutinaEscritura = StartCoroutine(EscribirTexto(conversacion[indice]));
    }

    IEnumerator EscribirTexto(LineaDialogo linea)
    {
        estaEscribiendo = true;
        saltoSolicitado = false;
        textoGUI.text = "";
        nombreGUI.text = linea.nombrePersonaje;

        foreach (char letra in linea.texto.ToCharArray())
        {
            if (saltoSolicitado)
            {
                textoGUI.text = linea.texto;
                break;
            }

            textoGUI.text += letra;

            if (fuenteAudio && linea.sonidoVoz && !char.IsWhiteSpace(letra))
            {
                fuenteAudio.pitch = Random.Range(0.85f, 1.15f);
                fuenteAudio.PlayOneShot(linea.sonidoVoz);
            }

            yield return new WaitForSeconds(linea.velocidad > 0 ? linea.velocidad : 0.05f);
        }

        yield return null; // Pequeña espera para evitar saltos accidentales
        estaEscribiendo = false;
        saltoSolicitado = false;
    }

    private void TerminarDialogo()
    {
        textoGUI.text = "";
        nombreGUI.text = "";
        Debug.Log("Evento de inicio de combate invocado.");
        // Aquí podrías desactivar el Panel de diálogo
        gameObject.SetActive(false);
    }
}