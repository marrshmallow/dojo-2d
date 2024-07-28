using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    public enum State
    {
        Idle, Walk, Run, Dance, Warp, Throw
    }

    private State currentState;

    [System.Serializable]
    public class CharacterState
    {
        public string name;
    }

    public void ChangeState(State state)
    {
        currentState = state;

        // エフェクトを変更
        // StartEffect 메소드는 SmokeParticle, SweatParticle, WarpEffect에 있다
        gameObject.BroadcastMessage("StartEffect", state, SendMessageOptions.DontRequireReceiver);

        // Animatorのステート変更
        GetComponent<Animator>().SetTrigger(state.ToString());
    }
}
