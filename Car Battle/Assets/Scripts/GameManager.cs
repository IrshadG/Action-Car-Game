using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float input = 0f;                                //Value of input taken from the user

    public Base_GS gsCurrent;                               //The current state that game is in
    public Home_GS gsHome = new Home_GS();                  //Home state where user interacts with UI elements
    public Gameplay_GS gsGameplay = new Gameplay_GS();      //State where the user is playing the game itself
    public Gameover_GS gsGameover = new Gameover_GS();      //State of game after user wins or loses the game

    // Start is called before the first frame update
    void Start()
    {
        gsCurrent = gsHome;
        gsCurrent.OnStateStarted(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Updates current Gamestate function every frame
        gsCurrent.OnStateUpdate(this);
    }

    //On start button pressed
    public void OnChangeState()
    {
        gsCurrent.ChangeState(this);
    }

    //Debugging purposes only
    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);      //Current scene
    }
}
