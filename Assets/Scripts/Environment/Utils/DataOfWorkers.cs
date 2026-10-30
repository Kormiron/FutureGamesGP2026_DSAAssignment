using UnityEngine;

public class DataOfWorkers : MonoBehaviour
{
    [System.Serializable]
    public class Employee {
        public string Name;
        public int EmployeeId;
        public bool HasEngineRoomClearance;
        public string LastEntranceInEngineRoom;
        public string LastExitFromEngineRoom;
    }

    [System.Serializable]
    public class EmployeeList {
        public Employee[] Employees;
    }
}
