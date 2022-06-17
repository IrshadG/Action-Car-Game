using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public GameObject panelHome;
    public GameObject panelCarSelection;
    public GameObject canvasMenu;
    public GameObject canvasInGameUI;
    public GameObject canvasGameOver;

    public TMP_Text gameOverCaption;

    //Singleton
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public static void Close(GameObject obj)
    {
        obj.SetActive(false);
    }

    public static void Open(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void Victory()
    {
        gameOverCaption.text = "You Win!!";
    }
}
