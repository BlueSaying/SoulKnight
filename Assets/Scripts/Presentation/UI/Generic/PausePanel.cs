using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : Panel
{
    protected override void Awake()
    {
        base.Awake();

        // 设置头像
        Player player = SystemRepository.Instance.GetSystem<PlayerSystem>().mainPlayer;
        Image icon1 = transform.Find("TopPanel").Find("Head1").Find("Icon").GetComponent<Image>();
        Image icon2 = transform.Find("TopPanel").Find("Head2").Find("Icon").GetComponent<Image>();
        Sprite playerSprite = null;
        if (player != null)
        {
            playerSprite = ResourcesLoader.Instance.LoadSprite(SpriteType.Profile.ToString(), player.ToString());
        }
        icon1.sprite = playerSprite;
        icon1.SetNativeSize();
        icon2.sprite = playerSprite;
        icon2.SetNativeSize();

        UIRenderer.Instance.MovePanelToFront(this);

        UnityTools.GetComponentFromChildren<Button>(gameObject, "BackButton").onClick.AddListener(BackHome);
        UnityTools.GetComponentFromChildren<Button>(gameObject, "ContinueButton").onClick.AddListener(ContinueGame);
        UnityTools.GetComponentFromChildren<Button>(gameObject, "SettingButton").onClick.AddListener(OpenSettingPanel);
    }

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

    #region 事件集
    private void BackHome()
    {
        GamePauseFacade.Instance.ResumeGame();
        SceneFacade.Instance.LoadScene(SceneName.MainMenuScene);
    }

    private void ContinueGame()
    {
        GamePauseFacade.Instance.ResumeGame();
        UIMediator.Instance.ClosePanel(name);
    }

    private void OpenSettingPanel()
    {
        Debug.Log("设置界面");
    }
    #endregion
}