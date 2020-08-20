using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    //Code sourced from: http://unitytipsandtricks.blogspot.com/2013/05/camera-shake.html
    //Look at https://www.youtube.com/watch?v=9A9yj8KnM8c

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private Vector3 originalCamPos;

    [SerializeField]
    private Vector3 originOffset;

    [SerializeField]
    private bool shakeConstantly;

    // Start is called before the first frame update
    void Start()
    {
        shakeConstantly = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shake(float duration, float magnitude)
    {

        float elapsed = 0.0f;

        originalCamPos = camera.transform.localPosition;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            camera.transform.localPosition = new Vector3(x + originOffset.x, y + originOffset.y, originalCamPos.z);

            yield return null;
        }

        camera.transform.localPosition = originalCamPos;
    }

    public IEnumerator ShakeConstant(float duration, float magnitude)
    {
        originalCamPos = camera.transform.localPosition;

        while (shakeConstantly)
        {
            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude;
            y *= magnitude;

            camera.transform.localPosition = new Vector3(x + originOffset.x, y + originOffset.y, originalCamPos.z);

            yield return null;
        }

        if(!shakeConstantly)
        {
            float elapsed = 0.0f;

            while (elapsed < duration)
            {

                elapsed += Time.deltaTime;

                float percentComplete = elapsed / duration;
                float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

                // map value to [-1, 1]
                float x = Random.value * 2.0f - 1.0f;
                float y = Random.value * 2.0f - 1.0f;
                x *= magnitude * damper;
                y *= magnitude * damper;

                camera.transform.localPosition = new Vector3(x + originOffset.x, y + originOffset.y, originalCamPos.z);

                yield return null;
            }
        }

        camera.transform.localPosition = originalCamPos;
    }

    public void SetShakeConstantly(bool value)
    {
        shakeConstantly = value;
    }
}
