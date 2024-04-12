using System;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    private string _axisHoriz = "Horizontal";
    private string _buttonJump = "Jump";
    private string _buttonShoot = "Fire1";
    private float _move;

    public event Action Jumping;
    public event Action Shooting;

    public float Move => _move;

    private void Update()
    {
        _move = Input.GetAxis(_axisHoriz);

        if (Input.GetButtonDown(_buttonJump))
            Jumping?.Invoke();

        if (Input.GetButtonDown(_buttonShoot))
            Shooting?.Invoke();
    }
}