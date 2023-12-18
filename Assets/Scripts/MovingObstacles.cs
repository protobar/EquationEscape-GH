using System.Collections;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    [Range(0, 20)]
    public float speed;

    [Range(0, 10)]
    public float waitDuration;

    Vector3 targetPos;
    public GameObject ways;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    int speedMultiplier = 1;
    private void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        var step = speedMultiplier * speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos)
        {
            FlipScale();
            NextPoint();
        }
    }

    void FlipScale()
    {
        // Flip the X scale based on the direction
        if (direction == -1)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void NextPoint()
    {
        if (pointIndex == pointCount - 1) // Arrived last point
        {
            direction = -1;
        }
        if (pointIndex == 0) // Arrived first point
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
        StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }
}
