// DialogManager zarz�dza wy�wietlaniem dialog�w na ekranie.
// Obs�uguje wy�wietlanie tekstu litera po literze oraz zamykanie dialogu po jego zako�czeniu.
// Umo�liwia tak�e nas�uchiwanie na zdarzenia otwierania i zamykania dialogu.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // UI dla dialogu oraz pr�dko�� wy�wietlania liter
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    // Zdarzenie wywo�ywane, gdy dialog jest pokazany lub ukryty
    public event Action OnShowDialog;
    public event Action OnHideDialog;

    // W�a�ciwo�� singletona
    public static DialogManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this; // Ustawienie instancji singletona
    }

    Dialog dialog;
    int currentLine = 0; // Aktualny indeks wiersza dialogu
    bool isTyping; // Sprawdza, czy tekst jest w trakcie pisania
    
    // Wy�wietla dialog; najpierw uruchamia zdarzenie pokazuj�ce dialog
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke(); // Wywo�anie zdarzenia pokazania dialogu

        this.dialog = dialog;
        dialogBox.SetActive(true); // Aktywacja okienka dialogu
        StartCoroutine(TypeDialog(dialog.Lines[0])); // Rozpocz�cie wy�wietlania pierwszego wiersza
    }
    public void HandleUpdate()
    {
        // Sprawdza, czy gracz nacisn�� "Z" i czy nie trwa wpisywanie liter
        if (Input.GetKeyUp(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            // Je�li s� kolejne linie, zaczyna wpisywanie nast�pnej
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false); // Ukrywa okno dialogowe
                currentLine = 0; // Resetuje lini� dialogu
                OnHideDialog?.Invoke(); // Wywo�uje zdarzenie ukrycia dialogu
            }
        }
    }

    // Wy�wietla tekst litera po literze
    public IEnumerator TypeDialog(string line)
    {
        isTyping = true; // Ustawia flag� wpisywania
        dialogText.text = ""; // Resetuje tekst
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond); // Czeka mi�dzy literami
        }
        isTyping = false; // Ko�czy wpisywanie
    }
}
