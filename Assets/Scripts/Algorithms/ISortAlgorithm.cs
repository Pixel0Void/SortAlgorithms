using System;
using System.Collections.Generic;

public interface ISortAlgorithm
{
    void Sort(List<Bar> bars, float delayTime, OrderEnum order, Action onComplete);
}
