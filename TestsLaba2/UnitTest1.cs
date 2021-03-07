using Microsoft.VisualStudio.TestTools.UnitTesting;
using laba2;
namespace TestsLaba2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str = "юабцде╗фгхийклмнопярстужвьызшэщчъ";
            var expected = "е╗фгхийклмнопярстужвьызшэщчъюабцд";
            var cezar = new CezarCipher();
            var actual = cezar.Encode(str, 5);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var str = "е╗фгхийклмнопярстужвьызшэщчъюабцд";
            var expected = "юабцде╗фгхийклмнопярстужвьызшэщчъ";
            var cezar = new CezarCipher();
            var actual = cezar.Decode(str, 5);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var str = "юабцде╗фгхийклмнопярстужвьызшэщчъ";
            var expected = "лмнопярстужвьызшэщчъюабцде╗фгхийк";
            var rot13 = new Rot13Cipher();
            var actual = rot13.Encode(str);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            var str = "лмнопярстужвьызшэщчъюабцде╗фгхийк";
            var expected = "юабцде╗фгхийклмнопярстужвьызшэщчъ";
            var rot13 = new Rot13Cipher();
            var actual = rot13.Decode(str);
            Assert.AreEqual(expected, actual);
        }
    }
}
