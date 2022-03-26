using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DmgEffect : MonoBehaviour
{
    private Volume vignetteVolume;
    private Vignette vignette;
    // Start is called before the first frame update
    void Start()
    {
        vignetteVolume = GetComponents<Volume>().GetValue(1) as Volume;
        vignetteVolume.profile.TryGet<Vignette>(out vignette);
    }

    public IEnumerator DmgEf()
    {
        vignette.color.value = Color.red;
        vignette.rounded.value = true;
        vignette.intensity.value = 0.6f;
        yield return new WaitForSeconds(0.75f);
        vignette.color.value = Color.black;
        vignette.intensity.value = 0.267f;
        vignette.rounded.value = false;
    }

    public void OnDmg()
    {
        StartCoroutine("DmgEf");
    }
}
