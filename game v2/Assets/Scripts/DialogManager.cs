// DialogManager zarz¹dza wyœwietlaniem dialogów na ekranie.
// Obs³uguje wyœwietlanie tekstu litera po literze oraz zamykanie dialogu po jego zakoñczeniu.
// Umo¿liwia tak¿e nas³uchiwanie na zdarzenia otwierania i zamykania dialogu.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // UI dla dialogu oraz prêdkoœæ wyœwietlania liter
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    // Zdarzenie wywo³ywane, gdy dialog jest pokazany lub ukryty
    public event Action OnShowDialog;
    public event Action OnHideDialog;

    // W³aœciwoœæ singletona
    public static DialogManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this; // Ustawienie instancji singletona
    }

    Dialog dialog;
    int currentLine = 0; // Aktualny indeks wiersza dialogu
    bool isTyping; // Sprawdza, czy tekst jest w trakcie pisania
    
    // Wyœwietla dialog; najpierw uruchamia zdarzenie pokazuj¹ce dialog
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke(); // Wywo³anie zdarzenia pokazania dialogu

        this.dialog = dialog;
        dialogBox.SetActive(true); // Aktywacja okienka dialogu
        StartCoroutine(TypeDialog(dialog.Lines[0])); // Rozpoczêcie wyœwietlania pierwszego wiersza
    }
    public void HandleUpdate()
    {
        // Sprawdza, czy gracz nacisn¹³ "Z" i czy nie trwa wpisywanie liter
        if (Input.GetKeyUp(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            // Jeœli s¹ kolejne linie, zaczyna wpisywanie nastêpnej
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false); // Ukrywa okno dialogowe
                currentLine = 0; // Resetuje liniê dialogu
                OnHideDialog?.Invoke(); // Wywo³uje zdarzenie ukrycia dialogu
            }
        }
    }

    // Wyœwietla tekst litera po literze
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true; // Ustawia flagê wpisywania
        dialogText.text = ""; // Resetuje tekst
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond); // Czeka miêdzy literami
        }
        isTyping = false; // Koñczy wpisywanie
    }
}
