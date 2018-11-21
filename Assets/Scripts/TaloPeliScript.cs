using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaloPeliScript : MonoBehaviour {

    public GameObject SceneToHide;
    public GameObject ShowNumeroGame;
    public GameObject ShowKoalaGame;
    public GameObject QuitButton;

	public void StartGame()
    {
        // Arvotaan numero nollan ja yhden välillä.
        int rand = 0;//Random.Range(0, 2);
        //Poistetaan Main Menu napit
        SceneToHide.SetActive(false);

        if (rand == 1)
        {
            // Käynnistetään Numeropeli
            ShowNumeroGame.SetActive(true);
            QuitButton.SetActive(true);
        }
        else
        {
            // Käynnistetaan Koalapeli
            ShowKoalaGame.SetActive(true);
            QuitButton.SetActive(true);
        }
    }

    // Laittaa Main Menun näkyväksi ja pelit piiloon.
    public void QuitGame()
    {
        SceneToHide.SetActive(true);
        QuitButton.SetActive(false);
        ShowKoalaGame.SetActive(false);
        ShowNumeroGame.SetActive(false);
    }
}
