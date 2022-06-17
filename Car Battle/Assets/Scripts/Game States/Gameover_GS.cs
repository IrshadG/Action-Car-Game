public class Gameover_GS : Base_GS
{
    public override void OnStateStarted(GameManager manager)
    {
        manager.LogMessage("Gameover...");

        UIHandler.Close(UIHandler.instance.canvasInGameUI);
        UIHandler.Open(UIHandler.instance.canvasGameOver);

        if(CarManager.instance.numberOfTurrets == 0)
            UIHandler.instance.Victory();
    }

    public override void ChangeState(GameManager manager)
    {

    }
}
