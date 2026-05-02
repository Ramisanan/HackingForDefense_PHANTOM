using System.Collections.Generic;
using UnityEngine;

public class HapticSimulationManager : MonoBehaviour
{
    public string activeProcedureId = "VAX01";

    private List<TissueLayer> tissueLayers = new List<TissueLayer>();
    private int lastLayerOrder = -1;

    private void Start()
    {
        PhantomLibraryLoader loader = GetComponent<PhantomLibraryLoader>();

        if (loader == null)
        {
            loader = gameObject.AddComponent<PhantomLibraryLoader>();
        }

        tissueLayers = loader.LoadTissueLayers();

        Debug.Log("PHANTOM Manager started for procedure: " + activeProcedureId);
    }

    public void UpdateFeedback(float depthMm)
    {
        TissueLayer currentLayer = GetCurrentLayer(depthMm);

        if (currentLayer == null)
        {
            Debug.Log("Outside known tissue layer. Depth: " + depthMm.ToString("F1") + " mm");
            return;
        }

        float force = Random.Range(currentLayer.forceMinN, currentLayer.forceMaxN);
        float vibration = Random.Range(currentLayer.vibrationLowHz, currentLayer.vibrationHighHz);

        string message =
            "Procedure: " + activeProcedureId + "\n" +
            "Depth: " + depthMm.ToString("F1") + " mm\n" +
            "Layer: " + currentLayer.tissueName + "\n" +
            "Force: " + force.ToString("F2") + " N\n" +
            "Vibration: " + vibration.ToString("F1") + " Hz\n" +
            "Feel: " + currentLayer.hapticDescriptor;

        if (currentLayer.popEvent && currentLayer.layerOrder != lastLayerOrder)
        {
            message += "\nPOP EVENT: " + currentLayer.tissueName + " breached";
        }

        lastLayerOrder = currentLayer.layerOrder;

        Debug.Log(message);
    }

    public void StopFeedback()
    {
        lastLayerOrder = -1;
        Debug.Log("No contact detected");
    }

    private TissueLayer GetCurrentLayer(float depthMm)
    {
        foreach (TissueLayer layer in tissueLayers)
        {
            if (layer.procedureId == activeProcedureId &&
                depthMm >= layer.depthStartMm &&
                depthMm <= layer.depthEndMm)
            {
                return layer;
            }
        }

        return null;
    }
}