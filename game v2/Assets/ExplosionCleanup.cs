using UnityEngine;

public class ExplosionCleanup : MonoBehaviour
{
    private void Start()
    {
        // Zniszcz obiekt po czasie trwania animacji
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
}
