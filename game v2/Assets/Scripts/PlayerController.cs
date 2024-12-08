using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Pr�dko�� ruchu gracza
    public float stepSize = 0.1f; // D�ugo�� kroku (mniejsza warto�� = p�ynniejsze ruchy)

    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    // Warstwy wykorzystywane do sprawdzenia przeszk�d i obiekt�w interaktywnych
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private void Awake()
    {
        // Pobiera komponent Animator przypisany do tego obiektu
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        // Obs�uguje wej�cia tylko, gdy gracz nie porusza si�
        if (!isMoving)
        {
            // Pobiera wej�cia poziome i pionowe (pozwala na ruch po skosie)
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input != Vector2.zero)
            {
                // Normalizacja wektora, aby zachowa� r�wn� pr�dko�� we wszystkich kierunkach
                input.Normalize();

                // Ustawia kierunek animacji
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                // Ustalanie docelowej pozycji na podstawie kierunku
                var targetPos = transform.position;
                targetPos.x += input.x * stepSize;
                targetPos.y += input.y * stepSize;

                // Sprawdza, czy docelowa pozycja jest przejezdna
                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos)); // Rozpocznij ruch
            }
        }

        animator.SetBool("isMoving", isMoving); // Aktualizacja stanu animacji

        if (Input.GetKeyDown(KeyCode.Z))
            Interact(); // Wywo�anie interakcji, je�li naci�ni�to Z
    }

    void Interact()
    {
        // Ustalanie kierunku interakcji
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        // Sprawdzanie kolizji z obiektem interaktywnym
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact(); // Wywo�anie interakcji
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        // Poruszanie gracza do docelowej pozycji
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Przesuwamy gracza o mniejszy krok w kierunku celu
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Sprawdza, czy na docelowej pozycji nie ma przeszk�d
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | interactableLayer) == null;
    }
}
