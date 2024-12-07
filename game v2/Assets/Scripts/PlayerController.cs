using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr�dko�� poruszania si�

    private Vector2 input; // Wektor wej�ciowy (ruch)
    private Rigidbody2D rb; // Komponent Rigidbody2D
    private Animator animator; // Komponent Animatora

    // Warstwy dla obiekt�w interaktywnych
    public LayerMask interactableLayer;

    private void Awake()
    {
        // Pobierz komponenty przypisane do obiektu
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Sprawd�, czy Rigidbody2D jest przypisane
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from Player!");
        }
    }

    private void Update()
    {
        // Odczyt ruchu gracza z wej�cia
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Normalizacja wektora, aby ruch po skosie by� r�wny
        if (input.magnitude > 1)
            input = input.normalized;

        // Obs�uga animacji
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);
        animator.SetBool("isMoving", input.magnitude > 0);

        // Obs�uga interakcji po naci�ni�ciu klawisza Z
        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    private void FixedUpdate()
    {
        // Przesuwanie postaci z u�yciem Rigidbody2D
        rb.velocity = input * moveSpeed;
    }

    void Interact()
    {
        // Ustalanie kierunku interakcji
        Vector3 facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        Vector3 interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        // Sprawd�, czy gracz dotyka obiektu interaktywnego
        Collider2D collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact(); // Wywo�anie interakcji
        }
    }
}
