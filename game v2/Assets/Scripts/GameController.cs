// GameController to centralny skrypt zarz�dzaj�cy stanem gry, kt�ry okre�la,
// w jakim trybie znajduje si� gra (swobodna eksploracja, dialog lub walka)
// i odpowiednio przekazuje kontrol� do innych skrypt�w, np. do obs�ugi gracza lub dialog�w.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Wyliczenie stan�w gry, aby �atwo kontrolowa�, czy gra jest w trybie eksploracji, dialogu, czy walki
public enum GameState { FreeRoam, Dialog, Battle }

public class GameController : MonoBehaviour
{
    // Odniesienie do komponentu PlayerController, przypisane w edytorze Unity
    [SerializeField] PlayerController playerController;

    // Zmienna przechowuj�ca aktualny stan gry
    GameState state;

    private void Start()
    {
        // Subskrybuj zdarzenia dialogowe, aby wiedzie�, kiedy gra przechodzi w tryb dialogu
        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            // Ustaw stan gry na swobodn� eksploracj� po zako�czeniu dialogu
            state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        // Obs�uguj logik� w zale�no�ci od stanu gry
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
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