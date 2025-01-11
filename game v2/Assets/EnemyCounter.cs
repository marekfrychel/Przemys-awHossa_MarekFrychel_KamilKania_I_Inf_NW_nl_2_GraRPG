using UnityEngine;
using TMPro; // Je�li u�ywasz TextMeshPro

public class EnemyCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Przypisz w inspectorze
    private int killCount = 0;       // Licznik zab�jstw

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
            // Tutaj mo�esz doda� inne akcje, np. przej�cie do nast�pnego poziomu
        }
    }
}
