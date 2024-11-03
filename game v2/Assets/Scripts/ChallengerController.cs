//ChallengerController reprezentuje wyzwanie, np. rozpocz�cie walki po interakcji z graczem.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengerController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    public void Interact()
    {
        // Wy�wietlenie komunikatu w konsoli po rozpocz�ciu interakcji
        //Debug.Log("You will start a battle!");
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
