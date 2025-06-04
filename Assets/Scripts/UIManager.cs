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
    [SerializeField] private Dropdown m_AlgorithmsDropDown;

    private bool m_IsSorted = false;

    private void Awake()
    {
        m_OrderDropDown.AddOptions(Enum.GetNames(typeof(OrderEnum)).ToList());
        m_AlgorithmsDropDown.AddOptions(Enum.GetNames(typeof(AlgorithmsEnum)).ToList());
        OnAlgorithmChanged();
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

    public void OnAlgorithmChanged()
    {
        m_SortManager.AlgorithmChanged(m_AlgorithmsDropDown.value);
    }

    private void SetButtonsInteractable(bool value)
    {
        m_RandomizeBtn.interactable = value;
        m_SortBtn.interactable = value;
    }
}
