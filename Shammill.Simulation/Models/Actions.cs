using Shammill.Simulation.Components;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Shammill.Simulation.Models
{
    public class Actions
    {
        public Queue<SimulationAction> Queue = new Queue<SimulationAction>();
        // Thread-Safety, consider ConcurrentQueue<T> or lock.
    }
}


//public class TasksToRun
//{
//    private readonly ConcurrentQueue<TaskSettings> _tasks = new();

//    public TasksToRun() => _tasks = new ConcurrentQueue<TaskSettings>();

//    public void Enqueue(TaskSettings settings) => _tasks.Enqueue(settings);

//    public TaskSettings? Dequeue()
//    {
//        var hasTasks = _tasks.TryDequeue(out var settings);
//        return hasTasks ? settings : null;
//    }
//}