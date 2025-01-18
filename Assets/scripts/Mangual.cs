using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mangual : MonoBehaviour
{
    public float amplitud = 10f; // Amplitud del péndulo (en grados)
    public float velocidad = 1f; // Velocidad de la oscilación (ajustado para mejor control)

    private float anguloInicial; // Ángulo inicial del objeto
    private float tiempo; // Contador de tiempo

    void Start()
    {
        // Guardar la rotación inicial del objeto
        anguloInicial = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        // Incrementar el tiempo, pero ahora lo dividimos para que se mueva más lento
        tiempo += Time.deltaTime * velocidad * 0.1f; // Multiplicamos por 0.1 para reducir la velocidad de la oscilación

        // Calcular el nuevo ángulo usando una función seno
        float angulo = amplitud * Mathf.Sin(tiempo);

        // Aplicar la rotación en el eje Z
        transform.rotation = Quaternion.Euler(0, 0, anguloInicial + angulo);
    }
}
