//ChallengerController reprezentuje wyzwanie, np. rozpoczêcie walki po interakcji z graczem.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengerController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {
        // Wyœwietlenie komunikatu w konsoli po rozpoczêciu interakcji
        //Debug.Log("You will start a battle!");
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
