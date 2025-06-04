using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : BaseSort, ISortAlgorithm
{
    private OrderEnum m_Order;
    private float m_DelayTime;

    public void Sort(List<Bar> bars, float delay, OrderEnum order, Action onComplete)
    {
        switch (order)
        {
            case OrderEnum.Ascending:
                m_Order = OrderEnum.Descending;
                break;
            case OrderEnum.Descending:
                m_Order = OrderEnum.Ascending;
                break;
            default: goto case OrderEnum.Ascending;
        }
        m_DelayTime = delay;

        StartSort(bars, 0, bars.Count - 1);

        onComplete();
    }

    private void StartSort(List<Bar> bars, int low, int high)
    {
        if (low < high)
            StartCoroutine(Partition(bars, low, high, OnPartitionIsReady));
    }

    private IEnumerator Partition(List<Bar> bars, int low, int high, Action<List<Bar>, int, int, int> onPartitionCompleted)
    {
        int pivot = bars[high].Value;

        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (CompareTool.CompareValues(bars[j].Value, pivot, m_Order))
            {
                i++;

                int temp = bars[i].Value;
                bars[i].Value = bars[j].Value;
                bars[j].Value = temp;

                bars[i].SetColor(m_ModifiedColor);
                bars[j].SetColor(m_ModifiedColor);

                yield return new WaitForSeconds(m_DelayTime);

                bars[i].ResetColorToOriginal();
                bars[j].ResetColorToOriginal();
            }
        }

        int temp1 = bars[i + 1].Value;
        bars[i + 1].Value = bars[high].Value;
        bars[high].Value = temp1;

        bars[i + 1].SetColor(m_ModifiedColor);
        bars[high].SetColor(m_ModifiedColor);

        yield return new WaitForSeconds(m_DelayTime);

        bars[i + 1].ResetColorToOriginal();
        bars[high].ResetColorToOriginal();

        onPartitionCompleted(bars, low, high, i + 1);

        yield break;
    }

    private void OnPartitionIsReady(List<Bar> bars, int low, int high, int partitionIndex)
    {
        StartSort(bars, low, partitionIndex - 1);
        StartSort(bars, partitionIndex + 1, high);
    }
}
