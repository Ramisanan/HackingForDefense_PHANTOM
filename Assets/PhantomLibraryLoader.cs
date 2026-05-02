using System.Collections.Generic;
using UnityEngine;

public class PhantomLibraryLoader : MonoBehaviour
{
    public List<TissueLayer> LoadTissueLayers()
    {
        List<TissueLayer> layers = new List<TissueLayer>();

        TextAsset csvFile = Resources.Load<TextAsset>("phantom_tissue_layers");

        if (csvFile == null)
        {
            Debug.LogError("PHANTOM CSV file not found in Resources folder.");
            return layers;
        }

        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            if (string.IsNullOrEmpty(line))
                continue;

            string[] values = line.Split(',');

            if (values.Length < 11)
            {
                Debug.LogWarning("Skipping invalid row: " + line);
                continue;
            }

            TissueLayer layer = new TissueLayer();

            layer.procedureId = values[0].Trim();
            layer.layerOrder = int.Parse(values[1]);
            layer.tissueName = values[2].Trim();

            layer.depthStartMm = float.Parse(values[3]);
            layer.depthEndMm = float.Parse(values[4]);

            layer.forceMinN = float.Parse(values[5]);
            layer.forceMaxN = float.Parse(values[6]);

            layer.vibrationLowHz = float.Parse(values[7]);
            layer.vibrationHighHz = float.Parse(values[8]);

            layer.popEvent = bool.Parse(values[9]);
            layer.hapticDescriptor = values[10].Trim();

            layers.Add(layer);
        }

        Debug.Log("Loaded PHANTOM tissue layers: " + layers.Count);

        return layers;
    }
}