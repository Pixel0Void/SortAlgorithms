using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleSort))]
[RequireComponent(typeof(SelectionSort))]
[RequireComponent(typeof(InsertionSort))]
[RequireComponent(typeof(ShellSort))]
public class SortManager : MonoBehaviour
{
    private BubbleSort m_BubbleSort;
    private SelectionSort m_SelectionSort;
    private InsertionSort m_InsertionSort;
    private ShellSort m_ShellSort;

    private ISortAlgorithm m_CurrentSortAlgorithm;
    [SerializeField] private AlgorithmsEnum m_CurrentAlgorithmEnum;

    private void Awake()
    {
        m_BubbleSort = GetComponent<BubbleSort>();
        m_SelectionSort = GetComponent<SelectionSort>();
        m_InsertionSort = GetComponent<InsertionSort>();
        m_ShellSort = GetComponent<ShellSort>();
    }

    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete)
    {
        m_CurrentSortAlgorithm.Sort(bars, delayTime, order,onComplete);
    }

    public void AlgorithmChanged(int value)
    {
        m_CurrentAlgorithmEnum = (AlgorithmsEnum)value;
        switch (m_CurrentAlgorithmEnum)
        {
            case AlgorithmsEnum.Bubble:
                m_CurrentSortAlgorithm = m_BubbleSort;
                break;
            case AlgorithmsEnum.Selection:
                m_CurrentSortAlgorithm = m_SelectionSort;
                break;
            case AlgorithmsEnum.Insertion:
                m_CurrentSortAlgorithm = m_InsertionSort;
                break;
            case AlgorithmsEnum.Shell:
                m_CurrentSortAlgorithm = m_ShellSort;
                break;
            case AlgorithmsEnum.Quick:
                break;
            default:
                goto case AlgorithmsEnum.Bubble;
        }
    }
}
