public class GameMediator : AbstractMediator
{
    private static GameMediator _instance;

    public static GameMediator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameMediator();
            }
            return _instance;
        }
    }

    private GameMediator()
    {
        EventCenter.Instance.ReigisterEvent(EventType.OnSceneSwitchStart, true, () =>
        {
            //systems.Clear();
        });
    }
}