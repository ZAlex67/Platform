using System.Collections;
using UnityEngine;

public class HealthBarSliderSmooth : HealthBarSlider
{
    private Coroutine _coroutine;

    protected override void OnHealthUpdated()
    {
        base.ChangeMaxHealth();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeHealthSmooth());
    }

    private IEnumerator ChangeHealthSmooth()
    {
        float durationTime = 0.5f;
        float runningTime = 0;
        float startValue = Slider.value;

        while (durationTime - runningTime > float.Epsilon)
        {
            Slider.value = Mathf.Lerp(startValue, HealthPoint.CurrentHealth, runningTime / durationTime);
            runningTime += Time.deltaTime;
            yield return null;
        }

        Slider.value = HealthPoint.CurrentHealth;
    }
}