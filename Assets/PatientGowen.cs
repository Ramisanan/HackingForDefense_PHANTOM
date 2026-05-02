using UnityEngine;

public class PatientGownContactLogger : MonoBehaviour
{
    public string objectId = "patient_gown";
    public float expectedForce = 0.3f;

    private float contactStartTime;
    private bool isTouching = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTouching) return;

        isTouching = true;
        contactStartTime = Time.time;

        Debug.Log("[CONTACT_START] objectId=" + objectId +
                  " touchedBy=" + other.name +
                  " tag=" + other.tag +
                  " expectedForce=" + expectedForce.ToString("F2") + "N" +
                  " feel=smooth_soft" +
                  " time=" + Time.time.ToString("F2"));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isTouching) return;

        isTouching = false;
        float duration = Time.time - contactStartTime;

        Debug.Log("[CONTACT_END] objectId=" + objectId +
                  " touchedBy=" + other.name +
                  " totalDuration=" + duration.ToString("F2") + "s");
    }
}