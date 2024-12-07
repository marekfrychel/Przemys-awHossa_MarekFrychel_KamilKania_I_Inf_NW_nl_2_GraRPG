using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wyliczenie stanów gry, aby ³atwo kontrolowaæ, czy gra jest w trybie eksploracji, dialogu, czy walki
public enum GameState { FreeRoam, Dialog, Battle }

public class GameController : MonoBehaviour
{
    // Odniesienie do komponentu PlayerController, przypisane w edytorze Unity
    [SerializeField] PlayerController playerController;

    // Zmienna przechowuj¹ca aktualny stan gry
    GameState state;

    private void Start()
    {
        // Subskrybuj zdarzenia dialogowe, aby wiedzieæ, kiedy gra przechodzi w tryb dialogu
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            // Ustaw stan gry na swobodn¹ eksploracjê po zakoñczeniu dialogu
            state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        // Obs³uguj logikê w zale¿noœci od stanu gry
        if (state == GameState.FreeRoam)
        {
            // W trybie swobodnej eksploracji, Update() z PlayerController bêdzie obs³ugiwaæ ruch gracza
        }
        else if (state == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            // Logika walki (do zaimplementowania)
        }
    }
}
