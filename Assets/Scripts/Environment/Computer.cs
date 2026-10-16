using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private List<Task> StartupTasks = new List<Task>();
        private MyQueue TaskQueue = new MyQueue();

        private void Start() {
            // When game start move all task from StartipTask to MyQueue
            foreach(var task in StartupTasks) {
                if(task != null) {
                    TaskQueue.Enqueue(task);
                }
            }
        }


        public void OnInteract() {
            while(!TaskQueue.IsEmpty()) {
                Task nextTask = TaskQueue.Dequeue(); 
                nextTask.Execute();                  
            }
        }
    }
}
