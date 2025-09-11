using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : Panel
{
    private Toggle InfFireOn;
    private Toggle FreeRevive;

    protected override void DOOpenPanel()
    {
        base.DOOpenPanel();
        (transform as RectTransform).DOAnchorPosY(-1000, 0.5f).From().SetUpdate(true);
    }

    protected override void DOClosePanel()
    {
        base.DOClosePanel();
        (transform as RectTransform).DOAnchorPosY(-1000, 0.5f).OnComplete(DestroyPanel).OnKill(DestroyPanel);
    }

    protected override void Awake()
    {
        base.Awake();

        Transform bottomPanel = transform.Find("BottomPanel");
        InfFireOn = bottomPanel.Find("InfFireOn").GetComponent<Toggle>();
        FreeRevive = bottomPanel.Find("FreeRevive").GetComponent<Toggle>();

        InfFireOn.isOn= TestManager.InfFireOn;
        FreeRevive.isOn = TestManager.FreeRevive;

        // 按钮绑定
        UnityTools.GetComponentFromChildren<Button>(gameObject, "Close").onClick.AddListener(() => { UIMediator.Instance.ClosePanel(name); });
        InfFireOn.onValueChanged.AddListener((isOn) => { TestManager.InfFireOn = isOn; });
        FreeRevive.onValueChanged.AddListener((isOn) => { TestManager.FreeRevive = isOn; });
    }

    public override void OpenPanel(string panelName)
    {
        base.OpenPanel(panelName);

        // 暂停游戏
        GamePauseFacade.Instance.PauseGame();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        GamePauseFacade.Instance.ResumeGame();
    }
}