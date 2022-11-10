using StudentServiceLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StudentTest
{
    [TestClass]
    public class TestStudent
    {
        private Student student;
        private StudentService ss;
        [TestInitialize]
        public void Init()
        {
            student = new Student();
            ss = new StudentService();
        }
        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        public void WhenScoreisover10_exceptionshouldThrow()
        {
            student.Score = 11;
        }
        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        public void WhenScoreislower0_exceptionshouldThrow()
        {
            student.Score = -1;
        }

        public void Exceptionshouldin0to10()
        {
            String exceptionMessage = "Score must not exeed 10.0";
            String message = null;

            try
            {
                student.Score = 12;
            }
            catch(Exception e)
            {
                message = e.Message;
            }
            Assert.AreEqual(exceptionMessage, message);
        }

        [TestMethod]
        [DataRow(8,'A')]
        [DataRow(9,'A')]
        [DataRow(10,'A')]
        [DataRow(7,'B')]    
        [DataRow(6, 'C')]
        [DataRow(5,'C')]

        public void TestLetterScore(int score, char expect)
        {
            student.Score = score;
            char letterScore = student.getLetterScore();
            Assert.AreEqual(expect, letterScore);
        }


        [TestMethod]
        public void AddWhen_ID_NOTinList()
        {
            student.Id = 1;
            student.Name = "Minh";
            student.Age = 21;
            student.Score = 5;

            bool Added = ss.addStudent(student);
            Assert.IsTrue(Added);
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException))]

        public void ThrowNullRefferenceException_WhenStdIsNULL()
        {
            ss.addStudent(null);
        }

    }
}
