**Projekt 2D RPG w Unity**
Opis projektu
Ten projekt jest stworzony w Unity i napisany w języku C#. Celem jest stworzenie gry 2D RPG, w której gracze będą mogli eksplorować świat, walczyć z potworami oraz rozwijać swoje postacie. Gra zawiera elementy questów, system umiejętności oraz interaktywne środowisko.

Wymagania
Unity 2020.3 lub nowsza
.NET Framework 4.7.1 lub nowszy
Podstawowa znajomość C# i Unity
Struktura projektu
Klasy główne
Player

Reprezentuje postać gracza.
Zawiera metody do poruszania się, ataku, obrony oraz interakcji z obiektami.
Właściwości: zdrowie, mana, poziom, doświadczenie.
Enemy

Reprezentuje przeciwników w grze.
Zawiera logikę sztucznej inteligencji do ataku na gracza.
Właściwości: zdrowie, siła ataku, typ (np. potwór, boss).
Item

Reprezentuje przedmioty w grze (np. broń, zbroje, mikstury).
Właściwości: nazwa, typ, efekty.
Quest

Reprezentuje zadania do wykonania przez gracza.
Zawiera logikę do śledzenia postępu i nagród.
Właściwości: tytuł, opis, status (do wykonania, w trakcie, ukończone).
Inventory

Zarządza przedmiotami posiadanymi przez gracza.
Metody do dodawania, usuwania i przeglądania przedmiotów.
GameManager

Zarządza główną logiką gry, stanem gry, punktami kontrolnymi i przechodzi do różnych scen.
Odpowiada za inicjalizację i resetowanie gry.
Instalacja
Pobierz projekt

Sklonuj repozytorium lub pobierz pliki projektu.
Otwórz w Unity

Uruchom Unity Hub i otwórz projekt.
Zainstaluj zależności

Upewnij się, że wszystkie wymagane pakiety są zainstalowane w Unity (np. system zarządzania interfejsem użytkownika).
Uruchomienie gry
Upewnij się, że wybrana jest odpowiednia scena (np. MainScene).
Kliknij „Play” w edytorze Unity, aby rozpocząć grę.
Dalszy rozwój
Projekt można rozwijać o dodatkowe funkcje, takie jak:

Więcej klas wrogów i przedmiotów.
System ulepszania umiejętności postaci.
Rozbudowane questy z różnymi liniami fabularnymi.
Możliwość rozgrywki wieloosobowej.
