using UnityEngine;
using static DataOfWorkers;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SortEmployeesTask", menuName = "Tasks/Sort Employees")]
    public class SortEmployeesTask : Task {
        [SerializeField]
        private StoreEmployeesTask StoreTask;
        private Employee[] SortedEmployeesArray;

        public override void Execute() {
            Employee[] OriginalArray = StoreTask.GetStoredArray();

            SortedEmployeesArray = (Employee[])OriginalArray.Clone();

            SortOfWorkers.QuickSortByEntrance(SortedEmployeesArray);

            Debug.Log($"Successfully sorted {SortedEmployeesArray.Length} employees using Quicksort!");

            foreach(var employee in SortedEmployeesArray) {
                Debug.Log($"[Sorted] Name: {employee.Name} | Last Entrance: {employee.LastEntranceInEngineRoom}");
            }
        }
        public Employee[] GetSortedArray() {
            return SortedEmployeesArray;
        }
    }
}
