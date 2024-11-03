// NPCController reprezentuje NPC, który wyœwietla dialog, gdy gracz wejdzie z nim w interakcjê.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog; // Dialog przypisany do NPC
    public void Interact()
    {
        // Rozpoczêcie dialogu po wejœciu w interakcjê z NPC
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
