using UnityEngine;
using static DataOfWorkers;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "StoreEmployeesTask", menuName = "Tasks/Store Employees")]
    public class StoreEmployeesTask : Task {

        [SerializeField]
        private ReadJSON LoadTask;

        private Employee[] StoredEmployeesArray;

        public override void Execute() {
            if(LoadTask == null) {
                Debug.LogError("ERROR");
                return;
            }

            // Moved data frome Read  Task
            StoredEmployeesArray = LoadTask.LoadedEmployees;

            if(StoredEmployeesArray != null) {
                Debug.Log($"Successfully completed: {StoredEmployeesArray.Length}");
            }

            //For understad,Did it work correctly
            
        }

        public Employee[] GetStoredArray() {
            return StoredEmployeesArray;
        }
    }
}
