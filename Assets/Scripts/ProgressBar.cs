using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform EndLine;
    [SerializeField] private Slider slider;

    private float maxDistance;

    void Start()
    {
        maxDistance = GetDistance();
    }
    void Update()
    {
        if (Player.position.magnitude <= maxDistance && Player.position.y <= EndLine.position.y)
        {
            float distance = 1 - (GetDistance() / maxDistance);
            setProgress(distance);
        }
    }
    private float GetDistance()
    {
        return Vector3.Distance(Player.position, EndLine.position);
    }
    private void setProgress(float p)
    {
        slider.value = p;
    }
}
