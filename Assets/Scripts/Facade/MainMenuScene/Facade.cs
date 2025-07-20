namespace MainMenuScene
{
    public class Facade : AbstractFacade
    {
        private UISystem _uiController;
        protected override void OnInit()
        {
            base.OnInit();
            _uiController = new UISystem();
            GameMediator.Instance.RegisterSystem(_uiController);
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();
            _uiController.GameUpdate();
        }
    }
}
