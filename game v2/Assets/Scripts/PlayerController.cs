using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; // Prêdkoœæ ruchu gracza
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        // Pobiera komponent Animator i Rigidbody2D przypisane do tego obiektu
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                input.Normalize();

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x * moveSpeed * Time.deltaTime;
                targetPos.y += input.y * moveSpeed * Time.deltaTime;

                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }

    public void ResetInput()
    {
        // Resetuje wszystkie zmienne ruchu i animacji
        input = Vector2.zero;  // Zerowanie inputu, aby gracz nie rusza³ siê
        isMoving = false;

        // Resetuje wartoœci w Animatorze
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", 0); // Neutralny stan (brak ruchu)
        animator.SetBool("isMoving", false);

        Debug.Log("Input i animacje zosta³y zresetowane.");
    }
}
