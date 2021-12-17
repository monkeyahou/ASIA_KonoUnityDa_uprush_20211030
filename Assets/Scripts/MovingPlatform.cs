using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIdex = 0;

    [SerializeField] private float speed = 2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIdex].transform.position, transform.position) < .1f)
        {
            currentWaypointIdex ++;
            if (currentWaypointIdex >= waypoints.Length)
            {
                currentWaypointIdex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIdex].transform.position, Time.deltaTime * speed);
    }

}