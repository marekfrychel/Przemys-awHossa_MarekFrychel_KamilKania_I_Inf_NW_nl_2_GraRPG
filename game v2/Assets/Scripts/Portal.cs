using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Zatrzymanie gracza przed przeniesieniem
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Zerowanie pr�dko�ci
                rb.angularVelocity = 0f;    // Zerowanie pr�dko�ci obrotu
                Debug.Log("Rigidbody2D pr�dko�� i moment obrotowy zosta�y zresetowane.");
            }

            // Przenoszenie gracza do nowej pozycji
            collision.transform.position = destination.position;

            // Resetowanie animacji i ruchu gracza
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            //{
            //    playerController.ResetInput(); // Resetowanie ruchu i animacji gracza
            //}

            Debug.Log("Gracz przeszed� przez portal!");
        }
    }
}
