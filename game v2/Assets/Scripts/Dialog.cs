// Dialog to klasa przechowuj�ca tre�� dialog�w.
// Zawiera list� wierszy dialogowych, kt�re s� wy�wietlane po kolei, gdy gracz wchodzi w interakcj� z NPC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Umo�liwia edycj� obiektu w Inspektorze Unity
public class Dialog
{
    // Lista wierszy dialogowych, ustawiana w edytorze Unity
    [SerializeField] List<string> lines;

    // Publiczna w�a�ciwo�� umo�liwiaj�ca dost�p do listy wierszy
    public List<string> Lines
    {
        get { return lines; }
    }
}
