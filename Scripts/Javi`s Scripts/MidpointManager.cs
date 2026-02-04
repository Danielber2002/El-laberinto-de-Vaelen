using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MidpointManager : MonoBehaviour
{
    private bool haPulsadoBoton = false;
    private AudioSource andarSonido, derrumbeSonido;

    [Header("Referencias de Objetos")]
    public Image playerUI, backgroundImage;
    public TextMeshProUGUI textMeshPro;
    public Button botonAceptar;
    public GameObject UiGameObject, musicManager;

    [Header("Configuración de Imágenes")]
    public Sprite lysandraImage, garrickImage, sorremImage;
    public Sprite antesalaBackground, salaBackground, derrumbeBackground;

    [Header("Ajustes")]
    public float typingSpeed = 0.05f;

    void Start()
    {
        andarSonido = musicManager.GetComponents<AudioSource>()[1];
        derrumbeSonido = musicManager.GetComponents<AudioSource>()[2];

        StartCoroutine(ExecuteSequence());
    }

    private void Update()
    {
        // More velocity:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            typingSpeed = 0.001f;
        }
    }

    IEnumerator ExecuteSequence()
    {
        // ----------------------------------------------------------------------------------- En el pasillo.
        // 1. Asignamos la imagen del pasillo y activamos el sonido de pisadas.
        backgroundImage.sprite = antesalaBackground;
        Debug.Log("El sonido comienza");
        andarSonido.enabled = true;
        yield return new WaitForSeconds(andarSonido.clip.length); // Espera el tiempo exacto de la duración del clip.
        Debug.Log("El sonido ha terminado de reproducirse");

        // ----------------------------------------------------------------------------------- En la sala.
        // 2. Asignamos la imagen de la sala, habilitamos la UI y comienza el dialogo entre hermanos.
        backgroundImage.sprite = salaBackground;
        UiGameObject.SetActive(true);

        // --------------------------------------------- Introducción.
        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: ¡CHICOS!¡Seguís vivos! BIEEEN."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: Qué alegría de veros, estaba muy preocupado por ustedes."));
        yield return StartCoroutine(TypeText("Sorrem: ¿Habréis tenido cuidado de no perder nada importante por el camino, no?"));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Vaya que sí, me alegro de verle, hermanita jajajaja."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: Ni en una mazmorra como esta aprendes, macho."));

        // ---- Miedos
        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: Por lo menos Garrick no se ha topado con un enjambre de serpientes, pff."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Aaagh, por favor, ni las menciones."));
        yield return StartCoroutine(TypeText("Garrick: Entonces ¿cómo es que estás aquí con nosotros? Con el miedo que te da una sola rata."));
        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: De puro milagro. Casi parece que el destino lo puso allí pensando en mí."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Bueno, al menos no fue un león. Ese bicho te pilla y le tienes que rascar la barriguita jajaja."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: ¡Eeeh! Basta ya, yo no me he metido con vuestros miedos ¿vale?"));
        yield return StartCoroutine(TypeText("Sorrem: Booff, qué dos..."));

        // --------------------------------------------- Presentación de la sala y su acertijo.
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: Vamos a seguir con lo que tenemos aquí."));
        yield return StartCoroutine(TypeText("Sorrem: Veo que aquí no nos dejan pasar, el portón de enfrente no tiene ni pomo ni cerradura."));
        yield return StartCoroutine(TypeText("Sorrem: Nada... Tocará resolver el acertijo de esta sala. A este paso no terminaremos nunca."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: ¡Jo, qué pesimista! Pues otra más, ya ves..."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: Mmmmm."));
        yield return StartCoroutine(TypeText("Sorrem: El acertijo dice: El valor no nace, se forja con el tiempo. Primero el sueño, después el acero. El trono se alcanza con sangre y esfuerzo, y al final, solo queda el silencio del entierro."));
        // --------------------------------------------- Conflicto.
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: Vale, no es tan difícil. Normalmente siempre hay alguna trampa y aquí seguro que pasa lo mismo..."));
        yield return StartCoroutine(TypeText("Garrick: Estoy seguro de que el orden es: estatua del crío > estatua del guerrero > estatua del viejo > estatua del rey."));
        yield return StartCoroutine(TypeText("Garrick: El rey es el final del camino."));
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: ¡NO, Garrick, no! Es el ciclo del héroe, así que no tiene sentido que jueguen al despiste tan deshonestamente."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: ¿Qué nos dices? Soy yo quien ha estado evitando trampas. Aquí no tienes ni idea de cómo va esto, deja de mandar por una vez."));
        playerUI.sprite = lysandraImage;
        yield return StartCoroutine(TypeText("Lysandra: Caaalma, chicos, caalma. Tiene parte de sentido lo que habláis los dos, así que vamos a tranquilizarnos primero."));
        playerUI.sprite = garrickImage;
        yield return StartCoroutine(TypeText("Garrick: ¿Para qué? Si al final se va a hacer lo que Sorrem quiera. Mamá está muriéndose y no paramos de perder el tiempo aquí. Hay que actuar más."));
        // ----------------------------------------------------------------------------------- Derrumbe.
        playerUI.sprite = sorremImage;
        yield return StartCoroutine(TypeText("Sorrem: ¿Qué haces, Garrick? ¡NO TOQUES LAS PALANCAS!"));
        yield return StartCoroutine(TypeText("Sorrem: ¡NOOO!"));
        derrumbeSonido.enabled = true;
        backgroundImage.sprite = derrumbeBackground;
        yield return new WaitForSeconds(derrumbeSonido.clip.length);
        derrumbeSonido.Pause();


        switch (PlayerPrefs.GetInt("PersonajeSeleccionado"))
        {
            case 0: // Sorrem.
                SceneManager.LoadScene("Sorrem-4 Introduccion");
                break;
            case 1: // Garrick.
                SceneManager.LoadScene("Garrick-Parte_II-Intro");
                break;
            case 2: // Lysandra.
                SceneManager.LoadScene("Lysandra-Parte_II-Intro");
                break;
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
}
