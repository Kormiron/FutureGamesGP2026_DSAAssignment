using System.IO;
using UnityEngine;
using static DataOfWorkers;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "ReadJSON", menuName = "Tasks/Load Employees Json")]
    public class ReadJSON : Task {

        // Array to our data
        public Employee[] LoadedEmployees;

        public override void Execute() {
            // Reading file without HARDCODED PATH
            string FilePath = Path.Combine(Application.streamingAssetsPath, "fullEmployeesList.json");

            if(!File.Exists(FilePath)) {
                Debug.LogError("File didn't find: " + FilePath);
                return;
            }

            string JSONContent = File.ReadAllText(FilePath);
            EmployeeList Data = JsonUtility.FromJson<EmployeeList>(JSONContent);
            LoadedEmployees = Data.Employees;

            Debug.Log($"Employees uploaded: {LoadedEmployees.Length}");
        }
    }
}
