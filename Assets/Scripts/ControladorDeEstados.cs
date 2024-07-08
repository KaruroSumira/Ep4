using UnityEngine;

public enum GameState
{
    Jugando,
    Pausado
}

public class GameManager : MonoBehaviour
{
    public GameState currentState;

    void Start()
    {
        currentState = GameState.Jugando;
        EnterState(currentState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Jugando)
            {
                ChangeState(GameState.Pausado);
            }
            else if (currentState == GameState.Pausado)
            {
                ChangeState(GameState.Jugando);
            }
        }
    }

    void ChangeState(GameState newState)
    {
        currentState = newState;
        EnterState(currentState);
    }

    void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.Jugando:
                Time.timeScale = 1f;
                Debug.Log("Juego reanudado");
                break;
            case GameState.Pausado:
                Time.timeScale = 0f;
                Debug.Log("Juego pausado");
                break;
        }
    }
}
