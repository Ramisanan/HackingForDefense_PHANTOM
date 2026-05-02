using System;

[Serializable]
public class TissueLayer
{
    public string procedureId;
    public int layerOrder;
    public string tissueName;

    public float depthStartMm;
    public float depthEndMm;

    public float forceMinN;
    public float forceMaxN;

    public float vibrationLowHz;
    public float vibrationHighHz;

    public bool popEvent;
    public string hapticDescriptor;
}