using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletFactory _bulletFactory;
    [SerializeField] private InputPlayer _input;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _input.Shooting += OnShootAction;
    }

    private void OnDisable()
    {
        _input.Shooting -= OnShootAction;
    }

    private void OnShootAction()
    {
        _bulletFactory.GetPrefab();

        _audioSource.Play();
    }
}