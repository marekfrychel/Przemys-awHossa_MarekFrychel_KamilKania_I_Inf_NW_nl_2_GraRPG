using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private void Awake()
    {
        // Pobiera komponent Animator przypisany do tego obiektu
        animator = GetComponent<Animator>();
        //Debug.Log("Animator: " + animator);
    }

    //Update jest wywo�ywany raz na klatk�
    private void Update()
    {
        // Przetwarzaj wej�cie tylko, je�li gracz aktualnie si� nie porusza 
        if (!isMoving)
        {
            // Pobiera poziome wej�cia (lewo/prawo)
            input.x = Input.GetAxisRaw("Horizontal");
            // Pobiera pionowe wej�ci� (g�ra/d�)
            input.y = Input.GetAxisRaw("Vertical");

            // Je�li jest wej�cie poziome, ustaw pionowe wej�cie na 0, aby zapobiec ruchowi diagonalnemu 
            if (input.x != 0) input.y = 0;
            // Je�li istnieje jakie� wej�cie ( nie jest wektorem zerowym), przejd� do logiki ruchu 
            if (input != Vector2.zero)
            {
                // Ustaw parametry animacji w oparciu o kierunek wej�cia
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                //Debug.Log("This is input.x" + input.x);

                // Oblicza docelow� pozycj� w oparciu o aktualn� pozycj� i kierunek wej�cia 
                var targetPos = transform.position;
                // Dostosowuje docelow� pozycj� w kierunku x
                targetPos.x += input.x;
                // Dostosowuje docelow� pozycj� w kierunku y
                targetPos.y += input.y;

                // Sprawdza, czy docelowa pozycja jest przejezdna ( brak przeszk�d )
                if (IsWalkable(targetPos))
                    // Rozpoczyna korutyn� Move, aby poruszy� gracza
                    StartCoroutine(Move(targetPos));


                
            }
        }

        // Aktualizuje parametr isMoving animatora, aby odzwierciedli�, czy gracz si� porusza 
        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
    // Korutyna do poruszania gracza do docelowej pozycji
    IEnumerator Move(Vector3 targetPos)
    {
        // Ustawia isMoving na true, aby zapobiec nowym wej�ciom podczas ruchu
        isMoving = true;

        // Porusza si� w kierunku docelowej pozycji, dop�ki odleg�o�� nie b�dzie bardzo ma�a (sqrMagnitude > Mathf.Epsilon )
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Przesuwa gracza w kierunku docelowej pozycji za pomoc� Vector3.MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            // Czeka na nast�pn� klatk�
            yield return null;
        }
        // Ustawia pozycj� na docelow�, aby upewni� si�, �e gracz ko�czy dok�adnie na docelowej pozycji.
        transform.position = targetPos;
        // Pozwala na nowe wej�cia po osi�gni�ciu docelowej pozycji.
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // U�ywa OverlapCircle, aby sprawdzi�, czy w ma�ym okr�gu wok� docelowej pozycji znajduj� si� jakiekolwiek kolidery.
        // Je�li znajd� si� jakiekolwiek kolidery w okre�lonych warstwach, pozycja nie jest przejezdna.
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | interactableLayer) != null)
        {
            // Pozycja nie jest przejezdna
            return false;
        }
        // Pozycja jest przejezdna
        return true;
    }

}