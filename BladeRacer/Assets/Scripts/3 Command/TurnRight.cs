public class TurnRight : Command
{
    private BikeController _bikeController;

    public TurnRight(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    public override void Execute()
    {
        _bikeController.Turn(Direction.Right);
    }
}
