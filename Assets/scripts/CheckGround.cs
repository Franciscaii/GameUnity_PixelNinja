using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el objeto está en contacto con el suelo
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detecta si el objeto dejó de estar en contacto con el suelo
        isGrounded = false;
    }
}

