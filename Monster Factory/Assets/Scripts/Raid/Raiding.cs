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

    public int strength = 50; //PLACEHOLDER, WILL BE CHANGED LATER TO ADD ABILITY TO INCREASE THIS

    public class settlement //class for a settlement
    {
        public string name;
        public int population;
        public int difficulty;
        public int gold;

        public int number;
    }

    public settlement[] SettlementsArray; //delcare array for settlements info

    public settlement burgville = new settlement(); //adding the settlement objects
    public settlement cityville = new settlement();

    void Start()
    {
        SettlementsArray = new settlement[2]; //setting the size of the array

        burgville.name = "Burgville";
        burgville.population = 230;
        burgville.difficulty = 10;
        burgville.gold = 50;
        burgville.number = 1;

        cityville.name = "Cityville";   //adding values to the settlements
        cityville.population = 560;
        cityville.difficulty = 30;
        cityville.gold = 1000;
        cityville.number = 2;

        SettlementsArray[0] = burgville;
        SettlementsArray[1] = cityville;  //setting the settlements into the array
    }


    void Update()
    {
        string townname = EventSystem.current.currentSelectedGameObject.name;  //gets the name of the settlemennt that has been clicked on and puts it into a string
        int townnumber = Int32.Parse(townname);  //turns the string name into an int so the script knows which one has been clicked on

        nametext.text = SettlementsArray[townnumber].name.ToString();
        populationtext.text = SettlementsArray[townnumber].population.ToString();   //print text to the popup box
        difficultytext.text = SettlementsArray[townnumber].difficulty.ToString();
    }


    public void townnamegetter()
    {
        string townname = EventSystem.current.currentSelectedGameObject.name;   //runs when the button is clicked to find out which one was clicked
    }

    public void beginraid()  //when raid is clicked
    {

    }
}
