using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TEST_IIS_API.DataContext;

namespace TEST_IIS_API.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Address { get; set; }
}


public static class StudentEndpoints
{
	public static void MapStudentEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Student", async (WebApiDbContext db) =>
        {
            return await db.Students.ToListAsync();
        })
        .WithName("GetAllStudents");

        routes.MapGet("/api/Student/{id}", async (int Id, WebApiDbContext db) =>
        {
            return await db.Students.FindAsync(Id)
                is Student model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetStudentById");

        routes.MapPut("/api/Student/{id}", async (int Id, Student student, WebApiDbContext db) =>
        {
            var foundModel = await db.Students.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(student);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })   
        .WithName("UpdateStudent");

        routes.MapPost("/api/Student/", async (Student student, WebApiDbContext db) =>
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Results.Created($"/Students/{student.Id}", student);
        })
        .WithName("CreateStudent");


        routes.MapDelete("/api/Student/{id}", async (int Id, WebApiDbContext db) =>
        {
            if (await db.Students.FindAsync(Id) is Student student)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok(student);
            }

            return Results.NotFound();
        })
        .WithName("DeleteStudent");
    }
}