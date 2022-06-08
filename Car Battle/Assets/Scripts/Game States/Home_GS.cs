
public class Home_GS : Base_GS
{
    public override void OnStateStarted(GameManager manager)
    {
        manager.LogMessage("Home GameState started");
    }

    public override void OnStateChanged(GameManager manager)
    {
        UIHandler.instance.canvasMenu.SetActive(false);
        manager.gsCurrent = manager.gsGameplay;
        manager.gsCurrent.OnStateStarted(manager);
    }
}
