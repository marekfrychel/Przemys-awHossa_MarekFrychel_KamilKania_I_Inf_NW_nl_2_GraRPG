// NPCController reprezentuje NPC, kt�ry wy�wietla dialog, gdy gracz wejdzie z nim w interakcj�.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog; // Dialog przypisany do NPC
    public void Interact()
    {
        // Rozpocz�cie dialogu po wej�ciu w interakcj� z NPC
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
