using Environment.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils {
    public class MyQueue {
        private List<Task> tasks = new List<Task>();

        //add element to queue
        public void Enqueue(Task task) {
            tasks.Add(task);
        }

        //remove element from queue by FIFO 
        public Task Dequeue() {
            if(tasks.Count == 0) {
                throw new Exception("Queue is empty, can't dequeue");
            }
            Task task = tasks[0];
            tasks.RemoveAt(0);
            return task;
        }

        // show the peek element in queue
        public Task Peek() {
            if(tasks.Count == 0) {
                throw new Exception("Queue is empty, can't peek");
            }
            return tasks[0];
        }

        public bool IsEmpty() {
            tasks.RemoveAll(t => t == null); // remove all empty task
            return tasks.Count == 0;
        }


        public int Count => tasks.Count;
    }
}
