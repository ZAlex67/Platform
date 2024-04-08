using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);

        _enemySprite.flipX = _waypoints[_currentWaypoint].position.x < transform.position.x;
    }
}