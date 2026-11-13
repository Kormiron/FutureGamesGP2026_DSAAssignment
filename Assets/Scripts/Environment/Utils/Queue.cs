using Environment.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils {
    [System.Serializable]
    public class MyQueue {
        [SerializeField]
        private List<Task> Tasks = new List<Task>();

        //add element to queue
        public void Enqueue(Task Task) {
            Tasks.Add(Task);
        }

        //remove element from queue by FIFO 
        public Task Dequeue() {
            if(Tasks.Count == 0) {
                throw new Exception("Queue is empty, can't dequeue");
            }
            Task Task = Tasks[0];
            Tasks.RemoveAt(0);
            return Task;
        }

        // show the peek element in queue
        public Task Peek() {
            if(Tasks.Count == 0) {
                throw new Exception("Queue is empty, can't peek");
            }
            return Tasks[0];
        }

        public bool IsEmpty() {
            Tasks.RemoveAll(t => t == null); // remove all empty task
            return Tasks.Count == 0;
        }


        public int Count => Tasks.Count;
    }
}
