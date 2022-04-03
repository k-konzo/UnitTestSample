using Microsoft.VisualStudio.TestTools.UnitTesting;
using Isys.Utilities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Isys.Utilities.Tests 名前空間
/// </summary>
namespace Isys.Utilities.Tests
{
    /// <summary>
    /// PrivateProfile テストクラス
    /// </summary>
    [TestClass()]
    public class PrivateProfileTests
    {
        /// <summary>
        ///  コンストラクタ テスト
        /// </summary>
        [TestMethod()]
        public void PrivateProfileTest()
        {
            var testSymbol = string.Empty;
            var testCase = string.Empty;
            var testId = string.Empty;

            //----------------
            // normal
            testSymbol = "N";
            //----------------

            // 引数 fileNameが長さ0を超える文字列
            testCase = "1";
            testId = testSymbol + testCase;
            {
                try
                {
                    var excpeted = "inifilename.ini";
                    var target = new PrivateProfile(excpeted);
                    Assert.AreEqual(excpeted, target.FileName, testId);
                }
                catch
                {
                    Assert.Fail(testId);
                }
            }

            //----------------
            // abnormal
            testSymbol = "A";
            //----------------
            // N/A


            //----------------
            // exception
            testSymbol = "E";
            //----------------

            // 引数 fileNameがZLS
            testCase = "1";
            testId = testSymbol + testCase;
            {
                Assert.ThrowsException<ArgumentException>(() => new PrivateProfile(string.Empty), testId);
            }

            // 引数 fileNameがnull
            testCase = "2";
            testId = testSymbol + testCase;
            {
                Assert.ThrowsException<ArgumentException>(() => new PrivateProfile(null), testId);
            }

        }

        /// <summary>
        /// void ReadString テスト
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"..\..\TestData\PrivateProfileTests\ReadStringTest", @"TestData\PrivateProfileTests\ReadStringTest")]
        public void ReadStringTest()
        {

            var iniPath = @"TestData\PrivateProfileTests\ReadStringTest";
            var iniFileName = Path.Combine(iniPath, $"{nameof(ReadStringTest)}.ini");

            var testSymbol = string.Empty;
            var testCase = string.Empty;
            var testId = string.Empty;

            //----------------
            // normal
            testSymbol = "N";
            //----------------

            // 指定したキーの値を取得
            testCase = "1";
            testId = testSymbol + testCase;

            {
                var expected = "Value";
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadString($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値が未定義の場合は初期値を取得
            testCase = "2";
            testId = testSymbol + testCase;

            {
                var defalutValue = "Undefined";

                var expected = defalutValue;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadString($"Section{testSymbol}", $"Key{testCase}", defalutValue);
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値の長さが1023Byte
            testCase = "3M";    // 最大値未満
            testId = testSymbol + testCase;

            {
                var expected = new string('a', 1023);
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadString($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値の長さが1024Byte
            testCase = "3E";    // 最大値
            testId = testSymbol + testCase;

            {
                var expected = new string('a', 1024);
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadString($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値の長さが1025Byte
            testCase = "3L";    // 最大値超
            testId = testSymbol + testCase;

            {
                var expected = new string('a', 1024);
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadString($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            //----------------
            // abnormal
            testSymbol = "A";
            //----------------
            // N/A


            //----------------
            // exception
            testSymbol = "E";
            //----------------

            // 引数 Section がZLS
            testCase = "1A";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadString(string.Empty, $"Key{testCase}"), testId);
            }

            // 引数 section がnull
            testCase = "1B";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadString(null, $"Key{testCase}"), testId);
            }


            // 引数 ident がZLS
            testCase = "2A";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadString($"Section{testSymbol}", string.Empty), testId);
            }

            // 引数 ident がnull
            testCase = "2B";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadString($"Section{testSymbol}", null), testId);
            }
        }

        /// <summary>
        /// void ReadInteger テスト
        /// </summary>
        [TestMethod()]
        [DeploymentItem(@"..\..\TestData\PrivateProfileTests\ReadIntegerTest", @"TestData\PrivateProfileTests\ReadIntegerTest")]
        public void ReadIntegerTest()
        {
            var iniPath = @"TestData\PrivateProfileTests\ReadIntegerTest";
            var iniFileName = Path.Combine(iniPath, $"{nameof(ReadIntegerTest)}.ini");

            var testSymbol = string.Empty;
            var testCase = string.Empty;
            var testId = string.Empty;

            //----------------
            // normal
            testSymbol = "N";
            //----------------

            // 指定したキーの値を取得
            testCase = "1";
            testId = testSymbol + testCase;

            {
                var expected = 1;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値が未定義の場合は初期値を取得
            testCase = "2";
            testId = testSymbol + testCase;

            {
                var defalutValue = 2;

                var expected = defalutValue;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}", defalutValue);
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最小値未満
            testCase = "3NM";   // 最小値未満
            testId = testSymbol + testCase;

            {
                var expected = -2147483647;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最小値
            testCase = "3NE";   // 最長値
            testId = testSymbol + testCase;

            {
                var expected = -2147483648;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最小値超
            testCase = "3NL";   // 最小値超
            testId = testSymbol + testCase;

            {
                var expected = 0;   // int型ではないため初期値(0)が戻る
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最大値未満
            testCase = "3PM";   // 最大値未満
            testId = testSymbol + testCase;

            {
                var expected = 2147483646;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最大値
            testCase = "3PE";   // 最長値
            testId = testSymbol + testCase;

            {
                var expected = 2147483647;
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値のが最大値超
            testCase = "3PL";   // 最大値超
            testId = testSymbol + testCase;

            {
                var expected = 0;   // int型ではないため初期値(0)が戻る
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }


            //----------------
            // abnormal
            testSymbol = "A";
            //----------------
            // 指定したキーの値が文字列
            testCase = "1";
            testId = testSymbol + testCase;

            {
                var expected = 0;   // int型ではないため初期値(0)が戻る
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }

            // 指定したキーの値が実数
            testCase = "2";
            testId = testSymbol + testCase;

            {
                var expected = 0;   // int型ではないため初期値(0)が戻る
                var target = new PrivateProfile(iniFileName);
                var actual = target.ReadInteger($"Section{testSymbol}", $"Key{testCase}");
                Assert.AreEqual(expected, actual, testId);
            }


            //----------------
            // exception
            testSymbol = "E";
            //----------------

            // 引数 Section がZLS
            testCase = "1A";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadInteger(string.Empty, $"Key{testCase}"), testId);
            }

            // 引数 section がnull
            testCase = "1B";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadInteger(null, $"Key{testCase}"), testId);
            }


            // 引数 ident がZLS
            testCase = "2A";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadInteger($"Section{testSymbol}", string.Empty), testId);
            }

            // 引数 ident がnull
            testCase = "2B";
            testId = testSymbol + testCase;
            {
                var target = new PrivateProfile(iniFileName);
                Assert.ThrowsException<ArgumentException>(() => target.ReadInteger($"Section{testSymbol}", null), testId);
            }
        }
    }
}