using UnityEngine;

public class ToBattleScene : MonoBehaviour
{
    private TriggerDetector triggerDetector;

    private void Awake()
    {
        triggerDetector = gameObject.GetComponent<TriggerDetector>();
    }

    private void Start()
    {
        triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
        {
            SceneFacade.Instance.LoadScene(SceneName.BattleScene);
        });
    }
}