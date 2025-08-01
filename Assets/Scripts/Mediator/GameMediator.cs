//public class GameMediator : AbstractMediator
//{
//    private static GameMediator instance;

//    public static GameMediator Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = new GameMediator();
//            }
//            return instance;
//        }
//    }

//    private GameMediator()
//    {
//        EventCenter.Instance.RegisterEvent(EventType.OnSceneSwitchStart, () =>
//        {
//            //systems.Clear();
//        });
//    }
//}