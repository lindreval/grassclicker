using UnityEngine;
using System;
using UnityEngine.UI;
public class MultiPageActive : MonoBehaviour
{
    public GameObject page;
    public GameObject page2;

    void Start()
    {
        page.SetActive(true);
        page2.SetActive(false);
    }

    public void ToggleActive()
    {
        page.SetActive(!page.activeSelf);
    }

    public void ToggleOn()
    {
        page.SetActive(true);
        page2.SetActive(false);
    }

    public void ToggleOff()
    {
        page.SetActive(false);
        page2.SetActive(true);
    }
}