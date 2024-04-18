using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Player _player;
    [SerializeField] private float _stopDistance;

    private int _currentWaypoint = 0;
    private bool _faceRight;

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.transform.position) < _stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

            Reflect(_player.transform.position.x, transform.position.x);
        }
        else
        {
            if (transform.position == _waypoints[_currentWaypoint].position)
            {
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);

            Reflect(_waypoints[_currentWaypoint].position.x, transform.position.x);
        }
    }

    private void Reflect(float direction, float position)
    {
        float flipX = 0f;
        float flipY = 180f;
        float flipZ = 0f;

        if ((direction > position && _faceRight) || (direction < position && !_faceRight))
        {
            transform.Rotate(flipX, flipY, flipZ);
            _faceRight = !_faceRight;
        }
    }
}