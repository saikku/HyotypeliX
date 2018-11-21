using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayOnClick : MonoBehaviour
{
    public AudioClip clip;
    SoundManager soundMgr;
    void Start()
    {
        soundMgr = SoundManager.instance;
    }

    public void Play()
    {
        soundMgr.PlaySingle(clip);  
    }

}
