using UnityEngine;

public class GamePauseFacade : Singleton<GamePauseFacade>
{
    private GamePauseFacade() { }

    public bool IsPaused { get; private set; }

    public void PauseGame()
    {
        if(IsPaused) return;
        IsPaused = true;

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if(!IsPaused) return;
        IsPaused = false;

        Time.timeScale = 1f;
    }
}