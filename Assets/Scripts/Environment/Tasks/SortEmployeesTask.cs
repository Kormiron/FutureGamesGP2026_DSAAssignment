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
        }
        public Employee[] GetSortedArray() {
            return SortedEmployeesArray;
        }
    }
}
