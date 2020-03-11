using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Raiding : MonoBehaviour
{
    public Text nametext;
    public Text populationtext;
    public Text difficultytext;


    private int settlementnumber;

    public class settlement //class for a settlement
    {
        public string name;
        public int population;
        public int difficulty;
        public int gold;

        public int number;
    }

    public settlement[] SettlementsArray; //delcare array for settlements info

    public settlement burgville = new settlement();
    public settlement cityville = new settlement();

    void Start()
    {
        SettlementsArray = new settlement[2];

        burgville.name = "Burgville";
        burgville.population = 230;
        burgville.difficulty = 10;
        burgville.gold = 50;
        burgville.number = 1;

        cityville.name = "Cityville";
        cityville.population = 560;
        cityville.difficulty = 30;
        cityville.gold = 1000;
        cityville.number = 2;

        SettlementsArray[0] = burgville;
        SettlementsArray[1] = cityville;
    }


    void Update()
    {
        string townname = EventSystem.current.currentSelectedGameObject.name;
        print(townname);
        int townnumber = Int32.Parse(townname);
        print(townnumber);

        nametext.text = SettlementsArray[townnumber].name.ToString();
        populationtext.text = SettlementsArray[townnumber].population.ToString();
        difficultytext.text = SettlementsArray[townnumber].difficulty.ToString();
    }


    public void townnamegetter()
    {
        string townname = EventSystem.current.currentSelectedGameObject.name;
    }
}
