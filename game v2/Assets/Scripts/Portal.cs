using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination; // Miejsce docelowe portalu

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coœ wesz³o do portalu: " + other.name); // Sprawdzamy, co wchodzi do portalu

        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wchodzi do portalu.");

            if (destination != null)
            {
                other.transform.position = destination.position;
                Debug.Log("Gracz zosta³ przeniesiony.");
            }
            else
            {
                Debug.LogError("Nie ustawiono miejsca docelowego portalu!");
            }
        }
    }
}
