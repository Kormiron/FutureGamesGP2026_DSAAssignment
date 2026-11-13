using System.Collections.Generic;
using static DataOfWorkers;

public class TreeNode {
    public List<Employee> Employees;          
    public string TimeKey;             
    public TreeNode Left;              
    public TreeNode Right;             

    public TreeNode(Employee Emp) {
        Employees = new List<Employee>() { Emp };
        TimeKey = Emp.LastEntranceInEngineRoom;
        Left = null;
        Right = null;
    }
}

public class WorkerTree {
    public TreeNode Root;

    public void Add(Employee Emp) {
        Root = AddRecursive(Root, Emp);
    }
    private TreeNode AddRecursive(TreeNode Current, Employee Emp) {
        if(Current == null) {
            return new TreeNode(Emp);
        }

        int Comparison = string.Compare(Emp.LastEntranceInEngineRoom, Current.TimeKey);

        if(Comparison < 0) {
            Current.Left = AddRecursive(Current.Left, Emp);
        }
        else if(Comparison > 0) {
            Current.Right = AddRecursive(Current.Right, Emp);
        }
        else {
            Current.Employees.Add(Emp);
        }

        return Current;
    }
    public void TreeSearchRange(TreeNode Node, string StartTimePoint, string EndTimePoint, List<Employee> Result) {
        if(Node == null)  return; 
        int CompareToStart = string.Compare(Node.TimeKey, StartTimePoint);
        int CompareToEnd = string.Compare(Node.TimeKey, EndTimePoint);

        if(CompareToStart > 0) {
            TreeSearchRange(Node.Left, StartTimePoint, EndTimePoint, Result);
        }

        if(CompareToStart >= 0 && CompareToEnd <= 0) {
            Result.AddRange(Node.Employees);
        }

        if(CompareToEnd < 0) {  
            TreeSearchRange(Node.Right, StartTimePoint, EndTimePoint, Result);
        }
    }
}
