using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleSort))]
[RequireComponent(typeof(SelectionSort))]
public class SortManager : MonoBehaviour
{
    private BubbleSort m_BubbleSort;
    private SelectionSort m_SelectionSort;

    private void Awake()
    {
        m_BubbleSort = GetComponent<BubbleSort>();
        m_SelectionSort = GetComponent<SelectionSort>();
    }

    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete)
    {
        m_SelectionSort.Sort(bars, delayTime, order,onComplete);
    }
}
