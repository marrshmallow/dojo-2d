using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

// 상황별 환경광을 변화시켜주는 스크립트
public class LightController : MonoBehaviour
{
    [SerializeField] Light2D globalLight;
    [SerializeField] GameObject dayLight;
    [SerializeField] GameObject nightLight;
    [SerializeField] GameObject discoLight;

    public enum State
    {
        Off, Daytime, Night, Disco
    }

    void Start()
    {
        ChangeState(State.Off);
    }
    
    // !!!! 업데이트에 해놓는 게 없다...

    public void ChangeState(State state)
    {
        switch (state)
        {
            case State.Off:
                AllLightInactive();
                SetGlobalLight(1.0f, Color.white);
                break;
            case State.Daytime:
                AllLightInactive();
                SetGlobalLight(0.8f, Color.white);
                dayLight.SetActive(true);
                break;
            case State.Night:
                AllLightInactive();
                SetGlobalLight(0.3f, new Color(0, 0.6f, 1.0f, 1.0f));
                nightLight.SetActive(true);
                break;
            case State.Disco:
                AllLightInactive();
                SetGlobalLight(0.2f, new Color(0, 0.6f, 1.0f, 1.0f));
                discoLight.SetActive(true);
                break;
        }
    }

    private void SetGlobalLight(float val, Color col)
    {
        globalLight.intensity = val;
        globalLight.color = col;
    }

    public void AllLightInactive()
    {
        dayLight.SetActive(false);
        nightLight.SetActive(false);
        discoLight.SetActive(false);
    }
}
