using UnityEngine;
using UnityEngine.InputSystem;

public class ControlFiguras : MonoBehaviour
{
    public GameObject[] figuras;

    private Vector3 posicionElegida = new Vector3(0.677f, 1.431f, -0.203f);

    private Color[] colores = { Color.red, Color.green, Color.blue };
    private Vector3[] tamanos = { new Vector3(0.1f, 0.1f, 0.1f), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0.4f, 0.4f, 0.4f) };
    private Vector3[] rotaciones = { new Vector3(90, 0, 0), new Vector3(0, 90, 0), new Vector3(0, 0, 90) };

    private bool figuraElegida = false;
    private bool colorElegido = false;
    private bool tamanoElegido = false;
    private bool rotacionElegida = false;
    private bool confirmado = false;

    private int indice = 0;
    private GameObject figuraActual;

    private Vector3[] posicionesOriginales;
    private Vector3[] escalasOriginales;

    private InputAction botonB = new InputAction(binding: "<XRController>{RightHand}/secondaryButton");
    private InputAction gatilloElegir = new InputAction(binding: "<XRController>{RightHand}/triggerPressed");
    private InputAction gatilloReiniciar = new InputAction(binding: "<XRController>{LeftHand}/triggerPressed");
    private InputAction gatilloConfirmar = new InputAction(binding: "<XRController>{RightHand}/gripPressed");

    void Start()
    {
        posicionesOriginales = new Vector3[figuras.Length];
        escalasOriginales = new Vector3[figuras.Length];

        for (int i = 0; i < figuras.Length; i++)
        {
            posicionesOriginales[i] = figuras[i].transform.position;
            escalasOriginales[i] = figuras[i].transform.localScale;
        }

        botonB.Enable();
        gatilloElegir.Enable();
        gatilloReiniciar.Enable();
        gatilloConfirmar.Enable();

        ResaltarFigura();
    }

    void Update()
    {
        if (gatilloReiniciar.WasPressedThisFrame())
        {
            Reiniciar();
            return;
        }

        if (confirmado) return;

        if (gatilloConfirmar.WasPressedThisFrame()) Confirmar();

        if (!figuraElegida) ManejarFigura();
        else if (!colorElegido) ManejarColor();
        else if (!tamanoElegido) ManejarTamano();
        else if (!rotacionElegida) ManejarRotacion();
    }

    void ResaltarFigura()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            if (i == indice) figuras[i].transform.localScale = escalasOriginales[i] * 1.3f;
            else figuras[i].transform.localScale = escalasOriginales[i];
        }
    }

    void ManejarFigura()
    {
        if (botonB.WasPressedThisFrame())
        {
            indice = (indice + 1) % figuras.Length;
            ResaltarFigura();
        }

        if (gatilloElegir.WasPressedThisFrame())
        {
            figuraActual = figuras[indice];

            for (int i = 0; i < figuras.Length; i++)
            {
                figuras[i].SetActive(i == indice);
            }

            figuraActual.transform.localScale = escalasOriginales[indice];
            figuraActual.transform.position = posicionElegida;
            figuraActual.GetComponent<Renderer>().material.color = colores[0];

            figuraElegida = true;
            indice = 0;
        }
    }

    void ManejarColor()
    {
        if (botonB.WasPressedThisFrame())
        {
            indice = (indice + 1) % colores.Length;
            figuraActual.GetComponent<Renderer>().material.color = colores[indice];
        }

        if (gatilloElegir.WasPressedThisFrame())
        {
            colorElegido = true;
            indice = 0;
            figuraActual.transform.localScale = tamanos[0];
        }
    }

    void ManejarTamano()
    {
        if (botonB.WasPressedThisFrame())
        {
            indice = (indice + 1) % tamanos.Length;
            figuraActual.transform.localScale = tamanos[indice];
        }

        if (gatilloElegir.WasPressedThisFrame())
        {
            tamanoElegido = true;
            indice = 0;
            figuraActual.transform.eulerAngles = rotaciones[0];
        }
    }

    void ManejarRotacion()
    {
        if (botonB.WasPressedThisFrame())
        {
            indice = (indice + 1) % rotaciones.Length;
            figuraActual.transform.eulerAngles = rotaciones[indice];
        }

        if (gatilloElegir.WasPressedThisFrame())
        {
            rotacionElegida = true;
        }
    }

    void Confirmar()
    {
        if (figuraElegida && colorElegido && tamanoElegido && rotacionElegida)
        {

            //Here is where you have to work Armando
            confirmado = true;
            Debug.Log("Respuesta confirmada");
        }
    }

    void Reiniciar()
    {
        for (int i = 0; i < figuras.Length; i++)
        {
            figuras[i].SetActive(true);
            figuras[i].transform.position = posicionesOriginales[i];
            figuras[i].transform.localScale = escalasOriginales[i];
            figuras[i].transform.rotation = Quaternion.identity;
            figuras[i].GetComponent<Renderer>().material.color = Color.white;
        }

        figuraElegida = false;
        colorElegido = false;
        tamanoElegido = false;
        rotacionElegida = false;
        confirmado = false;

        indice = 0;
        figuraActual = null;

        ResaltarFigura();
    }
}
