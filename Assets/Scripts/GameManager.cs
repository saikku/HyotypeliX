using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //GameObjecteja
    public GameObject SceneToHide;
    public GameObject ShowNumeroGame;
    public GameObject ShowKoalaGame;
    public GameObject ShowColorGame;
    public GameObject ShowAlphabetGame;

    //Quit nappi
    public GameObject QuitButton;

    //Tähti
    private GameObject star;
    bool check;
    Animation anim;

    //Tähtien määrä
    public int Stars = 0;

    //Kun peli käynnistetään.
    void Start()
    {
        //Haetaan tähden GameObject.
        star = GameObject.Find("Stars");

        //Asetetaan tähdet pois näkyvistä.
        star.transform.GetChild(5).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        star.transform.GetChild(6).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        star.transform.GetChild(7).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        star.transform.GetChild(8).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        star.transform.GetChild(9).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }

    //StartGame metodi.
	public void StartGame(int game)
    {
        //Poistetaan Main Menu napit
        SceneToHide.SetActive(false);

        if (game == 1)
        {
            // Käynnistetään Numeropeli
            ShowKoalaGame.SetActive(true);
            QuitButton.SetActive(true);
        }

        if (game == 2)
        {
            // Käynnistetaan Koalapeli
            ShowNumeroGame.SetActive(true);
            QuitButton.SetActive(true);
        }

        if (game == 3)
        {
            // Käynnistetaan Koalapeli
            ShowColorGame.SetActive(true);
            QuitButton.SetActive(true);
        }

        if (game == 4)
        {
            // Käynnistetaan Koalapeli
            ShowAlphabetGame.SetActive(true);
            QuitButton.SetActive(true);
        }

        //Debuggia varten.
        if (game == 5)
        {
            
            for (int i = 0; i <= 200; i++)
            {
                int Number = Random.Range(0, 27);
                Debug.Log(Number);
            }
        }
    }

    void Update()
    {

    }

    // Laittaa Main Menun näkyväksi ja pelit piiloon.
    public void QuitGame()
    {
        Debug.Log("jee");
        SceneToHide.SetActive(true);
        QuitButton.SetActive(false);
        ShowKoalaGame.SetActive(false);
        ShowNumeroGame.SetActive(false);
        ShowAlphabetGame.SetActive(false);
        ShowColorGame.SetActive(false);
    }

    //Tähtien määrän checkaus
    public void CheckStars()
    {
        //Haetaan tähden GameObject.
        GameObject star = GameObject.Find("Stars");

        //Stars muuttujan switch case.
        switch (Stars)
        {
            //Nolla tähteä, kaikki tähdet poissa näkyvistä.
            case 0:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                star.transform.GetChild(7).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                star.transform.GetChild(8).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                star.transform.GetChild(9).GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;
            //Yksi tähti, yksi tähti asetetaan näkyviin.
            case 1:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            //Kaksi tähteä, kaksi tähteä asetetaan näkyviin.
            case 2:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            //Kolme tähteä, kolme tähteä asetetaan näkyviin.
            case 3:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            //Neljä tähteä, neljä tähteä asetetaan näkyviin.
            case 4:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            //Viisi tähteä, viisi tähteä asetetaan näkyviin.
            case 5:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(9).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
            default:
                star.transform.GetChild(5).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(6).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(7).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(8).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                star.transform.GetChild(9).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                break;
        
        }

    }

}
