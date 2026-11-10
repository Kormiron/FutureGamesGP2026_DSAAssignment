using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Rendering.Universal;
using static DataOfWorkers;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SearchEmployeesTask", menuName = "Tasks/Search Employees")]
    public class SearchEmployeesTask : Task {
        [SerializeField] SortEmployeesTask SortTask;
        private string StartTimePoint = "2234-08-09T22:00:00";
        private string EndTimePoint = "2234-08-09T23:00:00";

        public override void Execute() {
            if(SortTask == null) {
               UnityEngine.Debug.Log("SortTask reference is not assigned");
            }

            Employee[] SortedArray = SortTask.GetSortedArray();

            // I'm not do we need write our own Benchmark so I use System.Diagnostics
            Stopwatch Timer = Stopwatch.StartNew();

            List<Employee> Suspects = SearchInRange.FindSuspectsInRagnge(SortedArray, StartTimePoint, EndTimePoint);

            Timer.Stop();

            UnityEngine.Debug.Log($"Binary Search Benchmark Completed in {Timer.Elapsed.TotalMilliseconds:F4} ms ({Timer.ElapsedTicks} ticks)");
            UnityEngine.Debug.Log($"Found {Suspects.Count} suspects entering between {StartTimePoint} and {EndTimePoint}:");
            foreach(var Suspect in Suspects) {
                UnityEngine.Debug.Log($"[SUSPECT] ID: {Suspect.EmployeeId} | Name: {Suspect.Name} | Entrance: {Suspect.LastEntranceInEngineRoom}| HasEngineRoomClearance: {Suspect.HasEngineRoomClearance} ");
            }

        }
    }
}
