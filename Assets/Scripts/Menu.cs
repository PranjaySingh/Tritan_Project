using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject infoPanel;

    private void Start()
    {
        infoPanel.SetActive(false);
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void InfoBtn()
    {
        infoPanel.SetActive(true);
    }

    public void BackBtn()
    {
        infoPanel.SetActive(false);
    }
}
