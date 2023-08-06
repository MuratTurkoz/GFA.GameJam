using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public event Action<int> SteelChanged;
    public event Action<int> PaperChanged;
    public event Action<int> PlasticChanged;
    public event Action<int> GoldChanged;
    public event Action<int> LevelChanged;
    public event Action GameStarted;
    public event Action GameEnded;
    public event Action Won;
    public event Action Lost;
    


    public bool IsGameStarted { get; private set; }

    public void StartGame()
    {
        IsGameStarted = true;
        GameStarted?.Invoke();
    }

    public void EndGame()
    {
        IsGameStarted = false;
        GameEnded?.Invoke();
    }

    /*
	 get 
	 {
		return _gold;
	 }
	 */
    private int _gold;
    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            GoldChanged?.Invoke(_gold);
        }
    }
    private int _steel;
    public int Steel
    {
        get => _steel;
        set
        {
            _steel = value;
            SteelChanged?.Invoke(_steel);
        }
    }
    private int _paper;
    public int Paper
    {
        get => _paper;
        set
        {
            _paper = value;
            PaperChanged?.Invoke(_paper);
        }
    }
    private int _plastic;
    public int Plastic
    {
        get => _plastic;
        set
        {
            _plastic = value;
            PlasticChanged?.Invoke(_plastic);
        }
    }

    public float GoldMultiplier { get; set; } = 1;

    // public int Gold { get; set; }
    private int _level;
    public int Level
    {
        get => _level;
        set
        {
            _level = value;
            LevelChanged?.Invoke(_level);
        }
    }
    private bool _lost=false;
    public bool Lose
    {
        get => _lost;
        set
        {
            _lost = value;
            Lost?.Invoke();
        }
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Level++;

        EndGame();

        Won?.Invoke();
    }

    public void PlayerLose()
    {
        // TODO Show lose screen
        _lost = true;

        EndGame();

        Lost?.Invoke();
    }


}
