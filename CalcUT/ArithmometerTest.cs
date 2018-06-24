using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcModels;

namespace CalcUT
{
    [TestClass]
    public class ArithmometerTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            CalcOperationParam cop = new CalcOperationParam();
            
            // 1
            Arithmometer.Clear(ref cop);
            cop.arg = "=";  Arithmometer.Calc(ref cop);
            Assert.AreEqual("0", cop.result);
            Assert.AreEqual("", cop.history);
            // 2
            Arithmometer.Clear(ref cop);
            cop.arg = "0";  Arithmometer.Calc(ref cop);
            Assert.AreEqual("0", cop.result);
            Assert.AreEqual("", cop.history);
            // 3
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            Assert.AreEqual("1", cop.result);
            Assert.AreEqual("", cop.history);
            // 4
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            Assert.AreEqual("12", cop.result);
            Assert.AreEqual("", cop.history);
            // 5
            Arithmometer.Clear(ref cop);
            cop.arg = "0"; Arithmometer.Calc(ref cop);
            cop.arg = "+"; Arithmometer.Calc(ref cop);
            Assert.AreEqual("0+", cop.result);
            Assert.AreEqual("", cop.history);
            // 6
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "+"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            Assert.AreEqual("1+2", cop.result);
            Assert.AreEqual("", cop.history);
            // 7
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "+"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);
            Assert.AreEqual("3", cop.result);
            Assert.AreEqual("1+2=", cop.history);
            // 8
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "*"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);

            cop.arg = "4"; Arithmometer.Calc(ref cop);
            cop.arg = "6"; Arithmometer.Calc(ref cop);
            cop.arg = "/"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);
            Assert.AreEqual("123", cop.result);
            Assert.AreEqual("246/2=", cop.history);
            // 9
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "*"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "CE"; Arithmometer.Calc(ref cop);
            Assert.AreEqual("0", cop.result);
            Assert.AreEqual("", cop.history);
            // 10
            Arithmometer.Clear(ref cop);
            cop.arg = "8"; Arithmometer.Calc(ref cop);
            cop.arg = "+"; Arithmometer.Calc(ref cop);
            cop.arg = "+"; Arithmometer.Calc(ref cop);
            cop.arg = "*"; Arithmometer.Calc(ref cop);
            cop.arg = "/"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);
            Assert.AreEqual("4", cop.result);
            Assert.AreEqual("8/2=", cop.history);
            // 11 Division by zero
            Arithmometer.Clear(ref cop);
            cop.arg = "1"; Arithmometer.Calc(ref cop);
            cop.arg = "/"; Arithmometer.Calc(ref cop);
            cop.arg = "0"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);
            Assert.AreEqual("0", cop.result);
            Assert.AreEqual("Division by zero is impossible", cop.history);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "*"; Arithmometer.Calc(ref cop);
            cop.arg = "2"; Arithmometer.Calc(ref cop);
            cop.arg = "="; Arithmometer.Calc(ref cop);
            Assert.AreEqual("4", cop.result);
            Assert.AreEqual("2*2=", cop.history);
        }
    }
}
