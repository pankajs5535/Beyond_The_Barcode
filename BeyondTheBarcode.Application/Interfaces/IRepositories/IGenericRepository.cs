using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BeyondTheBarcode.Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Get All
        Task<IEnumerable<T>> GetAllAsync();

        // Get By Id
        Task<T?> GetByIdAsync(int id);

        // Find
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        // Count
        Task<int> CountAsync();

        // Add
        Task AddAsync(T entity);

        // Add Multiple
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update
        void Update(T entity);

        // Delete
        void Delete(T entity);

        // Delete Multiple
        void DeleteRange(IEnumerable<T> entities);
    }
}


/*

| Return Type      | Use When                                                           |
| ---------------- | ------------------------------------------------------------------ |
| `T`              | Returning a single entity                                          |
| `T?`             | Returning a single entity that may not exist                       |
| `IEnumerable<T>` | Returning a collection of entities                                 |
| `List<T>`        | Returning a modifiable list (less common in repository interfaces) |




Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

| Part              | Meaning                                                             |
| ----------------- | ------------------------------------------------------------------- |
| `Task<...>`       | The method runs asynchronously.                                     |
| `IEnumerable<T>`  | It returns a collection of entities (`T`).                          |
| `FindAsync(...)`  | The method name.                                                    |
| `Expression<...>` | Accepts an expression that Entity Framework can translate into SQL. |
| `Func<T, bool>`   | A function that takes a `T` (entity) and returns `true` or `false`. |
| `predicate`       | The parameter name (the filter condition).                          |


FindAsync accepts a filter condition (predicate) for entities of type T and asynchronously returns all
entities of type T that satisfy that condition."
Suppose T is Product.
await repository.FindAsync(p => p.Price > 100);


 
 */


/*
  
================== TASK vs VOID (EF Core / Repository Pattern) ==================

Use Task / Task<T>
------------------
Use when the method performs asynchronous work (uses await).

Examples:
✔ Database Query
✔ Save Changes
✔ API Call
✔ File Read/Write

Example:
Task<IEnumerable<T>> GetAllAsync();
Task<T?> GetByIdAsync(int id);
Task AddAsync(T entity);
Task<int> SaveAsync();

Reason:
These methods access external resources (Database, API, File System), so they should be asynchronous.


Use void
---------
Use when the method only changes the object's state in memory and does NOT access the database.

Examples:
void Update(T entity);
void Delete(T entity);

Reason:
_dbSet.Update(entity) and _dbSet.Remove(entity) only mark the entity as Modified/Deleted inside EF Core's Change Tracker.
No SQL is executed here.

The actual database operation happens only when:
await _unitOfWork.SaveAsync();


Easy Rule to Remember
---------------------
✔ Uses await / hits database  → Task or Task<T>
✔ Only changes object state    → void


Flow
----
Update(entity)  --> Marks entity as Modified
Delete(entity)  --> Marks entity as Deleted
SaveAsync()     --> Executes SQL UPDATE/DELETE in the database

======================================================================



Update Tip

"Because Update() only changes the entity state in EF Core's Change Tracker. 
It doesn't communicate with the database. The actual database operation happens 
in SaveChangesAsync(), so only SaveAsync() needs to be asynchronous."

*/