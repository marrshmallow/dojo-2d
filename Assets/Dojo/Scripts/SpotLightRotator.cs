using UnityEngine;

public class SpotLightRotator : MonoBehaviour
{
    [SerializeField] AnimationCurve animCurve;
    [SerializeField] float speed = 10;
    private float random;

    void Start()
    {
        random = Random.Range(0, 1f);
    }

    void Update()
    {
        float t = Time.time / speed + random;
        float r = animCurve.Evaluate(t - Mathf.Floor(t));
        var v = new Vector3(0, 0, r);
        transform.localEulerAngles = v;
    }
}
