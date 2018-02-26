using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EF.DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** EntityFramework Basic Tutorials Demo Start ***");
            Console.WriteLine("");

            EFBasics.DynamicProxyDemo();
            //DBEntityEntry класс, который полезен при получении различной 
            //информации об объекте.
            //DBEntityEntry позволяет получить доступ к состоянию сущности, 
            //текущему и исходному значению всех свойств данной сущности
            EFBasics.DBEntityEntryDemo();
            //контекст отслеживает сущности всякий раз, когда мы получаем,
            //добавляем, изменяем или удаляем любой объект.
            //Контекст "жив" во время любой из операций на сущностях. 
            //Контекст не будет следить, если выполняются какие-либо действия
            //над сущностями не из его области видимости.
            EFBasics.ChangeTrackingDemo();
            //Существуетсть два сценария, описывающего как Entity Framework 
            //сохраняет объект, Connected Scenario & Disconnected Scenario.
            //Контекст автоматически обнаружит изменения и обновит состояние объекта.
            EFBasics.CRUDOperationInConnectedScenarioDemo();
            //Disconnected Entities
            EFBasics.AddSingleEntity();
            EFBasics.AddEntityGraph();

            EFBasics.UpdateEntityDisconnectedScenario();
            EFBasics.DeleteEntityDisconnectedScenario();

            EFBasics.FindEntityDemo();
            EFBasics.OptimisticConcurrencyDemo();

            EFBasics.LocalDemo();
            EFBasics.LazyLoadingDemo();
            EFBasics.EagerLoading();
            EFBasics.ExplicitLoadingDemo();
            EFBasics.CRUDOperationInConnectedScenarioDemo();

            //EFBasics.RawSQLtoEntityTypeDemo();
            //EFBasics.RawSQLCommandDemo();
            //EFBasics.EntitySQLDemo();
            //EFBasics.EntitySQLUsingEntityConnectionDemo();
            //EFBasics.SpatialDataTypeDemo();
            //EFBasics.GetPropertyValuesDemo();
            //EFBasics.SetValuesDemo();
            //EFBasics.ValidationErrorDemo();
            Console.WriteLine("*** EntityFramework Basic Tutorials Demo Finished ***");
        }
    }

    class EFBasics
    {
        public static void ChangeTrackingDemo()
        {
            Console.WriteLine("*** ChangeTracking Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                //предотвратить создание прокси средой Entity Framework
                ctx.Configuration.ProxyCreationEnabled = false;
                Debug.WriteLine("*** ChangeTracking Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);

                Console.WriteLine("Find Student");
                var std1 = ctx.Students.Find(1);

                Console.WriteLine($"ctx tracking changes of {ctx.ChangeTracker.Entries().Count()} entity.");

                DisplayTrackedEntities(ctx.ChangeTracker);

                Console.WriteLine("Find Standard");

                var standard = ctx.Standards.Find(1);

                Console.WriteLine($"ctx tracking changes of {ctx.ChangeTracker.Entries().Count()} entities.");
                Console.WriteLine("Editing Standard");

                standard.StandardName = "Edited name";
                DisplayTrackedEntities(ctx.ChangeTracker);

                Teacher tchr = new Teacher {TeacherName = "new teacher"};
                Console.WriteLine("Adding New Teacher");

                ctx.Teachers.Add(tchr);
                Console.WriteLine("");
                Console.WriteLine("ctx tracking changes of {ctx.ChangeTracker.Entries().Count()} entities.");
                DisplayTrackedEntities(ctx.ChangeTracker);

                Console.WriteLine("Remove Student");
                Console.WriteLine("");

                ctx.Students.Remove(std1);
                DisplayTrackedEntities(ctx.ChangeTracker);
            }
            Console.WriteLine("*** ChangeTracking Demo Finished ***");
        }

        private static void DisplayTrackedEntities(DbChangeTracker changeTracker)
        {
            var entries = changeTracker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Status: {0}", entry.State);
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
        }

        public static void DBEntityEntryDemo()
        {
            Console.WriteLine("*** DBEntityEntry Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** DBEntityEntry Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                //get student whose StudentId is 1
                var student = ctx.Students.Find(1);

                //edit student name
                student.StudentName = "Edited name";

                //get DbEntityEntry object for student entity object
                var entry = ctx.Entry(student);
                entry.State = System.Data.Entity.EntityState.Modified;

                //get entity information e.g. full name
                Console.WriteLine($"Entity Name: {entry.Entity.GetType().FullName}");

                //get current EntityState
                Console.WriteLine($"Entity State: {entry.State}");

                Console.WriteLine("********Property Values********");

                foreach (var propertyName in entry.CurrentValues.PropertyNames)
                {
                    Console.WriteLine($"Property Name: {propertyName}");

                    //get original value
                    var orgVal = entry.OriginalValues[propertyName];
                    Console.WriteLine($"     Original Value: {orgVal}");

                    //get current values
                    var curVal = entry.CurrentValues[propertyName];
                    Console.WriteLine($"     Current Value: {curVal}");
                }

                var collectionProperty = entry.Collection<Course>(s => s.Courses);
                foreach (var course in collectionProperty.Query())
                {
                    Console.WriteLine($"     course: {course.CourseName}");
                }
            }
            Console.WriteLine("*** DBEntityEntry Demo Finished ***");

        }

        public static void CRUDOperationInConnectedScenarioDemo()
        {
            Console.WriteLine("*** CRUD Operation In Connected Scenario Demo Start ***");

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** CRUD Operation In Connected Scenario Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                var projectionQuery = from s in ctx.Students
                    select s;

                var studentList = projectionQuery.ToList(); //! not detected

                //Perform create operation
                ctx.Students.Add(new Student
                {
                    StudentName = "New Student from CRUD Operation"
                });

                //Perform Update operation
                Student studentToUpdate = studentList.FirstOrDefault(s => s.StudentID == 14);
                if (studentToUpdate != null) studentToUpdate.StudentName = "Edited Student Name";

                //Perform delete operation
                if (studentList.FirstOrDefault(s => s.StudentID == 10) != null)
                    ctx.Students.Remove(studentList.FirstOrDefault(s => s.StudentID == 10));

                //Execute Insert, Update & Delete queries in the database
                ctx.SaveChanges();

            }
            Console.WriteLine("*** CRUD Operation In Connected Scenario Demo Finished ***");
        }

        //Поиск в запросе в Entity Framework использует следующую последовательность:
        // - Сначала выполняется поиск в коллекции объектов, уже загруженных
        //из базы данных в память приложения.
        // - Если к коллекции добавлялись новые объекты, то поиск выполняется и в них.
        // - Выполняется поиск в базе данных в объектах, которые еще не были   
        //загружены в память приложения.
        public static void FindEntityDemo()
        {
            Console.WriteLine("*** Find Entity Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Find Entity Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                Student st1 = ctx.Students.First();
                var stud = ctx.Students.Find(1);

                Console.WriteLine($"{stud.StudentName} found");

                //Student st1 = ctx.Students.First();
                Console.WriteLine(st1 == stud);

            }
            Console.WriteLine("*** Find Entity Demo Finished ***");
        }

        public static void GetPropertyValuesDemo()
        {
            Console.WriteLine("*** Get Property Values Demo Start ***");

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Get Property Values Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                var stud = ctx.Students
                    .Include("StudentAddress")
                    .FirstOrDefault(s => s.StudentID == 1);

                stud.StudentName = "Changed Student Name";

                //Get reference reference property eg. foerignkey entity (single entity)
                var referenceProperty = ctx.Entry(stud).Reference(s => s.Standard);

                //get collection navigation property information (one-to-many or many-to-many property) eg. Student.Courses
                var collectionProperty = ctx.Entry(stud).Collection<Course>(s => s.Courses);

                string propertyName = ctx.Entry(stud).Property("StudentName").Name;
                string currentValue = ctx.Entry(stud).Property("StudentName").CurrentValue.ToString();
                string originalValue = ctx.Entry(stud).Property("StudentName").OriginalValue.ToString();
                bool isChanged = ctx.Entry(stud).Property("StudentName").IsModified;
                var dbEntity = ctx.Entry(stud).Property("StudentName").EntityEntry;

                Console.WriteLine("StudentName property values: ");
                Console.WriteLine("Property Name:" + propertyName);
                Console.WriteLine("current value:" + currentValue);
                Console.WriteLine("original value:" + originalValue);
                Console.WriteLine("isModified:" + isChanged);
            }

            Console.WriteLine("*** GetPropertyValuesDemo Finished ***");
        }

        public static void LocalDemo()
        {
            Console.WriteLine("*** Local Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** LocalDemo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                int count = ctx.Students.Local.Count;
                Console.WriteLine($"Объектов Student в памяти {count}");

                ctx.Students.Add(new Student
                {
                    StudentName = "New Student for Local demo"
                });

                ctx.Students.Remove(ctx.Students.Find(1));

                count = ctx.Students.Local.Count;
                Console.WriteLine($"Объектов Student в памяти {count}");

                // Loop over the unicorns in the ctx.
                Console.WriteLine("***In Local: ");
                foreach (var student in ctx.Students.Local)
                {
                    Console.WriteLine(
                        $"Found {student.StudentID}: {student.StudentName} with state {ctx.Entry(student).State}");
                }

                // Perform a query against the database.
                Console.WriteLine("***In DbSet query: ");
                foreach (var student in ctx.Students)
                {
                    Console.WriteLine(
                        $"Found {student.StudentID}: {student.StudentName} with state {ctx.Entry(student).State}");
                }

                ctx.Courses.Load();
                int countCourses = ctx.Courses.Local.Count;

                Console.WriteLine($"Объектов Course в памяти {countCourses}");
                Console.WriteLine("*** Local Demo Finished ***");

            }
        }

        public static void ValidationErrorDemo()
        {
            try
            {
                Console.WriteLine("*** ValidationErrorDemo Start ***");
                using (var ctx = new SchoolDBEntities())
                {
                    ctx.Students.Add(new Student() {StudentName = ""});
                    ctx.Standards.Add(new Standard() {StandardName = ""});

                    Console.WriteLine("***ValidationErrorDemo Start");

                    ctx.SaveChanges();


                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
                {
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error Property Name {0} : Error Message: {1}",
                            error.PropertyName, error.ErrorMessage);
                    }
                }
                Console.WriteLine("*** ValidationErrorDemo Finished ***");
            }
        }

        public static void LazyLoadingDemo()
        {
            Console.WriteLine("*** Lazy Loading Demo Start ***");

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Lazy Loading Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                //Loading student only
                Student student = ctx.Students.FirstOrDefault(s => s.StudentID == 1);

                //Loads Student address for particular Student only (seperate SQL query)
                if (student != null)
                {
                    Standard std = student.Standard;
                }
            }
            Console.WriteLine("*** LazyLoadingDemo Finished ***");
        }

        public static void ExplicitLoadingDemo()
        {
            Console.WriteLine("*** Explicit Loading Demo Start ***");

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Explicit Loading Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                //Loading students only
                IList<Student> studList = ctx.Students.ToList<Student>();

                Student std = studList.FirstOrDefault(s => s.StudentID == 1);

                //Loads Standard for particular Student only (seperate SQL query)
                ctx.Entry(std).Reference(s => s.Standard).Load();

                //Loads Courses for particular Student only (seperate SQL query)
                ctx.Entry(std).Collection(s => s.Courses).Load();
            }

            Console.WriteLine("*** Explicit Loading Demo Finished ***");
        }

        public static void EagerLoading()
        {
            Console.WriteLine("*** Eager Loading ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Eager Loading ***");
                ctx.Database.Log = s => Debug.WriteLine(s);

                // Загрузить всех покупателей и связанные с ними заказы
                var students = ctx.Students.Include("Courses")
                    //vs  System.Data.Entity
                    .Include(c => c.Courses);
                    //.ToList(); // +1 запрос к базе

                //TODO

                // Получить все их заказы
                List<Course> courses = students.SelectMany(c => c.Courses)
                    // Запрос к базе данных не выполняется,
                    // т.к. данные уже были извлечены 
                    // ранее с помощью прямой загрузки
                    .ToList();
            }
            Console.WriteLine("*** Eager Loading Finished ***");
        }

        public static void DynamicProxyDemo()
        {
            Console.WriteLine("*** DynamicProxyDemo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** DynamicProxyDemo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                //var stud1 = ctx.Students
                //    .Include("Standard.Teachers")
                //    .FirstOrDefault(s => s.StudentName == "Student1");

                //var stud = ctx.Students
                //    .Include("Standard.Teachers")
                //    .FirstOrDefault(s => s.StudentName == "Student1");

                //getting POCO Proxy object
                var studentPOCOProxy = ctx.Students.Find(1);

                Console.WriteLine($"Proxy Type: {studentPOCOProxy}");

                //get actual type of POCO Proxy object
                Type pocoType = studentPOCOProxy.GetType().BaseType;
                Console.WriteLine($"Actual type of Proxy: {pocoType}");

                //Disable Proxy creation
                ctx.Configuration.ProxyCreationEnabled = false;

                //Getting POCO object (Plain Old CLR Object)
                Student stdPOCO = ctx.Students.Find(2);
                Console.WriteLine($"Actual type entity: {stdPOCO}");
            }
            Console.WriteLine("*** DynamicProxyDemo Finished ***");
        }

        public static void RawSQLtoEntityTypeDemo()
        {
            Console.WriteLine("*** Raw SQL to Entity Type Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                var studentList = ctx.Students.SqlQuery("Select * from Student").ToList<Student>();

                var studentName = ctx.Students
                    .SqlQuery("Select StudentId, StudentName, StandardId, RowVersion from Student where StudentId =1")
                    .ToList();

            }
            Console.WriteLine("*** Raw SQL to Entity Type Demo Finished ***");
        }

        public static void RawSQLCommandDemo()
        {
            Console.WriteLine("*** Raw SQL Command Demo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                //Get student name of string type
                string standardName =
                    ctx.Database.SqlQuery<string>("Select standardName from Standard where standardid=1")
                        .FirstOrDefault<string>();

                //Update command
                int noOfRowUpdate =
                    ctx.Database.ExecuteSqlCommand(
                        "Update student set studentname ='changed student by command' where studentid=1");
                //Insert command
                int noOfRowInsert =
                    ctx.Database.ExecuteSqlCommand("insert into student(studentname) values('New Student')");
                //Delete command
                int noOfRowDeleted = ctx.Database.ExecuteSqlCommand("delete from student where studentid=0");

            }
            Console.WriteLine("*** Raw SQL Command Demo Finished ***");
        }

        public static void EntitySQLDemo()
        {
            Console.WriteLine("*** EntitySQLDemo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                string sqlString = "SELECT VALUE st FROM SchoolDBEntities.Students " +
                                   "AS st WHERE st.StudentID = 1";
                var objctx = ((IObjectContextAdapter) ctx).ObjectContext;

                ObjectQuery<Student> student = objctx.CreateQuery<Student>(sqlString);
                Student std = student.FirstOrDefault();

                Console.WriteLine("*** EntitySQLDemo Finished ***");

            }
        }

        public static void EntitySQLUsingEntityConnectionDemo()
        {
            Console.WriteLine("*** EntitySQLUsingEntityConnectionDemo Start ***");
            using (var con = new EntityConnection("name=SchoolDBEntities"))
            {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT VALUE st FROM SchoolDBEntities.Students as st where st.StudentID = 1";
                Dictionary<int, string> dict = new Dictionary<int, string>();
                using (
                    EntityDataReader rdr =
                        cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (rdr.Read())
                    {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetString(1);

                        dict.Add(a, b);
                    }
                }
            }
            Console.WriteLine("*** EntitySQLUsingEntityConnectionDemo Finished ***");
        }

        public static void SetValuesDemo()
        {
            Console.WriteLine("*** SetValuesDemo Start ***");
            StudentDTO studDTO = new StudentDTO();
            studDTO.StudentName = "StudentName from DTO";

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** SetValuesDemo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                var stud = ctx.Students.Find(1);

                var studEntry = ctx.Entry(stud);
                studEntry.CurrentValues.SetValues(studDTO);
                Console.WriteLine("****SetValuesDemo Start: ");

                foreach (var propertyName in studEntry.CurrentValues.PropertyNames)
                {
                    Console.WriteLine("Property {0} has value {1}",
                        propertyName, studEntry.CurrentValues[propertyName]);
                }
                Console.WriteLine("*** SetValuesDemo Finished ***");
            }

        }

        public static void SpatialDataTypeDemo()
        {
            Console.WriteLine("*** SpatialDataTypeDemo Start ***");
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** SpatialDataTypeDemo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);
                //Add Location using System.Data.Entity.Spatial.DbGeography
                ctx.Courses.Add(new Course()
                {
                    CourseName = "New Course from SpatialDataTypeDemo",
                    Location = DbGeography.FromText("POINT(-122.360 47.656)")
                });

                ctx.SaveChanges();
            }

            Console.WriteLine("*** SpatialDataTypeDemo Finished ***");

        }

        public static void OptimisticConcurrencyDemo()
        {
            Console.WriteLine("*** Optimistic Concurrency Demo Start ***");
            Student student1WithUser1 = null;
            Student student1WithUser2 = null;

            //User 1 gets student
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("*** Optimistic Concurrency Demo Start ***");
                ctx.Database.Log = s => Debug.WriteLine(s);

                //ctx.Configuration.ProxyCreationEnabled = false;
                student1WithUser1 = ctx.Students.Single(s => s.StudentID == 1);
            }
            //User 2 also get the same student
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Database.Log = s => Debug.WriteLine(s);
                //ctx.Configuration.ProxyCreationEnabled = false;

                student1WithUser2 = ctx.Students.Single(s => s.StudentID == 1);
            }
            //User 1 updates Student name
            student1WithUser1.StudentName = "Edited from user1";

            //User 2 updates Student name
            student1WithUser2.StudentName = "Edited from user2";

            //User 1 saves changes first
            using (var ctx = new SchoolDBEntities())
            {
                try
                {
                    ctx.Entry(student1WithUser1).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Optimistic Concurrency exception occured");
                }
            }

            //User 2 saves changes after User 1. 
            //User 2 will get concurrency exection because CreateOrModifiedDate 
            //is different in the database 
            using (var ctx = new SchoolDBEntities())
            {
                try
                {
                    ctx.Entry(student1WithUser2).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Optimistic Concurrency exception occured");
                }
            }
            Console.WriteLine("*** Optimistic Concurrency Demo Finished ***");
        }

        public static void AddSingleEntity()
        {
            Console.WriteLine("****Starting Add Single Entity****");

            Student newStudent = new Student {StudentName = "Student12"};
            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("****Starting Add Single Entity****");
                ctx.Database.Log = s => Debug.WriteLine(s);
                ctx.Students.Add(newStudent);
                //vs
                //ctx.Entry(newStudent).State = EntityState.Added;
                Console.WriteLine($"Student EntityState: {ctx.Entry(newStudent).State}");
                ctx.SaveChanges();

                Console.WriteLine($"New Student Entity has been added with new StudentId = {newStudent.StudentID}");
            }
            Console.WriteLine("****Finished Add Single Entity****");

        }

        public static void AddEntityGraph()
        {
            Console.WriteLine("****Starting Add Entity Graph****");

            //Create student in disconnected mode
            Student newStudent = new Student
            {
                StudentName = "New Single Student",
                Standard = new Standard {StandardName = "New Standard"}
            };

            //Assign new standard to student entity

            //add new course with new teacher into student.courses
            newStudent.Courses.Add(new Course
            {
                CourseName = "New Course for single student",
                Teacher = new Teacher
                {
                    TeacherName = "New Teacher"
                }
            });

            using (var ctx = new SchoolDBEntities())
            {
                Debug.WriteLine("****Starting Add Entity Graph****");
                ctx.Database.Log = s => Debug.WriteLine(s);
                ctx.Students.Add(newStudent);
                Console.WriteLine($"Student EntityState: {ctx.Entry(newStudent).State}");
                Console.WriteLine($"Standart EntityState: {ctx.Entry(newStudent.Standard).State}");
                ctx.SaveChanges();

                Console.WriteLine($"New Student Entity has been added with new StudentId = {newStudent.StudentID}");
                Console.WriteLine($"New Standard Entity has been added with new StandardId = {newStudent.StandardId}");
                Console.WriteLine(
                    $"New Course Entity has been added with new CourseId = {newStudent.Courses.ElementAt(0).CourseId}");
                Console.WriteLine(
                    $"New Teacher Entity has been added with new TeacherId = {newStudent.Courses.ElementAt(0).TeacherId}");
            }

            Console.WriteLine("****Finished Add Entity Graph****");

        }

        public static void UpdateEntityDisconnectedScenario()
        {
            Console.WriteLine("****Starting Update Single Entity****");

            Student student;
            //1. Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                student = ctx.Students
                    .FirstOrDefault(s => s.StudentName == "Student2");
            }

            //2. change student name in disconnected mode (out of ctx scope)
            if (student != null)
            {
                student.StudentName = "Updated Student1";
            }

            //save modified entity using new Context
            using (var ctx = new SchoolDBEntities())
            {
                //3. Mark entity as modified
                ctx.Entry(student).State = EntityState.Modified;

                //4. call SaveChanges
                ctx.SaveChanges();
            }

            Console.WriteLine("****Finished Update Single Entity****");

        }

        public static void DeleteEntityDisconnectedScenario()
        {
            Student studentToDelete;
            //1. Get student from DB
            using (var ctx = new SchoolDBEntities())
            {
                studentToDelete = ctx.Students
                    .FirstOrDefault(s => s.StudentName == "New Student from CRUD Operation");
            }

            //Create new context for disconnected scenario
            using (var newContext = new SchoolDBEntities())
            {
                newContext.Entry(studentToDelete).State = EntityState.Deleted;

                newContext.SaveChanges();
            }
        }

        public static void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            // Настройки контекста
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Database.Log = s => Debug.WriteLine(s);

                ctx.Entry(entity).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public static void Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            // Настройки контекста
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Database.Log = s => Debug.WriteLine(s);

                // Отключаем отслеживание и проверку изменений для
                //оптимизации вставки множества полей
                ctx.Configuration.AutoDetectChangesEnabled = false;
                ctx.Configuration.ValidateOnSaveEnabled = false;

                foreach (TEntity entity in entities)
                    ctx.Entry(entity).State = EntityState.Added;
                ctx.SaveChanges();

                ctx.Configuration.AutoDetectChangesEnabled = true;
                ctx.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public static void DeleteOrder()
        {
            using (var ctx = new SchoolDBEntities())
            {
                ctx.Database.Log = s => Debug.WriteLine(s);
                Student student = ctx.Students
                    .FirstOrDefault(o => o.StandardId == 5);

                ctx.Students.Remove(student);
                ctx.SaveChanges();

                //vs

                Student student1 = new Student
                {
                    StandardId = 5
                };

                ctx.Students.Attach(student1);
                ctx.Students.Remove(student1);

                ctx.SaveChanges();
            }
        }

        public class StudentDTO
        {
            //public int StudentID { get; set; }
            public string StudentName { get; set; }
        }
    }
}
