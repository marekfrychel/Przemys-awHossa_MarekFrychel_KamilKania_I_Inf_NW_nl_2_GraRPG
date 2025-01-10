using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Pobierz Animator przeciwnika
            Animator enemyAnimator = collision.GetComponent<Animator>();

            if (enemyAnimator != null)
            {
                // Wywo�aj animacj� umierania
                enemyAnimator.SetTrigger("Die");

                // Wy��cz Collider, �eby przeciwnik nie reagowa� dalej
                Collider2D enemyCollider = collision.GetComponent<Collider2D>();
                if (enemyCollider != null)
                {
                    enemyCollider.enabled = false;
                }

                // Zniszcz przeciwnika po zako�czeniu animacji
                Destroy(collision.gameObject, enemyAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
