using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClosingStoryManager : MonoBehaviour
{
    private Sprite imagenPasilloGuiaElegida;
    private AudioSource andarSonido;
    private bool haPulsadoBoton = false;
    private bool esFinalBueno;
    private int jugadorActual;

    [Header("Referencias de Objetos")]
    public Image playerUI, backgroundImage;
    public TextMeshProUGUI textMeshPro;
    public Button botonAceptar;
    public GameObject UiGameObject, playerUiGameObject, musicManager;

    [Header("Configuración de Imágenes")]
    public Sprite lysandraImage, garrickImage, sorremImage;
    public Sprite imagenSalaHierba, imagenSalida, imagenSalidaPadre, imagenSalidaPadreMasSorrem,
        imagenSalidaPadreMasGarrick, imagenSalidaPadreMasLysandra, imagenBosque, imagenCasa;

    [Header("Ajustes")]
    public float typingSpeed = 0.05f;

    void Start()
    {
        andarSonido = musicManager.GetComponents<AudioSource>()[1];

        esFinalBueno = PlayerPrefs.GetInt("EsFinalBueno") == 1;
        jugadorActual = PlayerPrefs.GetInt("PersonajeSeleccionado");

        AsignarValoresEscena();
        StartCoroutine(ExecuteStory());
    }

    private void Update()
    {
        // More velocity:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            typingSpeed = 0.001f;
        }
    }

    IEnumerator ExecuteStory()
    {
        // ----------------------------------------------------------------------------------- Recoger la hierba.
        backgroundImage.sprite = imagenSalaHierba;
        UiGameObject.SetActive(true);
        playerUiGameObject.SetActive(false);
        yield return StartCoroutine(TypeText("La quimera, se retira lentamente entre risas. Todo este esfuerzo os ha conducido hasta la hierba mágica."));
        yield return StartCoroutine(TypeText("Al fin la hierba está a vuestro alcance. Recogeis un par de ellas."));
        playerUiGameObject.SetActive(true);

        if (esFinalBueno)
        {
            playerUI.sprite = sorremImage;
            yield return StartCoroutine(TypeText("Sorrem: ¡Siii, lo hemos conseguido! jajajajaj."));
            playerUI.sprite = lysandraImage;
            yield return StartCoroutine(TypeText("Lysandra: Buua por fin podemos salvar a mamá."));
            playerUI.sprite = garrickImage;
            yield return StartCoroutine(TypeText("Garrick: NO ME LO CREO, por fin nos vamos a largar de este lugar."));
        }
        else
        {
            switch (jugadorActual)
            {
                case 0: // Sorrem.
                    playerUI.sprite = sorremImage;
                    yield return StartCoroutine(TypeText("Sorrem: ¡Dios no! Garrick no te mueras noo."));
                    yield return StartCoroutine(TypeText("Sorrem: Tenemos que salir de aquí, no podemos morir ahora."));
                    break;
                case 1: // Garrick.
                    playerUI.sprite = garrickImage;
                    yield return StartCoroutine(TypeText("Garrick: ¡¿Qué?! Lys despierta, Lys... LYYS. (llora)"));
                    yield return StartCoroutine(TypeText("Garrick: Espero que después de esto consigamos salvar a mamá."));
                    break;
                case 2: // Lysandra.
                    playerUI.sprite = lysandraImage;
                    yield return StartCoroutine(TypeText("Lysandra: Nooo Sorrem, no mueras noo..."));
                    yield return StartCoroutine(TypeText("Lysandra: No, debemos que ser fuerte, es lo que Sorrem diría. Debemos salir de aquí."));
                    break;
            }
        }

        // ----------------------------------------------------------------------------------- En el pasillo de salida de la Dungeon.
        // Unos segundos donde se escucha el sonido de los pasos y ves la imagen de la salida.
        UiGameObject.SetActive(false);
        playerUiGameObject.SetActive(false);
        backgroundImage.sprite = imagenSalida;
        andarSonido.enabled = true;
        yield return new WaitForSeconds(andarSonido.clip.length);
        andarSonido.Pause();

        // Se vuelve activar el UI, muestra la o las esferas guía y empieza el dialogo.
        backgroundImage.sprite = imagenPasilloGuiaElegida;
        UiGameObject.SetActive(true);
        playerUiGameObject.SetActive(true);

        if (esFinalBueno)
        {
            playerUI.sprite = sorremImage;
            yield return StartCoroutine(TypeText("Sorrem: ¡Mirad! La esfera que me ayudó antes ha vuelto."));
            yield return StartCoroutine(TypeText("Sorrem: Chicos, creo que es el espiritu de papá y nos está guiando a la salida. VAMOS"));
        }
        else
        {
            switch (jugadorActual)
            {
                case 0: // Sorrem.
                    playerUI.sprite = sorremImage;
                    yield return StartCoroutine(TypeText("Sorrem: La esfera de antes... Ahora va acompañada de otra."));
                    yield return StartCoroutine(TypeText("Sorrem: Lys, son papá y Garrick. Nos están protegiendo incluso en santa paz."));
                    yield return StartCoroutine(TypeText("Sorrem: Nos guian hasta la salida, corre."));
                    break;
                case 1: // Garrick.
                    playerUI.sprite = garrickImage;
                    yield return StartCoroutine(TypeText("Garrick: Uuh ¿dos esferas?¿serán papá y Lys?."));
                    playerUI.sprite = sorremImage;
                    yield return StartCoroutine(TypeText("Sorrem: No le des más vueltas, corre, la salida está ahí."));
                    break;
                case 2: // Lysandra.
                    playerUI.sprite = lysandraImage;
                    yield return StartCoroutine(TypeText("Lysandra: Mira Garrick, esas dos esferas son papá y Sorrem."));
                    yield return StartCoroutine(TypeText("Lysandra: Siento que nos quieren guiar hasta fuera. SIGAMOSLES."));
                    break;
            }
        }

        // ----------------------------------------------------------------------------------- Camino de vuelta.
        backgroundImage.sprite = imagenBosque;
        if (esFinalBueno)
        {
            playerUI.sprite = sorremImage;
            yield return StartCoroutine(TypeText("Sorrem: Pensandolo bien chicos, es increible todo lo que hemos vivido ¿verdad?"));
            yield return StartCoroutine(TypeText("Sorrem: Hemos luchado con criaturas terrorificas y salimos para contarlo."));
            playerUI.sprite = lysandraImage;
            yield return StartCoroutine(TypeText("Lysandra: Ahora hago mágia."));
            playerUI.sprite = garrickImage;
            yield return StartCoroutine(TypeText("Garrick: Y sobrevivimos a nuestros miedos. Quién lo diria."));
        }
        else
        {
            switch (jugadorActual)
            {
                case 0: // Sorrem.
                    playerUI.sprite = sorremImage;
                    yield return StartCoroutine(TypeText("Sorrem: Viendole el lado positivo Lys, ahora somo más fuertes."));
                    yield return StartCoroutine(TypeText("Sorrem: Nos falta papá y Garrick pero ahora podemos con todo."));
                    break;
                case 1: // Garrick.
                    playerUI.sprite = garrickImage;
                    yield return StartCoroutine(TypeText("Garrick: Todavía no me creo que estemos volviendo sin Sorrem."));
                    yield return StartCoroutine(TypeText("Garrick: Pero hemos heredado su voluntad y ahora tenemos habilidades nuevas."));
                    break;
                case 2: // Lysandra.
                    playerUI.sprite = lysandraImage;
                    yield return StartCoroutine(TypeText("Lysandra: Cuanta paz, se me hace raro pero lo agradezco."));
                    yield return StartCoroutine(TypeText("Lysandra: Ahora soy más segura y la mágia me ha cambiado por completo, pero todavía necesito pensar en todo."));
                    break;
            }
        }

        // ----------------------------------------------------------------------------------- Ya en casa.
        backgroundImage.sprite = imagenCasa;
        playerUiGameObject.SetActive(false);

        yield return StartCoroutine(TypeText("Y así fue como los hermanos Moure se adentraron a las profundidades de el laberinto de Vaelen."));
        yield return StartCoroutine(TypeText("Un lugar inhóspito y perdido, tuvieron que adentrarse para salvar a su familia."));
        yield return StartCoroutine(TypeText("Al llegar a casa, su hermana pequeña les recibió con gran entusiasmo."));

        if (esFinalBueno)
        {
            yield return StartCoroutine(TypeText("Prepararon la poción con la hierba mágica y se la diero a su mamá."));
            yield return StartCoroutine(TypeText("De repente la cara de la mádre cambió, se notaba mejor casi al instante."));
            yield return StartCoroutine(TypeText("Todos felices se unieron en un enorme abrazo y celebraron la recuperación de su familia."));
        } else
        {
            yield return StartCoroutine(TypeText("Sorrem no muy animado, se puso a preparar la poción curativa junto a Lysandra."));
            yield return StartCoroutine(TypeText("De repente la cara de la mádre cambió, se notaba mejor casi al instante."));
            yield return StartCoroutine(TypeText("Sonrieron, pensando en lo que habian dejado atrás pero felices de seguir casi todos juntos"));
        }
    }

    // Corrutina para el efecto de escribir letra por letra
    IEnumerator TypeText(string message)
    {
        textMeshPro.text = "";
        foreach (char letter in message.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        Debug.Log("Terminó de escribir todo el dialogo.");
        yield return new WaitUntil(() => haPulsadoBoton);
        haPulsadoBoton = false;
    }

    public void AlPulsarBotonContinuar()
    {
        haPulsadoBoton = true;
    }

    private void AsignarValoresEscena()
    {
        switch (jugadorActual)
        {
            case 0: // Sorrem.
                if (esFinalBueno)
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadre;
                }
                else
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadreMasGarrick; // Muere Garrick.

                }
                break;
            case 1: // Garrick.
                if (esFinalBueno)
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadre;
                }
                else
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadreMasLysandra; // Muere Lysandra.
                }
                break;
            case 2: // Lysandra.
                if (esFinalBueno)
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadre;
                }
                else
                {
                    imagenPasilloGuiaElegida = imagenSalidaPadreMasSorrem; // Muere Sorrem.
                }
                break;
        }
    }
}
