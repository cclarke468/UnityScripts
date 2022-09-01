
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    //listener for the game action
    public GameAction gameActionObj;
    public UnityEvent respondEvent;

    private void Respond()
    {
        respondEvent.Invoke();
    }

    private void Awake()
    {
        gameActionObj.raiseActionObj += Respond;
    }
    
}
