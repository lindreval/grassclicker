using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalCount : MonoBehaviour
{
    public static double totalCount;
    public TextMeshProUGUI totalText;

    private void Update() {
        totalText.text = "Total = " + totalCount;
    }

}
