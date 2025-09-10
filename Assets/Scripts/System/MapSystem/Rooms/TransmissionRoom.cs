using UnityEngine;

public class TransmissionRoom : Room
{
    public TransmissionRoom(LevelType levelType, RoomType roomType, BoundsInt bounds, GameObject gameObject)
        : base(levelType, roomType, bounds, gameObject)
    {
        UnityTools.GetComponentFromChildren<TriggerDetector>(gameObject, "Transmission")
            .AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
            {
                SceneFacade.Instance.LoadScene(SceneName.MainMenuScene);
            });
    }
}