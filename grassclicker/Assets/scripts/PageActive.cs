using UnityEngine;
using System;
using UnityEngine.UI;
public class PageActive : MonoBehaviour
{
    public GameObject page;

    void Start()
    {
        page.SetActive(false);
    }

    public void ToggleActive()
    {
        page.SetActive(!page.activeSelf);
    }
}
