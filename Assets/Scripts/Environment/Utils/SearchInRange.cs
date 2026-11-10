using System.Collections.Generic;
using static DataOfWorkers;

public class SearchInRange
{
    public static List<Employee> FindSuspectsInRagnge(Employee[] SortedArray,string StartTimePoint,string EndTimePoint) {
        List<Employee> ResultArray = new List<Employee> ();

        int LeftBoundIndex = FindLeftBound(SortedArray, StartTimePoint);
        int RightBoundIndex = FindRightBound(SortedArray, EndTimePoint);

        for(int i = LeftBoundIndex; i < RightBoundIndex; i++) {
            ResultArray.Add(SortedArray[i]);
        }

        return ResultArray;
    }


    public static int FindLeftBound(Employee[] SortedArray, string TargetTimePoint) {
        int Low = 0;
        int High = SortedArray.Length - 1;
        int ResultIndex=0;

        while(Low <= High) {
            int Mid = Low + (High - Low) / 2;
            if(string.Compare(SortedArray[Mid].LastEntranceInEngineRoom, TargetTimePoint) >= 0) {
                ResultIndex = Mid;
                High = Mid - 1;
            }
            else {
                Low = Mid + 1;
            }
        }
        return ResultIndex;
    }
    public static int FindRightBound(Employee[] SortedArray, string TargetTimePoint) {
        int Low = 0;
        int High = SortedArray.Length - 1;
        int ResultIndex = 0;

        while(Low <= High) {
            int Mid = Low + (High - Low) / 2;
            if(string.Compare(SortedArray[Mid].LastEntranceInEngineRoom, TargetTimePoint) > 0) {
                ResultIndex = Mid;
                High = Mid - 1;
            }
            else {
                Low = Mid + 1;
            }
        }
        return ResultIndex;
    }


}
