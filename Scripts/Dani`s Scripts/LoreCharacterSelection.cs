using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoreCharacterSelection : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoEntreLetras = 0.05f;
    public string contenidoDelTexto;

    private TextMeshProUGUI miTextoUI;

    void Awake()
    {
        miTextoUI = GetComponent<TextMeshProUGUI>();
    }


    void Start()
    {

    }

    void Update()
    {

        MoreVelocity();
    }

    void MoreVelocity()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            tiempoEntreLetras = 0.001f;
        }
    }

    public void SpawnLetters()
    {
        if (string.IsNullOrEmpty(contenidoDelTexto))
        {
            contenidoDelTexto = miTextoUI.text;
        }
        StopAllCoroutines();

        StartCoroutine(EscribirTexto());
    }

    IEnumerator EscribirTexto()
    {
        miTextoUI.text = "";

        foreach (char letra in contenidoDelTexto.ToCharArray())
        {
            miTextoUI.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
    }
}