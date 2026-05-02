using UnityEngine;

public class PatientBodyContactLogger : MonoBehaviour
{
    public string objectId = "patient_body";
    public HapticSimulationManager hapticManager;

    private bool isTouching = false;
    private float contactStartTime;

    private void OnTriggerEnter(Collider other)
    {
        if (isTouching) return;

        isTouching = true;
        contactStartTime = Time.time;

        Debug.Log("[CONTACT_START] objectId=" + objectId +
                  " touchedBy=" + other.name +
                  " tag=" + other.tag +
                  " time=" + Time.time.ToString("F2"));

        if (hapticManager != null)
        {
            hapticManager.UpdateFeedback(1.5f);
        }
        else
        {
            Debug.LogWarning("Haptic Manager is not assigned on PatientBodyContactLogger.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isTouching) return;

        isTouching = false;
        float totalDuration = Time.time - contactStartTime;

        Debug.Log("[CONTACT_END] objectId=" + objectId +
                  " touchedBy=" + other.name +
                  " totalDuration=" + totalDuration.ToString("F2") + "s");

        if (hapticManager != null)
        {
            hapticManager.StopFeedback();
        }
    }
}