using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleSort))]
public class SortManager : MonoBehaviour
{
    private BubbleSort m_BubbleSort;

    private void Awake()
    {
        m_BubbleSort = GetComponent<BubbleSort>();
    }

    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete)
    {
        m_BubbleSort.Sort(bars, delayTime, order,onComplete);
    }
}
