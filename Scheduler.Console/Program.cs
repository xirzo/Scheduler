// using Raylib_CsLo;
using Scheduler.Entities;
using Scheduler.Factories;
using Scheduler.Repositories;

namespace Scheduler.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Raylib.InitWindow(900, 600, "Scheduler");
        // RayGui.GuiLoadStyleDefault();
        // Raylib.SetTargetFPS(60);
        //
        // var editMode = false;
        //
        // while (!Raylib.WindowShouldClose())
        // {
        //     Raylib.BeginDrawing();
        //     Raylib.ClearBackground(Raylib.BLACK);
        //     
        //     RayGui.GuiLabel(new Rectangle(408, 344, 120, 24), "User");
        //     
        //     if (RayGui.GuiTextBox(new Rectangle(408, 344 + 24, 120, 24), "Name", 128, editMode))
        //     {
        //         editMode = !editMode;
        //     }
        //     
        //     if (RayGui.GuiButton(new Rectangle(408, 416, 120, 24), "Add user"))
        //     {
        //     }
        //     
        //     Raylib.DrawFPS(10, 10);
        //     Raylib.EndDrawing();
        // }
    }
}
