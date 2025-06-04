using System.Collections.Generic;
using UnityEngine;

public class BarsManager : MonoBehaviour
{
    [SerializeField] private int m_BarsCount;
    public int BarsCount => m_BarsCount;

    [SerializeField] private float m_BarsOffset = 5f;

    [SerializeField] private Bar m_BarPrefab;
    [SerializeField] private Transform m_BarsParent;

    private List<Bar> m_Bars;
    public List<Bar> Bars => m_Bars;

    private float m_BarWidth = 0f;

    private void Start()
    {
        CreateBars();
        SetPositions();
    }

    private void CreateBars()
    {
        m_Bars = new List<Bar>(m_BarsCount);
        for (int i = 0; i < m_BarsCount; i++)
        {
            m_Bars.Add(Instantiate(m_BarPrefab, m_BarsParent));
        }
    }

    private void SetPositions()
    {
        m_BarWidth = (int)m_Bars[0].GetComponent<RectTransform>().sizeDelta.x;
        float totalWidth = m_BarWidth * m_BarsCount + (m_BarsCount * m_BarsOffset);
        float startPositionX = (totalWidth / 2.0f) - totalWidth;
        foreach (var bar in m_Bars)
        {
            bar.GetComponent<RectTransform>().anchoredPosition = new Vector3(startPositionX, 0, 0);
            startPositionX += m_BarWidth + m_BarsOffset;
        }
    }
}
