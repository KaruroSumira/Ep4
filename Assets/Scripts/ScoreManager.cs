using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text puntosText;
    private int puntos = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdatePuntosText();
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntos += cantidad;
        UpdatePuntosText();
    }

    void UpdatePuntosText()
    {
        puntosText.text = "Puntos: " + puntos.ToString();
    }
}
