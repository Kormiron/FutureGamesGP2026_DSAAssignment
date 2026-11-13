using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static DataOfWorkers;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "TreeSearchTask", menuName = "Tasks/Tree Search Task")]
    public class TreeSearchTask : Task {

        [SerializeField] private SortEmployeesTask SortEmployeesTask;
        private string StartTimePoint = "2234-08-09T22:00:00";
        private string EndTimePoint = "2234-08-09T23:00:00";

        public override void Execute() {
            Employee[] Employees = SortEmployeesTask.GetSortedArray();
            if(Employees == null || Employees.Length == 0) {
                UnityEngine.Debug.LogWarning("No employees found!");
                return;
            }

            WorkerTree Tree = new WorkerTree();
            foreach(var Emp in Employees) {
                Tree.Add(Emp); 
            }

            Stopwatch SearchTimer = Stopwatch.StartNew();

            List<Employee> Suspects = new List<Employee>();
            Tree.TreeSearchRange(Tree.Root, StartTimePoint, EndTimePoint, Suspects);

            SearchTimer.Stop();

            UnityEngine.Debug.Log("=== WEEK 5: TREE SEARCH BENCHMARK ===");
            UnityEngine.Debug.Log($"Search took: {SearchTimer.Elapsed.TotalMilliseconds:F4} ms ({SearchTimer.ElapsedTicks} ticks)");

            
        }
    }
}
