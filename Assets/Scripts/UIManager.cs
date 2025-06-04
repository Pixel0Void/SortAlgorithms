using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BarsManager m_BarsManager;
    [SerializeField] private SortManager m_SortManager;

    [Header("UI Elements")]
    [SerializeField] private Button m_RandomizeBtn;
    [SerializeField] private Button m_SortBtn;

    private bool m_IsSorted = false;

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

        m_SortManager.Sort(m_BarsManager.Bars, 0.01f, () =>
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
