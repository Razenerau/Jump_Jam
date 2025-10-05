using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalView : MonoBehaviour
{
    public List<Image> SignalPanels;
    public List<Color> SignalColors;
    public int SignalStrength = 0;

    public void IncreaseSignalStrenght()
    {
        if (SignalStrength > 4) return;
        SignalStrength++;
        UpdateSignalPanels();
    }

    public void UpdateSignalPanels()
    {
        for (int i = 0; i < SignalStrength; i++)
        {
            SignalPanels[i].color = SignalColors[SignalStrength];
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            IncreaseSignalStrenght();
        }
    }
}
