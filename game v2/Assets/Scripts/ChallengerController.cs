//ChallengerController reprezentuje wyzwanie, np. rozpoczęcie walki po interakcji z graczem.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengerController : MonoBehaviour, Interactable
{
    public void Interact()
    {
        // Wyświetlenie komunikatu w konsoli po rozpoczęciu interakcji
        Debug.Log("You will start a battle!");
    }
}
