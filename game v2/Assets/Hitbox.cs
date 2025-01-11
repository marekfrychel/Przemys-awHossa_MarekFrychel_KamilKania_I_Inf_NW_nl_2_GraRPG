using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public EnemyCounter enemyCounter; // Przypisz GameObject z EnemyCounter w Inspectorze
    public GameObject explosionPrefab; // Prefabrykat wybuchu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Instancjuj animacjê wybuchu
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            }

            // Obs³uga animacji i zniszczenia przeciwnika
            Animator enemyAnimator = collision.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Die");
                Destroy(collision.gameObject); // Opcjonalnie opóŸnienie
            }
            else
            {
                Destroy(collision.gameObject);
            }

            // Aktualizuj licznik zabitych przeciwników
            if (enemyCounter != null)
            {
                enemyCounter.EnemyKilled();
            }
        }
    }
}
