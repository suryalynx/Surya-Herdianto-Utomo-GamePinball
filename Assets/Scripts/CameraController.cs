using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;
    public Transform target;
    private Vector3 defaultPosition;
    public bool hasTarget { get { return target != null; } }
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        }

    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;

    }

    public void BackToDefault()
    {
        target = null;
        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 Target, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, Target, Mathf.SmoothStep(0.0f, 1.0f, elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = Target;
    }
}
