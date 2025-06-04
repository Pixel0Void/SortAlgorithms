using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSort : BaseSort, ISortAlgorithm
{
    public void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onCompelete)
    {
        StartCoroutine(Sorting(bars,delayTime, order, onCompelete));
    }

    private IEnumerator Sorting(List<Bar> bars, float delay, OrderEnum order, Action onComplete)
    {
        int max = bars.Count;

        int i, j, inc, temp;
        inc = 3;

        while (inc > 0)
        {
            for (i = 0; i < max; i++)
            {
                j = i;
                temp = bars[i].Value;

                while ((j >= inc) && CompareTool.CompareValues(bars[j - inc].Value, temp, order))
                {
                    bars[j].Value = bars[j - inc].Value;

                    int tempJ = j;

                    j = j - inc;

                    bars[tempJ].SetColor(m_ModifiedColor);
                    bars[tempJ - inc].SetColor(m_ModifiedColor);

                    yield return new WaitForSeconds(delay);

                    bars[tempJ].ResetColorToOriginal();
                    bars[tempJ - inc].ResetColorToOriginal();
                }

                bars[j].Value = temp;
                yield return new WaitForSeconds(delay);
            }

            if (inc / 2 != 0)
                inc = inc / 2;
            else if (inc == 1)
                inc = 0;
            else
                inc = 1;

            yield return new WaitForSeconds(delay);
        }

        onComplete();
    }
}
