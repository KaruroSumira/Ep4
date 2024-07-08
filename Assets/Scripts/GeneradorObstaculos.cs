using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public int cantidadObstaculos = 10;
    public float distanciaEntreObstaculos = 2f;

    void Start()
    {
        Vector3 posicionInicial = transform.position;

        for (int i = 0; i < cantidadObstaculos; i++)
        {
            Vector3 posicionObstaculo = posicionInicial + Vector3.right * i * distanciaEntreObstaculos;

            Instantiate(obstaculoPrefab, posicionObstaculo, Quaternion.identity);
        }
    }
}

