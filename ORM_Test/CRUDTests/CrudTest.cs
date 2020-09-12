using System;
using System.Collections.Generic;
using NUnit.Framework;
using Students.Objects;
using Students.WorkWithORM;
using System.Linq;

namespace ORM_Test.CRUD_Tests
{
    /// <summary>
    /// Class for testing CRUD.
    /// </summary>
    public class CrudTest
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// The method tests the method Insert when object id is not exists.
        /// </summary>
        [Test]
        public void Insert_WhenObjectIdIsNotExists_AddObject()
        {
            StudentDBContext studentDBContext = new StudentDBContext(_connectionString);
            var student = new List<Student>()
            {
                new Student()
                {
                FullName = "Saladuhin Pavel Viktorovich",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 01, 25),
                GroupId = 1
                }
            };

            studentDBContext.Student.Add(student);

            List<Student> resultList = studentDBContext.Student.GetCollection();
            studentDBContext.Student.Remove(student[0].Id);

            Assert.AreEqual(resultList.Last<Student>(), student);
        }
        /*
        /// <summary>
        /// The method tests the method Insert.
        /// </summary>
        [TestCase(1, 1, TestName = "Insert_WhenObjectIdExists_ThrowSqlException")]
        [TestCase(8, 3, TestName = "Insert_WhenObjectIdForeignKeyNotExist_ThrowSqlException")]
        public void Test_Insert(int id, int foreignKey)
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = id,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = foreignKey
            };

            Assert.That(() => crud.Insert(student), Throws.Exception);
        }

        /// <summary>
        /// The method tests the method Update.
        /// </summary>
        [Test]
        public void Test_Update()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 3,
                FullName = "Dfsdf dfdfa Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            crud.Update(student.ID, student);

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Delete when object exists.
        /// </summary>
        [Test]
        public void Delete_WhenObjectExists_DeleteObject()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 7,
                FullName = "Avseeva Eva Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2001, 4, 18),
                GroupID = 1
            };

            crud.Insert(student);

            crud.Delete(student.ID);

            Student result = crud.Read(student.ID);

            Assert.IsNull(result);
        }

        /// <summary>
        /// The method tests the method Read when object exists.
        /// </summary>
        [Test]
        public void Read_WhenObjectExists_GetObject()
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);
            var student = new Student()
            {
                ID = 1,
                FullName = "Famov Maxim Gennadievich",
                Gender = "Male",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result, student);
        }

        /// <summary>
        /// The method tests the method Read when object does not exists.
        /// </summary>
        /// <param name="id">Id</param>
        [TestCase(-1)]
        [TestCase(15)]
        public void Read_WhenObjectNotExists_GetNull(int id)
        {
            Crud<Student> crud = new Crud<Student>(_sqlConnection);

            Student result = crud.Read(id);

            Assert.IsNull(result);
        }
        */
    }
}
