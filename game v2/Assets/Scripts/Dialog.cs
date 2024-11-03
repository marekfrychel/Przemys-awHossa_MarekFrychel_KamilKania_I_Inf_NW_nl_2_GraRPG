// Dialog to klasa przechowuj¹ca treœæ dialogów.
// Zawiera listê wierszy dialogowych, które s¹ wyœwietlane po kolei, gdy gracz wchodzi w interakcjê z NPC.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Umo¿liwia edycjê obiektu w Inspektorze Unity
public class Dialog
{
    // Lista wierszy dialogowych, ustawiana w edytorze Unity
    [SerializeField] List<string> lines;

    // Publiczna w³aœciwoœæ umo¿liwiaj¹ca dostêp do listy wierszy
    public List<string> Lines
    {
        get { return lines; }
    }
}
