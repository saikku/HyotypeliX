using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColorGame : MonoBehaviour
{
    //Äänet
    public GameObject Sounds;
    
    //Animaatiotähden GameObject.
    public GameObject AnimationStar;

    //Värit.
    public GameObject Colors;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Yellow;
    
    // Main menu ja peli.
    public GameObject Mainscene;
    public GameObject Game;

    // Napit ja nappien tekstit.
    public GameObject HintButton;

    //Quit nappi.
    public GameObject QuitButton;
    private string CorrectText;

    // Nappien positionit.
    private Vector2 CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
    private Vector2 WrongButtonPosition = new Vector2(540.0f, -260.0f);

    //Tähden script ja Gamemanagerin Gameobject.
    private GameManager StarScript;
    private GameObject ScriptGameObject;

    //Edellinen randomilla generoitu numero.
    private int PrevNumber;

    //Kun aktivoidaan pelin Gameobject.
    void OnEnable()
    {
        //Todo: ääni
        //Sounds.transform.GetChild(6).GetComponent<AudioSource>().Play();

        //Asetetaan napit aktiiviseksi.
        CorrectButtonPosition = new Vector2(-540.0f, -260.0f);
        WrongButtonPosition = new Vector2(540.0f, -260.0f);
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

    //Värien piilottaminen
    private void HideColors()
    {
        Red.SetActive(false);
        Green.SetActive(false);
        Blue.SetActive(false);
        Yellow.SetActive(false);
        Red.transform.tag = "Untagged";
        Green.transform.tag = "Untagged";
        Blue.transform.tag = "Untagged";
        Yellow.transform.tag = "Untagged";
    }


    //Pelin käynnistäminen.
    private void LaunchGame()
    {
        //Random numero yhden ja neljän väliltä.
        int Number = Random.Range(0, 4);

        //Generoidaan uusi numero kunnes yllä oleva numero ei vastaa edellistä arvottua numeroa.
        while (Number == PrevNumber)
        {
            //Debug.Log("GNERATING");
            Number = Random.Range(1, 5);
        }
        Debug.Log("CorrectNumber: " + Number);
        HideColors();

        //Näytetään väri mikä vastaa generoitua numeroa.
        if (Number == 0)
        {
            HideColors();
            Yellow.SetActive(true);
            Yellow.transform.tag = "correct";
            Yellow.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomColor(Number);
            RandomizeButtons();

        }

        if (Number == 1)
        {
            HideColors();
            Green.SetActive(true);
            Green.transform.tag = "correct";
            Green.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomColor(Number);
            RandomizeButtons();
        }

        if (Number == 2)
        {
            HideColors();
            Blue.SetActive(true);
            Blue.transform.tag = "correct";
            Blue.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomColor(Number);
            RandomizeButtons();
        }

        if (Number == 3)
        {
            HideColors();
            Red.SetActive(true);
            Red.transform.tag = "correct";
            Red.transform.localPosition = CorrectButtonPosition;
            CheckPositions();
            GetRandomColor(Number);
            RandomizeButtons();
        }

        //Asetetaan Prevnumberiin randomilla generoitu numero.
        PrevNumber = Number;
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

    private void GetRandomColor(int n)
    {
        int Number = Random.Range(0, 4);
        while (Number == n)
        {

            Number = Random.Range(0, 4);
        }
        Debug.Log("WrongNumber: " + Number);
        Colors.transform.GetChild(Number).gameObject.SetActive(true);
        Colors.transform.GetChild(Number).transform.tag = "wrong";
        Colors.transform.GetChild(Number).transform.localPosition = WrongButtonPosition;
    }

    private void CheckPositions()
    {
        for (int i = 0; i < Colors.transform.childCount; i++)
        {
            if (Colors.transform.GetChild(i).tag == "correct")
            {
                Colors.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }

            if (Colors.transform.GetChild(i).tag == "wrong")
            {
                Colors.transform.GetChild(i).transform.localPosition = WrongButtonPosition;
            }

            else
            {
                Colors.transform.GetChild(i).transform.localPosition = CorrectButtonPosition;
            }
        }
    }
}