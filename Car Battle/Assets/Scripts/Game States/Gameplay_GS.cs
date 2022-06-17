public class Gameplay_GS : Base_GS
{
    public override void OnStateStarted(GameManager manager)
    {
        CarManager.instance.GameStarted();
        
        UIHandler.Open(UIHandler.instance.canvasInGameUI);

        CameraMovement.instance.target = CarManager.instance.myCar;
        CameraMovement.instance.AssignCameraAim();
    }

    public override void OnStateUpdate(GameManager manager)
    {
        CarManager.instance.HandleCar();
        CameraMovement.instance.CameraUpdate();
    }

    public override void ChangeState(GameManager manager)
    {
        manager.gsCurrent = manager.gsGameover;
        manager.gsCurrent.OnStateStarted(manager);
    }
}
