using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BarsManager m_BarsManager;
    [SerializeField] private SortManager m_SortManager;

    [Header("UI Elements")]
    [SerializeField] private Button m_RandomizeBtn;
    [SerializeField] private Button m_SortBtn;
    [SerializeField] private Dropdown m_OrderDropDown;

    private bool m_IsSorted = false;

    private void Awake()
    {
        m_OrderDropDown.AddOptions(Enum.GetNames(typeof(OrderEnum)).ToList());
    }

    public void OnRandomize()
    {
        m_IsSorted = false;
        m_BarsManager.SetValues();
    }

    public void OnSort()
    {
        if (m_IsSorted)
            OnRandomize();

        SetButtonsInteractable(false);

        m_SortManager.Sort(m_BarsManager.Bars, 0.01f, (OrderEnum)m_OrderDropDown.value ,() =>
        {
            SetButtonsInteractable(true);
            m_IsSorted = true;
        });
    }

    private void SetButtonsInteractable(bool value)
    {
        m_RandomizeBtn.interactable = value;
        m_SortBtn.interactable = value;
    }
}
