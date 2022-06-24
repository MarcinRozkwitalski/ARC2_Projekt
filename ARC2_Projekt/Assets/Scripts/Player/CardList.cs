using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardList : MonoBehaviour
{
    [System.Serializable]
    public class Cards
    {
        public int id;
        public string card_description;
        public string card_name;
        public string card_type;
        public string card_subtype;
        public int points;
        public int health_points;
        public int price;
        public bool is_equipped;
        public bool bought;

        public Cards(int newId, string new_card_description, string new_card_name, string new_card_type, string new_card_subtype, int new_points, int new_health_points, int new_price, bool new_is_equipped, bool new_bought)
        {
            id = newId;
            card_description = new_card_description;
            card_name = new_card_name;
            card_type = new_card_type;
            card_subtype = new_card_subtype;
            points = new_points;
            health_points = new_health_points;
            price = new_price;
            is_equipped = new_is_equipped;
            bought = new_bought;
        }
    }

    public List<Cards> cardsList = new List<Cards>();

    private void Awake() 
    {
        var cardLists = FindObjectsOfType<CardList>();
        if(cardLists.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        cardsList.Add(new CardList.Cards(1, "Postac w ogromnym szale zaczyna ryczec na przeciwnika.", "Bestialski ryk", 
                                            "Atak", "Atak", 
                                            2, 1, 70, 
                                            true, true));
        cardsList.Add(new CardList.Cards(2, "Postac wymierza sprawiedliwosc przeciwnikowi przez uderzenie otwarta dlonia.", "Spadajacy lisc", 
                                            "Atak", "Atak", 
                                            4, 2, 120, 
                                            true, true));
        cardsList.Add(new CardList.Cards(3, "Postac obzera sie kanapkami zwiekszajac swoja mase tluszczowa.", "Grubo skorny", 
                                            "Obrona", "Obrona", 
                                            3, 1, 80, 
                                            true, true));
        cardsList.Add(new CardList.Cards(4, "Postac wyciaga krolika z kapelusza, ktory zaslania nasza postac przed obrazeniami.", "Znikajacy krolik",
                                            "Obrona", "Obrona", 
                                            1, 0, 50, 
                                            false, false));
        cardsList.Add(new CardList.Cards(5, "Postac na slepo zaczyna rzucac kamieniami w przeciwnikow.", "Slepy traf", 
                                            "Atak", "Atak", 
                                            2, 0, 150, 
                                            false, false));
        cardsList.Add(new CardList.Cards(6, "Postac przylepia do siebie platy miodu.", "Miodzio zbroja", 
                                            "Obrona", "Obrona", 
                                            8, 3, 130, 
                                            false, false));
        cardsList.Add(new CardList.Cards(7, "Postac pije ostry sos po czym zaczyna ziac ogniem.", "Palace gardlo", 
                                            "Atak", "Atak", 
                                            6, 3, 200, 
                                            false, false));
        cardsList.Add(new CardList.Cards(8, "Postac dziabie palcem przeciwnika w oko (o ile je ma).", "Paluszek", 
                                            "Atak", "Atak", 
                                            4, 3, 80, 
                                            false, false));
        cardsList.Add(new CardList.Cards(9, "Postac ubiera zolta bluze, ktora dodaje klasy jak i punkty obrony.", "Slynna bluza", 
                                            "Obrona", "Obrona", 
                                            10, 4, 180, 
                                            false, false));
        cardsList.Add(new CardList.Cards(10, "Postac przyczepia do siebie banany za pomoca tasmy klejacej.", "Banan na droge", 
                                            "Obrona", "Obrona", 
                                            6, 2, 140, 
                                            false, false));
        cardsList.Add(new CardList.Cards(11, "Postac powtarza co chwile slowo \"Azaliz\" rzucajac przy tym czar niszczacy psychike przeciwnika.", "Azaliz", 
                                            "Atak", "Atak", 
                                            8, 4, 250, 
                                            false, false));
        cardsList.Add(new CardList.Cards(12, "Postac wypluwa z ust ogromna ilosc wody, ktora zalewa przeciwnika.", "Lanie wody", 
                                            "Atak", "Atak", 
                                            5, 3, 150, 
                                            false, false));
        cardsList.Add(new CardList.Cards(13, "Postac depcze swoje okulary i zaklada nowe.", "Nowe okulary", 
                                            "Obrona", "Obrona", 
                                            13, 5, 250, 
                                            false, false));
        cardsList.Add(new CardList.Cards(14, "Postac oslepia wroga swym spojrzeniem zabierajac mu jeden ruch w jego turze.", "Blyszczace oko", 
                                            "Specjalna", "Ogluszenie", 
                                            0, 4, 70, 
                                            false, false));
        cardsList.Add(new CardList.Cards(15, "Postac je drugie sniadanie i sie leczy.", "A co ze sniadaniem?", 
                                            "Specjalna", "Leczenie", 
                                            10, 0, 120, 
                                            false, false));
        cardsList.Add(new CardList.Cards(16, "Postac oblewa przeciwnika zepsutym budyniem i zmniejsza mu atak procentowo.", "Poranny deser", 
                                            "Specjalna", "Oslabienie", 
                                            25, 5, 140, 
                                            false, false));
        cardsList.Add(new CardList.Cards(17, "Postac otrzymuje darmowy ruch w tej turze.", "Robic robic", 
                                            "Specjalna", "Pospiech", 
                                            0, 3, 40, 
                                            false, false));
        cardsList.Add(new CardList.Cards(18, "Obrona jest przetrzymywana do nastepnej tury.", "Mocny klej", 
                                            "Specjalna", "Wytrwalosc", 
                                            0, 2, 70, 
                                            false, false));
        cardsList.Add(new CardList.Cards(19, "Dodanie punktow do nastepnej zagranej karty (nie zuzywa ruchu).", "Mocniej sie nie da?", 
                                            "Specjalna", "Ulepszenie", 
                                            6, 3, 150, 
                                            false, false));
        cardsList.Add(new CardList.Cards(20, "Losowy efekt, gdzie atakujemy lub dodajemy obrone, badz leczymy sie za darmo.", "Czy to wybawienie?", 
                                            "Specjalna", "Tecza", 
                                            20, 5, 400, 
                                            false, false));
        cardsList.Add(new CardList.Cards(21, "Podwojenie obecnej ilosci obrony (nie zuzywa ruchu).", "Zelazne boki", 
                                            "Specjalna", "Wzmocnienie", 
                                            2, 4, 200, 
                                            false, false));
    }
}