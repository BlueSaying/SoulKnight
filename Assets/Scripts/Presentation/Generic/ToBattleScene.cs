
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ToBattleScene : MonoBehaviour
{
    private MemoryModel memoryModel;
    private TriggerDetector triggerDetector;

    private void Awake()
    {
        //memoryModel = ModelContainer.Instance.GetModel<MemoryModel>();
        triggerDetector = gameObject.GetComponent<TriggerDetector>();
    }

    private void Start()
    {
        triggerDetector.AddTriggerListener(TriggerEventType.OnTriggerEnter2D, "Player", (obj) =>
        {
            // 处理场景加载前的逻辑
            //memoryModel.playerStaticAttr = obj.GetComponent<Symbol>().character.model.staticAttr as PlayerStaticAttr;
            //memoryModel.playerDynamicAttr = obj.GetComponent<Symbol>().character.model.dynamicAttr as PlayerDynamicAttr;
            //DontDestroyOnLoad(obj);

            // 加载Battle场景
            //SceneCommand.Instance.LoadScene(SceneName.BattleScene);
        });
    }
}