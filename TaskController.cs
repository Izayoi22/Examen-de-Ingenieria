using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static List<Task> tasks = new List<Task>();
        private static int nextId = 1;

        // Listar todas las tareas
        public ActionResult Index()
        {
            return View(tasks);
        }

        // Crear una nueva tarea (GET)
        public ActionResult Create()
        {
            return View();
        }

        // Crear una nueva tarea (POST)
        [HttpPost]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = nextId++;
                tasks.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // Editar una tarea (GET)
        public ActionResult Edit(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return HttpNotFound();
            return View(task);
        }

        // Editar una tarea (POST)
        [HttpPost]
        public ActionResult Edit(Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                var existingTask = tasks.FirstOrDefault(t => t.Id == updatedTask.Id);
                if (existingTask != null)
                {
                    existingTask.Title = updatedTask.Title;
                    existingTask.Description = updatedTask.Description;
                    existingTask.DueDate = updatedTask.DueDate;
                    existingTask.Status = updatedTask.Status;
                    return RedirectToAction("Index");
                }
            }
            return View(updatedTask);
        }

        // Eliminar una tarea (GET)
        public ActionResult Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return HttpNotFound();
            return View(task);
        }

        // Eliminar una tarea (POST)
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
