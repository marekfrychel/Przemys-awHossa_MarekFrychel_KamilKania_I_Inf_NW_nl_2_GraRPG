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

    //Update jest wywo³ywany raz na klatkê
    private void Update()
    {
        // Przetwarzaj wejœcie tylko, jeœli gracz aktualnie siê nie porusza 
        if (!isMoving)
        {
            // Pobiera poziome wejœcia (lewo/prawo)
            input.x = Input.GetAxisRaw("Horizontal");
            // Pobiera pionowe wejœci¹ (góra/dó³)
            input.y = Input.GetAxisRaw("Vertical");

            // Jeœli jest wejœcie poziome, ustaw pionowe wejœcie na 0, aby zapobiec ruchowi diagonalnemu 
            if (input.x != 0) input.y = 0;
            // Jeœli istnieje jakieœ wejœcie ( nie jest wektorem zerowym), przejdŸ do logiki ruchu 
            if (input != Vector2.zero)
            {
                // Ustaw parametry animacji w oparciu o kierunek wejœcia
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                //Debug.Log("This is input.x" + input.x);

                // Oblicza docelow¹ pozycjê w oparciu o aktualn¹ pozycjê i kierunek wejœcia 
                var targetPos = transform.position;
                // Dostosowuje docelow¹ pozycjê w kierunku x
                targetPos.x += input.x;
                // Dostosowuje docelow¹ pozycjê w kierunku y
                targetPos.y += input.y;

                // Sprawdza, czy docelowa pozycja jest przejezdna ( brak przeszkód )
                if (IsWalkable(targetPos))
                    // Rozpoczyna korutynê Move, aby poruszyæ gracza
                    StartCoroutine(Move(targetPos));


                
            }
        }

        // Aktualizuje parametr isMoving animatora, aby odzwierciedliæ, czy gracz siê porusza 
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
        // Ustawia isMoving na true, aby zapobiec nowym wejœciom podczas ruchu
        isMoving = true;

        // Porusza siê w kierunku docelowej pozycji, dopóki odleg³oœæ nie bêdzie bardzo ma³a (sqrMagnitude > Mathf.Epsilon )
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // Przesuwa gracza w kierunku docelowej pozycji za pomoc¹ Vector3.MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            // Czeka na nastêpn¹ klatkê
            yield return null;
        }
        // Ustawia pozycjê na docelow¹, aby upewniæ siê, ¿e gracz koñczy dok³adnie na docelowej pozycji.
        transform.position = targetPos;
        // Pozwala na nowe wejœcia po osi¹gniêciu docelowej pozycji.
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // U¿ywa OverlapCircle, aby sprawdziæ, czy w ma³ym okrêgu wokó³ docelowej pozycji znajduj¹ siê jakiekolwiek kolidery.
        // Jeœli znajd¹ siê jakiekolwiek kolidery w okreœlonych warstwach, pozycja nie jest przejezdna.
        if (Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | interactableLayer) != null)
        {
            // Pozycja nie jest przejezdna
            return false;
        }
        // Pozycja jest przejezdna
        return true;
    }

}