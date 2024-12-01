using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private RectTransform backgroundImage;
    [SerializeField] private float moveDistance = 1000f;
    [SerializeField] private float moveDuration = 20f;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        Vector3 startPosition = backgroundImage.localPosition;
        Vector3 targetPosition = new Vector3(
            startPosition.x,
            startPosition.y - moveDistance,
            startPosition.z
        );

        float elapsedTime = 0f;
        
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            backgroundImage.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        
        backgroundImage.localPosition = targetPosition;
    }
}
