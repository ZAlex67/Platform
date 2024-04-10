using System;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    private string _axisHoriz = "Horizontal";
    private string _buttonJump = "Jump";
    private float _move;

    public event Action Jump;

    public float Move => _move;

    private void Update()
    {
        _move = Input.GetAxis(_axisHoriz);

        if (Input.GetButtonDown(_buttonJump))
            Jump?.Invoke();
    }
}