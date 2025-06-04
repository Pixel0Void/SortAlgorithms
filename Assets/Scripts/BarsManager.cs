using System.Collections.Generic;
using UnityEngine;

public class BarsManager : MonoBehaviour
{
    [SerializeField] private int m_BarsCount;
    public int BarsCount => m_BarsCount;

    [SerializeField] private Bar m_BarPrefab;
    [SerializeField] private Transform m_BarsParent;

    private List<Bar> m_Bars;
    public List<Bar> Bars => m_Bars;

    private void Start()
    {
        CreateBars();
    }

    private void CreateBars()
    {
        m_Bars = new List<Bar>(m_BarsCount);
        for (int i = 0; i < m_BarsCount; i++)
        {
            m_Bars.Add(Instantiate(m_BarPrefab, m_BarsParent));
        }
    }
}
