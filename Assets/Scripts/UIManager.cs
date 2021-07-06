using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _score;

    private void Awake()
    {
        Bird.OnDeath += OnGameOver;
        Bird.OnScore += OnScore;
    }

    private void OnDestroy()
    {
        Bird.OnDeath -= OnGameOver;
        Bird.OnScore -= OnScore;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void OnGameOver() => _playButton.SetActive(true);

    private void OnScore() => _score.text = (int.Parse(_score.text) + 1).ToString();
}
