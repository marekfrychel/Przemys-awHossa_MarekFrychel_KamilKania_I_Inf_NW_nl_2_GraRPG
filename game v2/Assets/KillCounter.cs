using UnityEngine;
using TMPro; // Je�li u�ywasz TextMeshPro

public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Przypisz w inspectorze
    private int killCount = 0;       // Zmienna do przechowywania liczby zab�jstw

    public void AddKill()
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
            // Tutaj mo�esz doda� inne akcje, np. zako�czenie poziomu
        }
    }
}
