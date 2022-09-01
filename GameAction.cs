using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
   public UnityEvent raiseEvent, awakeEvent, destroyEvent, appQuitEvent;
   public UnityAction raiseActionObj;

   public void RaiseAction()
   {
      raiseActionObj?.Invoke(); 
      // Debug.Log("game action raised");
   }

   public void Awake()
   {
      awakeEvent?.Invoke();
   }

   public void OnDestroy()
   {
      destroyEvent?.Invoke();
   }

   public void OnApplicationQuit()
   {
      appQuitEvent?.Invoke();
   }
}
