using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartgameButton : MonoBehaviour
{
    public GameObject TipPanel;
    public GameObject TitlePanel;
    public AudioSource Click;
    public bool gamestarted;

    public void _StartButtonOnClick()
    {
        Click.Play();
        gamestarted = true;
        TipPanel.SetActive(false);
    }

    public void _CloseTitleOnClick()
    {
        Click.Play();
        TitlePanel.SetActive(false);
    }

    public void _ReplayButtonOnClick()
    {
        Click.Play();
        SceneManager.LoadScene("GameScene");
    }
}
