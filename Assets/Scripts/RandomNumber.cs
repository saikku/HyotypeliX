using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Koala on omena

public class RandomNumber : MonoBehaviour {

    //Animaatiotähdet
    public GameObject AnimationStar;

    // Nappien tekstit.
    public Text CorrectButtonText;
    public Text WrongButtonText;

    // Koala Image.
    public Object Koala;

    // Koalat.
    public Transform KoalaTransform;

    // Gameobjectit.
    public GameObject NumeroPeli;
    public GameObject MainMenu;
    public GameObject CorrectButton;
    public GameObject WrongButton;
    public GameObject Quit;

    private float xPosition = 0;
    private float yPosition = 0;

    // Nappien positionit.
    private float CorrectButtonXPosition = 0;
    private float WrongButtonXPosition = 0;
    private float ButtonYPosition = 0;
    private GameManager script;
    private GameObject test;

    //Kun aktivoidaan pelin GameObject
    void OnEnable()
    {
        test = GameObject.Find("Games");
        script = test.GetComponent<GameManager>();
        //Sounds.transform.GetChild(8).GetComponent<AudioSource>().Play();
        LaunchGame();
    }

    // Oikean napin painallus.
    public void CorrectAnswer(Button button)
    {
        if (button.tag == "correct")
        {
            Debug.Log("Oikein meni!");
            //Sounds.transform.GetChild(6).GetComponent<AudioSource>().Play();

            //Animaatiotähti asetetaan aktiiviseksi.
            AnimationStar.SetActive(true);

            //Haetaan Animaatiotähden Animation komponentti ja kutsutaan Play metodia.
            AnimationStar.GetComponent<Animation>().Play("StarAnimation");

            //Lisätään yksi tähti.
            script.Stars++;

            //Checkataan monta tähteä pitää näyttää ruudulla.
            script.CheckStars();

            if (script.Stars >= 3)
            {
                Debug.Log("Oikein Meni!");

                //Kutsutaan Win komento sekunnin viiveellä.
                Invoke(("Win"), 1);
            }
            else
            {
                DestroyClones();
                LaunchGame();
                script.Stars++;
                script.CheckStars();
            }
        }
        else
        {
            WrongAnswer();
        }
    }

    // Väärän napin painallus.
    public void WrongAnswer()
    {
        //TODO: Jokin tapahtuma jos vastaa väärin.
        Debug.Log("Väärin meni.");
    }

    private void LaunchGame()
    {
        GameObject Original = GameObject.Find("Koala");
        Original.transform.tag = "original";
        // Haetaan Koalan x Position.
        xPosition = KoalaTransform.position.x - 300;
        yPosition = KoalaTransform.position.y;
        // Haetaan Nappien Position.
        CorrectButtonXPosition = CorrectButton.transform.position.x;
        WrongButtonXPosition = WrongButton.transform.position.x;
        ButtonYPosition = CorrectButton.transform.position.y;

        // Luodaan satunnaiset numerot nappeihin.
        int CorrectNumber = Random.Range(1, 4);
        int WrongNumber = Random.Range(1, 4);

        for (int i = 0; i < CorrectNumber; i++)
        {

            // Asetetaan Koalat Gameobjectin childille eli KoalaImagalle position.
            KoalaTransform.GetChild(i).transform.position = new Vector3(xPosition += 300, yPosition);

            // Luodaan kopio KoalaImagesta Koalat objectin alle.
            Instantiate(Koala, KoalaTransform);

            // Annetaan KoalaImage cloneille tag nimeltä "clone".
            KoalaTransform.GetChild(i).transform.tag = "clone";

        }

        // Laitetaan oikea vastaus CorrectNumber nappiin.
        CorrectButtonText.text = CorrectNumber.ToString();

        // Checkataan että nappien teksti ei ole sama.
        if (CorrectNumber == WrongNumber)
        {
            WrongNumber--;
        }

        // Arvotana numero nollan ja yhden välillä.
        int RandomButton = Random.Range(0, 2);

        // Jos arvo on yksi Correctbutton ja Wrongbutton ovat omalla paikallaan.
        if (RandomButton == 1)
        {
            CorrectButton.transform.position = new Vector3(CorrectButtonXPosition, ButtonYPosition, 0);
            WrongButton.transform.position = new Vector3(WrongButtonXPosition, ButtonYPosition, 0);
        }

        // Jos arvo on nolla Correctbutton ja Wrongbutton vaihtaa paikkaa.
        else
        {
            CorrectButton.transform.position = new Vector3(WrongButtonXPosition, ButtonYPosition, 0);
            WrongButton.transform.position = new Vector3(CorrectButtonXPosition, ButtonYPosition, 0);
        }

        // Asetetaan myös Väärälle napille teksti
        WrongButtonText.text = WrongNumber.ToString();
    }

    void DestroyClones()
    {
        // Etsitään alkuperäinen KoalaImage.
        GameObject Original = GameObject.Find("Koala");

        // Asetetaan sille original tag.
        Original.transform.tag = "original";

        // Etsitään clonet (Joskus aikaisempi for loop ei aseta kaikille clone tagia).
        GameObject Clone = GameObject.Find("Koala(Clone)");

        // Asetetaan niille clone tag.
        Clone.transform.tag = "clone";

        // Taulukko johon sijoitetaan kaikki objectit joilla on tag "clone".
        GameObject[] destroyClones;
        destroyClones = GameObject.FindGameObjectsWithTag("clone");

        for (int i = 0; i < destroyClones.Length; i++)
        {
            // Tuhotaan clonet.
            Destroy(destroyClones[i].gameObject);
        }
    }
}
