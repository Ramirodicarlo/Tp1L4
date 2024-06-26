﻿
using System.Collections.Generic;
using System.Linq;
using TODOLIST.Data.Entities;
using TODOLIST.Services.Interfaces;
using TODOLIST.DBContext;
using Microsoft.EntityFrameworkCore;
using ErrorOr;

namespace TODOLIST.Services.Implementations
{
    public class TodoService : IToDoService
    {
        private readonly ToDoContext _todos;

        public TodoService(ToDoContext todoService)
        {
            _todos = todoService;
        }

        public List<ToDo> GetAllToDos()
        {
            return _todos.ToDo.ToList();
        }

        public ToDo GetTodoById(int todoId)
        {
            var todoEncontrado = _todos.ToDo.FirstOrDefault(t => t.ToDoId == todoId);
            return todoEncontrado;
        }

        public ToDo CreateTodo(ToDo todo)
        {
            _todos.ToDo.Add(todo);
            _todos.SaveChanges();
            return todo;
        }

        public ToDo UpdateTodo(int todoId, ToDo updatedTodo)
        {
            var existingTodo = _todos.ToDo.Find(todoId);
            if (existingTodo == null)
            {
                return null;
            }
            existingTodo.Title = updatedTodo.Title;
            existingTodo.Description = updatedTodo.Description;


            _todos.SaveChanges();
            return existingTodo;
        }

        public bool DeleteTodo(int todoId)
        {
            ToDo toDoToBeDeleted = _todos.ToDo.SingleOrDefault(u => u.ToDoId == todoId);

            if (toDoToBeDeleted != null)
            {
                if (toDoToBeDeleted.State != false)
                {
                    toDoToBeDeleted.State = false;
                    _todos.Update(toDoToBeDeleted);
                    _todos.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(toDoToBeDeleted), "El ToDo a ser eliminado no fue encontrado.");
            }
        }

    }
}
