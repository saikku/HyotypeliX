using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KoalaScripti : MonoBehaviour
{
    //Animaatiotähden GameObject.
    public GameObject AnimationStar;

    //Eläimet
        public GameObject Animals;
        public GameObject Cat;
        public GameObject Cow;
        public GameObject Dog;
        public GameObject Horse;
        public GameObject Sheep;
        public GameObject Pig;
        
    //Äänet
    public GameObject Sounds;

    // Main menu ja peli
    public GameObject Mainscene;
    public GameObject Game;

    public GameObject HintButton1;

    // Quit button
    public GameObject QuitButton;
    private string CorrectText;

    // Nappien positionit
    private Vector2 CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
    private Vector2 WrongButtonPosition = new Vector2(540.0f, -260.0f);

    private float ButtonYPosition = 0;
    private float HintButtonYPosition = 0;
    private float HintButton1XPosition = 0;

    //Tähden script ja Gamemanagerin Gameobject.
    private GameManager StarScript;
    private GameObject ScriptGameObject;

    //Edellinen randomilla generoitu numero.
    private int PrevNumber;

    //Kun aktivoidaan pelin Gameobject.
    void OnEnable()
    {
        //Asetetaan napit aktiiviseksi.
        //Etsitään Games Gameobject ja sen sisältä GameManagerScript.
        ScriptGameObject = GameObject.Find("Games");
        StarScript = ScriptGameObject.GetComponent<GameManager>();
        CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
        WrongButtonPosition = new Vector2(540.0f, -260.0f);
        //Asetetaan tähdet nollaksi.
        StarScript.Stars = 0;
        //Sounds.transform.GetChild(8).GetComponent<AudioSource>().Play();
        //Käynnistetään peli.
        LaunchGame();
    }

    //Kutsutaan joka framella.
    void Update()
    {
        //Checkataan monta tähteä pitää näyttää ruudulla.
        StarScript.CheckStars();
        //Checkataan onko animaatio käynnissä.
        CheckAnimation();        
    }

    //Kun vastataan oikein.
    public void CorrectAnswer(Button button)
    {
        if (button.tag == "correct")
        {
            Debug.Log("Oikein Meni!");
            //Sounds.transform.GetChild(6).GetComponent<AudioSource>().Play();
            //Animaatiotähti asetetaan aktiiviseksi.
            AnimationStar.SetActive(true);

            //Haetaan Animaatiotähden Animation komponentti ja kutsutaan Play metodia.
            AnimationStar.GetComponent<Animation>().Play("StarAnimation");

            //Lisätään yksi tähti.
            StarScript.Stars++;

            //Checkataan monta tähteä pitää näyttää ruudulla.
            StarScript.CheckStars();

            //Jos tähtiä on kertynyt 3 peli päättyy.
            if (StarScript.Stars >= 3)
            {
                Debug.Log("Oikein Meni!");

                //Kutsutaan Win komento sekunnin viiveellä.
                Invoke(("Win"), 1);

            }

            //Muussa tapauksessa kutsutaan LaunchGame 0.6 sekunnin viiveellä.
            else
            {
                Invoke("LaunchGame", 1.2f);
            }
        }
        else
        {
            WrongAnswer();
        }
        
    }

    //TODO: Väärinvastauksen jutut.
    public void WrongAnswer()
    {
        Debug.Log("Väärin Meni!");
    }

    //Nappien paikan randomisointi.
    private void RandomizeButtons()
    {
        //Random numero yhden ja kahden väliltä.
        int RandomButton = Random.Range(0, 2);
        CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
        WrongButtonPosition = new Vector2(540.0f, -260.0f);
        // Jos arvo on yksi Correctbutton ja Wrongbutton ovat omalla paikallaan.
        if (RandomButton == 1)
        {
            CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
            WrongButtonPosition = new Vector2(540.0f, -260.0f);
        }

        // Jos arvo on nolla Correctbutton ja Wrongbutton vaihtaa paikkaa.
        else
        {
            CorrectButtonPosition = new Vector2(540.0f, -260.0f);
            WrongButtonPosition = new Vector2(-540.0f, -260.0f);
        }
    }

    //Eläinten piilottaminen.
    private void HideAnimals()
    {
        Cat.SetActive(false);
        Cow.SetActive(false);
        Dog.SetActive(false);
        Horse.SetActive(false);
        Sheep.SetActive(false);
        Pig.SetActive(false);
        Cat.transform.tag = "Untagged";
        Cow.transform.tag = "Untagged";
        Dog.transform.tag = "Untagged";
        Horse.transform.tag = "Untagged";
        Sheep.transform.tag = "Untagged";
        Pig.transform.tag = "Untagged";

    }

    //Pelin käynnistäminen.
    private void LaunchGame()
    {
        //Generoidaan numero yhden ja viiden väliltä.
        int n = Random.Range(0, 6);
        while (n == PrevNumber)
        {
            n = Random.Range(0, 6);
        }
        
        //Piilotetaan eläimet.
        HideAnimals();

        //Näytetään eläin mikä vastaa generoitua numeroa.
        if (n == 0)
        {
            HideAnimals();
            Cat.SetActive(true);
            Cat.transform.tag = "correct";
            Cat.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
           
        }

        if (n == 1)
        {
            HideAnimals();
            Cow.SetActive(true);
            Cow.transform.tag = "correct";
            Cow.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
        }

        if (n == 2)
        {
            HideAnimals();
            Dog.SetActive(true);
            Dog.transform.tag = "correct";
            Dog.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
        }

        if (n == 3)
        {
            HideAnimals();
            Horse.SetActive(true);
            Horse.transform.tag = "correct";
            Horse.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
        }

        if (n == 4)
        {
            HideAnimals();
            Pig.SetActive(true);
            Pig.transform.tag = "correct";
            Pig.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
        }

        if (n == 5)
        {
            HideAnimals();
            Sheep.SetActive(true);
            Sheep.transform.tag = "correct";
            Sheep.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomAnimal(n);
            RandomizeButtons();
        }
        PrevNumber = n;
    }

    //Voitto metodi.
    private void Win()
    {
        //Sounds.transform.GetChild(7).GetComponent<AudioSource>().Play();

        //Deaktivoidaan peli.
        Game.SetActive(false);

        //Aktivoidaan MainScene.
        Mainscene.SetActive(true);

        //Deaktivoidaan QuitNappi.
        QuitButton.SetActive(false);

    }

    //Checkataan onko animaatio käynnissä.
    private void CheckAnimation()
    {
        //Jos animaatio ei ole käynnissä, deaktivoidaan se.
        if (!AnimationStar.GetComponent<Animation>().isPlaying)
        {
            AnimationStar.SetActive(false);
        }
    }

    private void GetRandomAnimal(int n)
    {
        int Number = Random.Range(0, 6);
        while (Number == n)
        {
            
            Number = Random.Range(0, 6);
        }
        
        Animals.transform.GetChild(Number).gameObject.SetActive(true);
        Animals.transform.GetChild(Number).transform.tag = "wrong";
        Animals.transform.GetChild(Number).transform.localPosition = WrongButtonPosition;
    }

    private void CheckPositions()
    {
        for (int i = 0; i < Animals.transform.childCount; i++)
        {
            if (Animals.transform.GetChild(i).tag == "correct")
            {
                Animals.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }

            if (Animals.transform.GetChild(i).tag == "wrong")
            {
                Animals.transform.GetChild(i).transform.localPosition = WrongButtonPosition;
            }

            else
            {
                Animals.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }
        }
    }
}
