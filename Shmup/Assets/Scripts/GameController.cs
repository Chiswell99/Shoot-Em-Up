using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public delegate void EnemyDied(GameObject corpse);
    public event EnemyDied OnEnemyDied;
    public delegate void ScoreChanged(int updatedScore);
    public event ScoreChanged OnScoreChanged;
    

    [SerializeField] private PlayerController player;
    [HideInInspector] 
    public PlayerController Player
    {
        get { return player; }
    }

    private int _playerScore;
    public int PlayerScore
    {
        get { return _playerScore; }

        private set 
        {
            _playerScore = value;
            if (OnScoreChanged != null)
                OnScoreChanged.Invoke(_playerScore);
        }
    }

    public bool isGamePaused = false;

    private void Awake()
    {
        Instance = this;
    }

    public void OnDie(GameObject deadObject, int score = 0)
    {
        PlayerScore += score;
        
        Debug.LogFormat("GameController: the object {0} has died! Adding score {1}, Total{2}", deadObject.name, score, PlayerScore);

        player.AddToPowerLevel(1);

        if(OnEnemyDied != null)
        {
            OnEnemyDied.Invoke(deadObject);
        }
    }

    public void OnPlayerDie()
    {
        Debug.Log("*********************PLAYER DIED!!!***********************");
    }

    public void OnPickupPickedUp(PickupController pickup)//Game controller le avisa al player que tomo un pickup de cierto tipo.
    {
        PlayerScore += pickup.config.score;
        player.UnlockSpecial(pickup.config);
    }
}
