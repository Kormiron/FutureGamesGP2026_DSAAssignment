using UnityEngine;
using static DataOfWorkers;

public class SortOfWorkers {
    public static void QuickSortByEntrance(Employee[] Array) {
        if(Array == null || Array.Length <= 1) return;
        QuickSort(Array, 0, Array.Length - 1);
    }

    private static void QuickSort(Employee[] Array, int Low, int High) {
        if(Low < High) {
            int PivotIndex = GroupByPivot(Array, Low, High);
            QuickSort(Array, Low, PivotIndex - 1);
            QuickSort(Array, PivotIndex + 1, High);
        }
    }

    private static int GroupByPivot(Employee[] Array, int Low, int High) {
        if(Low < 0) {
            throw new System.ArgumentOutOfRangeException(nameof(Low), Low, $"'{nameof(Low)}' cannot be negative");
        }

        string Pivot = Array[High].LastEntranceInEngineRoom;
        int i = (Low - 1);

        for(int j = Low; j < High; j++) { 
            if(string.Compare(Array[j].LastEntranceInEngineRoom, Pivot) <= 0) {
                i++;
                Employee Temp = Array[i];
                Array[i] = Array[j];
                Array[j] = Temp;
            }
        }

        Employee TempPivot = Array[i + 1];
        Array[i + 1] = Array[High];
        Array[High] = TempPivot;

        return i + 1;
    }
}
