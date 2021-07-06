using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;

    private void Awake()
    {
        Bird.OnDeath += OnGameOver;
    }

    private void OnDestroy()
    {
        Bird.OnDeath -= OnGameOver;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void OnGameOver() => _playButton.SetActive(true);
}
