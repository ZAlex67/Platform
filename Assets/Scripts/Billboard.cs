using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void LateUpdate()
    {
        transform.rotation = _camera.rotation;
    }
}