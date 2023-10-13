using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using swimming.Models;

namespace swimming.Controllers;

public class SampleController : Controller
{
 public IActionResult Index()
    {
        
        return View();
    }    
public IActionResult ToDoList(int id, string title, string description)
    {
       ViewData["id"]=id;
       ViewData["todotitle"]=title;
       ViewData["description"]=description;
       return View();
    }
}