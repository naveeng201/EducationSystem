using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ES.DAL;
using ES.MODELS;
namespace ESTest
{
    [TestClass]
    public class AttendanceUnitTest
    {
        IAttendanceRepository _repository;
        public AttendanceUnitTest(IAttendanceRepository repository)
        {
            _repository = repository;
        }
        [TestMethod]
        public void GetAttendanceByClass()
        {
           var dtata = _repository.GetAttendanceByClass(1,1, Convert.ToDateTime("2017-08-10"));
        }
    }
}
