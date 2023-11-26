using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _mainScreen;
    [SerializeField] private CanvasGroup _score;

   private void Start()
    {
        Time.timeScale = 0;
        _score.gameObject.SetActive(false);
    }

    public void Play()
    {
        Time.timeScale = 1;
        _player.Restart();
        _mainScreen.gameObject.SetActive(false);
        _score.gameObject.SetActive(true);
    }
}
