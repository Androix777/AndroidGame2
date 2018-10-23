using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public IEnumerator Shake(float duration,float magnitude)
    {
        Vector3 startPos = transform.position;

        float elapsed = 0;

        while (elapsed > duration)
        {
            float x = Random.Range(-magnitude, magnitude);
            float y = Random.Range(-magnitude, magnitude);

            transform.localPosition = new Vector3(x,y, startPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
    }
}
