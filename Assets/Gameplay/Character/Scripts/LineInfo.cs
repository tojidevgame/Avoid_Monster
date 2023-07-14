using UnityEngine;

public class LineInfo : MonoBehaviour
{
    [SerializeField] private float timeToCalculateLine = 0.05f;
    private int line;
    private float lastTimeCalculateLine;
    public int Line { get { return line; }  }

    private void Start()
    {
        CalculateLine();
        lastTimeCalculateLine = float.MinValue;
    }

    public void CalculateLine()
    {
        line = MapManager.Instance.CalculateLine(transform.position);
    }
    private void Update()
    {
        if(Time.time > lastTimeCalculateLine + timeToCalculateLine)
        {
            lastTimeCalculateLine = Time.time;
            line = MapManager.Instance.CalculateLine(transform.position);
        }
    }
}
