using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _gameOverScreen;

    private Scene _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
        _gameOverScreen.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.Died += ShowScreen;
    }

    private void OnDisable()
    {
        _player.Died -= ShowScreen;
    }

    private void ShowScreen()
    {
        _gameOverScreen.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_currentScene.name);
    }
}
