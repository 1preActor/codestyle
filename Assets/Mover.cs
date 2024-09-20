using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _waypointContainer;

    private Transform[] _waypoints;
    private int _waypointIndex;

    private void Start()
    {
        _waypoints = new Transform[_waypointContainer.childCount];

        _waypointIndex = ++_waypointIndex % _waypoints.Length;
    }

    private void Update()
    {
        Transform _targetWaypoint = _waypoints[_waypointIndex];

        LookAtWaypoint();
        transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint.position, _moveSpeed * Time.deltaTime);

        if (transform.position == _targetWaypoint.position)
            ChooseWaypoint();
    }

    private void ChooseWaypoint()
    {
        _waypointIndex++;

        if (_waypointIndex == _waypoints.Length)
            _waypointIndex = 0;
    }

    private void LookAtWaypoint()
    {
        Vector3 currentWaypointPosition = _waypoints[_waypointIndex].transform.position;

        transform.forward = currentWaypointPosition - transform.position;
    }
}