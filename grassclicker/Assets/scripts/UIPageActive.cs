using UnityEngine;
using System;
using UnityEngine.UI;
public class UIPageActive : MonoBehaviour
{
    public GameObject page;

    void Start()
    {
        page.SetActive(true);
    }

    public void ToggleActive()
    {
        page.SetActive(!page.activeSelf);
    }
}
