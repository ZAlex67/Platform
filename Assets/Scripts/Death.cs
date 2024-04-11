using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private float _time = 0.5f;

    private void Start()
    {
        Destroy(gameObject, _time);
    }
}
