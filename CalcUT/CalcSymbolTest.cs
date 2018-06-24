using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcModels;

namespace CalcUT
{
    [TestClass]
    public class CalcSymbolTest
    {
        [TestMethod]
        public void TransformationArgTest()
        {
            Assert.AreEqual(TypeOperation.None.ToString(), CalcSymbol.TransformationArg(""));

            Assert.AreEqual(TypeOperation.Multiplication.ToString(), CalcSymbol.TransformationArg("*"));

            Assert.AreEqual(TypeOperation.None.ToString(), CalcSymbol.TransformationArg("9"));
        }
    }
}
