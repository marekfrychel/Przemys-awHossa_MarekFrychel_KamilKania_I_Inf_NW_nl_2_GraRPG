using UnityEngine;
using TMPro; // Jeœli u¿ywasz TextMeshPro

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Przypisz w inspectorze
    private int killCount = 0;       // Licznik zabójstw

    public void EnemyKilled()
    {
        killCount++;
        UpdateScoreText();
        CheckWinCondition();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + killCount;
    }

    private void CheckWinCondition()
    {
        if (killCount >= 5)
        {
            Debug.Log("You killed 5 enemies!");
            // Tutaj mo¿esz dodaæ inne akcje, np. przejœcie do nastêpnego poziomu
        }
    }
}
