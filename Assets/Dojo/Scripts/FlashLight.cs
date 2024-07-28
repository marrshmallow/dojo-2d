using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class FlashLight : MonoBehaviour
{
    Light2D light2D;
    float duration = 0.06f;
    float time = 0;

    void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    void OnEnable()
    {
        StartCoroutine(PlayAnimation());
    }

    void OnDisable()
    {
        time = 0;
        StopCoroutine(PlayAnimation());
    }

    // 점멸하는 플래시 라이트
    IEnumerator PlayAnimation()
    {
        while (time < duration)
        {
            time += Time.deltaTime;
            light2D.enabled = true;
            SetFlashLight();

            yield return null; // while 루프가 한 프레임 동안 무한대로 반복되지 않게 하기 위한 장치
        }

        light2D.enabled = false;
        yield return new WaitForSeconds(Random.Range(0, 0.3f));

        //もう一つのコルーチンを実行する
        time = 0;
        StartCoroutine(PlayAnimation());
    }

    // 위치와 색상을 랜덤하게 바꿔줌
    void SetFlashLight()
    {
        light2D.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        transform.localPosition = new Vector3(Random.Range(-2, 2), Random.Range(0.4f, 2), 0);
    }
}
