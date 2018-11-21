using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlphabetGame : MonoBehaviour {
    //Aakkosten GameObject
    public Transform AlphabetsObject;

    //Animaatiotähden GameObject.
    public GameObject AnimationStar;

    // Napit ja nappien tekstit.
    public GameObject HintButton;

    // Main menu ja peli.
    public GameObject Game;
    public GameObject Mainscene;

    //Quit nappi. 
    public GameObject QuitButton;

    // Nappien positionit.
    private Vector2 CorrectButtonPosition = new Vector2(-200.0f, -80.0f);
    private Vector2 WrongButtonPosition = new Vector2(200.0f, -80.0f);

    //Tähden script ja Gamemanagerin Gameobject.
    private GameManager StarScript;
    private GameObject ScriptGameObject;

    //Edellinen randomilla generoitu numero.
    private int PrevNumber;

    //Kun aktivoidaan pelin Gameobject.
    void OnEnable()
    {
        //Laitetaan napit oikeille paikoille
        CorrectButtonPosition = new Vector2(-200.0f, -80.0f);
        WrongButtonPosition = new Vector2(200.0f, -80.0f);

        //Etsitään Games Gameobject ja sen sisältä GameManagerScript.
        ScriptGameObject = GameObject.Find("Games");
        StarScript = ScriptGameObject.GetComponent<GameManager>();

        //Asetetaan tähdet nollaksi.
        StarScript.Stars = 0;

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
        //Jos Painetun napin tag on correct
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
        int RandomButton = Random.Range(0, 2);
        Debug.Log("RandomizeNumber: " + RandomButton);
        CorrectButtonPosition = new Vector2(-200.0f, -80.0f);
        WrongButtonPosition = new Vector2(200.0f, -80.0f);
        // Jos arvo on yksi Correctbutton ja Wrongbutton ovat omalla paikallaan.
        if (RandomButton == 1)
        {
            CorrectButtonPosition = new Vector2(-200.0f, -80.0f);
            WrongButtonPosition = new Vector2(200.0f, -80.0f);
        }

        // Jos arvo on nolla Correctbutton ja Wrongbutton vaihtaa paikkaa.
        else
        {
            CorrectButtonPosition = new Vector2(200.0f, -80.0f);
            WrongButtonPosition = new Vector2(-200.0f, -80.0f);
        }
    }

    //Pelin käynnistäminen.
    private void LaunchGame()
    {
        //Käydään läpi Aakkosten gameobject ja deaktivoidaan kaikki.
        for (int i = 0; i < AlphabetsObject.childCount; i++)
        {
            AlphabetsObject.GetChild(i).gameObject.SetActive(false);
        }

        //Tehdään aakkosista lista.
        List<string> alphabets = new List<string>();
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        alphabets.AddRange(alphabet);

        //Arvotaan oikean vastauksen numero.
        int randomNumber = Random.Range(0, 27);

        //Arvotaan uusi numero kunnes yllä oleva numero ei vastaa edellistä arvottua numeroa.
        while (randomNumber == PrevNumber)
        {
            randomNumber = Random.Range(0, 27);
        }

        //Käydään läpi Aakkosten lista.
        for (int i = 0; i < alphabets.Count; ++i)
        {

            //Katsotaan random numeron kohdalla oleva Aakkojen ja haetaan Aakkosten objectista sama aakkonen.
            if (alphabets[randomNumber] == AlphabetsObject.GetChild(i).name)
            {
                //Asetetaan se aktiiviseksi, annetaan sille tag "correct" ja laitetaan se CorrectButtonPositionin kohdalle.
                AlphabetsObject.GetChild(i).gameObject.SetActive(true);
                AlphabetsObject.GetChild(i).transform.tag = "correct";
                AlphabetsObject.GetChild(i).localPosition = CorrectButtonPosition;
                
                //Checkataan oikeat positionit.
                CheckPositions();

                //Haetaan random kirjain.
                GetRandomAlphabet(randomNumber);

                //Randomisoidaan nappien paikat.
                RandomizeButtons();

            }
        }
        //Asetetaan Prevnumberiin aiemmin arvottu numero.
        PrevNumber = randomNumber;
    }

    //Voitto metodi.
    private void Win()
    {
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
    
    private void CheckPositions()
    {
        //Käydään läpi Aakkosten objekti ja katsotaan kirjaimet joilla on tag correct ja wrong.
        for (int i = 0; i < AlphabetsObject.transform.childCount; i++)
        {
            if (AlphabetsObject.transform.GetChild(i).tag == "correct")
            {
                //Asetetaan Correct tagin alla oleva kirjain oikealle paikalle.
                AlphabetsObject.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }

            if (AlphabetsObject.transform.GetChild(i).tag == "wrong")
            {
                //Asetetaan Wrong tagin alla oleva kirjain oikealle paikalle.
                AlphabetsObject.transform.GetChild(i).transform.localPosition = WrongButtonPosition;
            }

            else
            {
                //Jos jostain syystä tageja ei löydy asetetaan se CorrectPositionin paikalle.
                AlphabetsObject.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }
        }
    }

    private void GetRandomAlphabet(int n)
    {
        int Number = Random.Range(0, 27);

        //Katsotaan että numero ei vastaa LaunchGame:n sisällä arvottua numeroa.
        while (Number == n)
        {
            Number = Random.Range(0, 27);
        }

        //Tehdään aakkosista lista.
        List<string> alphabets = new List<string>();
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        alphabets.AddRange(alphabet);

        //Käydään läpi Aakkosten lista.
        for (int i = 0; i < alphabets.Count; ++i)
        {
            //Katsotaan arvotun numeron kohdalla oleva Aakkojen ja haetaan Aakkosten objectista sama aakkonen.
            if (alphabets[Number] == AlphabetsObject.GetChild(i).name)
            {
                //Asetetaan väärä vastaus aktiiviseksi ja annetaan sille tag "wrong"
                AlphabetsObject.GetChild(i).gameObject.SetActive(true);
                AlphabetsObject.GetChild(i).transform.tag = "wrong";
                AlphabetsObject.GetChild(i).localPosition = WrongButtonPosition;
            }
        }
    }
}
