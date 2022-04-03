using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace Isys.Utilities {
    /// <summary>
    /// Windows API 関数定義クラス
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <history>
    /// 1.00.00 2022/04/03  k.konzo             新規作成
    /// </history>
    [SuppressUnmanagedCodeSecurity]
    internal static class UnsafeNativeMethods {
        /// <summary>
        /// 指定されたセクション内にある、指定されたキーに関連付けられている文字列を取得する(Windows API)
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpKeyName">キー名</param>
        /// <param name="lpDefault">既定の文字列</param>
        /// <param name="lpReturnedString">情報が格納されるバッファ</param>
        /// <param name="nSize">情報バッファのサイズ</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>バッファに格納された文字数(終端のNULL文字除く)を返す。
        /// <para>
        /// バッファのサイズが不足して、要求された文字列全体を格納できないと、文字列を途中で切り捨て、
        /// 最後に 1 個の NULL 文字を追加し、戻り値は <paramref name="nSize"/>-1 を返す。
        /// </para>
        /// <para>
        /// <paramref name="lpAppName"/> または <paramref name="lpKeyName"/> パラメータのどちらかが NULL の場合、
        /// バッファのサイズが不足して、要求された文字列全体を格納できないと、文字列を途中で切り捨て、
        /// 最後に 2 個の NULL 文字が追加し、戻り値は <paramref name="nSize"/>-2 を返す。
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <paramref name="lpAppName"/> パラメータで指定されたセクションの見出しの下から、
        /// <paramref name="lpKeyName"/> パラメータで指定された名前に一致するキーを検索します。
        /// キーが見つかった場合、そのキーに対応する文字列をバッファへコピーします。
        /// キーが見つからなかった場合、<paramref name="lpDefault"/> パラメータで
        /// 指定された既定の文字列をコピーする。
        /// </para>
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern uint GetPrivateProfileString(
           string lpAppName,
           string lpKeyName,
           string lpDefault,
           string lpReturnedString,
           uint nSize,
           string lpFileName);

        /// <summary>
        /// 指定されたセクション内にある、指定されたキーに関連付けられている整数を取得する(Windows API)
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpKeyName">キー名</param>
        /// <param name="nDefault">キー名が見つからなかった場合に返すべき値</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>指定したセクション内にある、指定したキーに関連付けられている文字列に相当する整数を返す。
        /// <para/>指定したキーが見つからない場合、<paramref name="nDefault"/> パラメータで指定した既定の値を返す。
        /// <para/>キーの値が負の場合、0 を返す。
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern uint GetPrivateProfileInt(
            string lpAppName,
            string lpKeyName,
            int nDefault,
            string lpFileName);

        /// <summary>
        /// 指定されたセクション内のすべてのキーと値を取得する(Windows API)
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpReturnedString">情報が格納されるバッファ</param>
        /// <param name="nSize">情報バッファのサイズ</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>バッファに格納された文字数(終端のNULL文字除く)を返す。
        /// <para>
        /// バッファのサイズが不足して、 指定したセクション内の
        /// キー名と値のペアの一部を格納できない場合、nSize-2 の値を返す。
        /// </para>
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern uint GetPrivateProfileSection(
           string lpAppName,
           string lpReturnedString,
           uint nSize,
           string lpFileName);

        /// <summary>
        /// すべてのセクションの名前を取得する(Windows API)
        /// </summary>
        /// <param name="lpReturnedString">情報が格納されるバッファ</param>
        /// <param name="nSize">情報バッファのサイズ</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>バッファに格納された文字数(終端のNULL文字除く)を返す。
        /// <para>
        /// バッファのサイズが不足して、 指定したセクション内の
        /// キー名と値のペアの一部を格納できない場合、nSize-2 の値を返す。
        /// </para>
        /// </returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        public static extern uint GetPrivateProfileSectionNames(
           string lpReturnedString,
           uint nSize,
           string lpFileName);

        /// <summary>
        /// 指定されたセクション内にある、指定されたキーに文字列を保存する(Windows API)
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpKeyName">キー名</param>
        /// <param name="lpString">保存する文字列</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>成功：0以外
        /// <para/>失敗：0
        /// </returns>
        /// <remarks>
        /// <para/><paramref name="lpString"/>が<c>NULL</c>の場合は指定されたキーを削除する
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileString(
            string lpAppName,
            string lpKeyName,
            string lpString,
            string lpFileName);

        /// <summary>
        /// 指定されたセクション内のキーと値を置き換える
        /// </summary>
        /// <param name="lpAppName">セクション名</param>
        /// <param name="lpString">置き換えるキーと値</param>
        /// <param name="lpFileName">INIファイル名</param>
        /// <returns>
        /// <para/>成功：0以外
        /// <para/>失敗：0
        /// </returns>
        /// <remarks>
        /// <para/><paramref name="lpString"/>には、NULLを区切り文字として最大65,535バイトまで複数のキーと値を指定できる。
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WritePrivateProfileSection(
            string lpAppName,
            string lpString,
            string lpFileName);

    }

    /// <summary>
    /// INIファイルアクセスクラス
    /// </summary>
    /// <remarks>
    /// Windows API による INIファイルアクセスクラス
    /// </remarks>
    /// <history>
    /// 1.00.00 2022/04/03  k.konzo             新規作成
    /// </history>
    public class PrivateProfile {
        /// <summary>
        /// INIファイル名
        /// </summary>
        /// <remarks>
        /// INIファイル名を保持する。
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        public string FileName { get; private set; } = string.Empty;

        /// <summary>
        /// 新しいインスタンスを初期化する
        /// </summary>
        /// <param name="fileName">INIファイル名</param>
        /// <exception cref="ArgumentException">
        /// <para/><paramref name="fileName"/>がnull、空白または空の場合
        /// </exception>
        /// <remarks>
        /// <para/><see cref="PrivateProfile"/>クラスの新しいインスタンスを初期化する。
        /// <para/><see cref="FileName"/>に<paramref name="fileName"/>を設定する。
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        public PrivateProfile(string fileName) {
            if (fileName != null) { fileName = fileName.Trim(); }

            if (string.IsNullOrEmpty(fileName)) {
                throw new ArgumentException(new ArgumentException().Message, nameof(fileName));
            }

            FileName = fileName;
        }

        /// <summary>
        /// 指定されたキーから文字列を読み出す
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="ident">キー名</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>文字列</returns>
        /// <exception cref="ArgumentException">
        /// <para/><paramref name="section"/>がnull、空白または空の場合
        /// <para/><paramref name="ident"/>がnull、空白または空の場合
        /// </exception>
        /// <remarks>
        /// <para/>最大取得可能文字数:半角1024文字(1024Byte)
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        public virtual string ReadString(string section, string ident, string defaultValue = "") {
            if (section != null) { section = section.Trim(); }

            if (string.IsNullOrEmpty(section)) {
                throw new ArgumentException(new ArgumentException().Message, nameof(section));
            }

            if (ident != null) { ident = ident.Trim(); }

            if (string.IsNullOrEmpty(ident)) {
                throw new ArgumentException(new ArgumentException().Message, nameof(ident));
            }

            var buffSize = 0;
            var buff = defaultValue;

            if (File.Exists(FileName)) {
                const int MaxStringSize = 1024 + 1;

                var fileSize = new FileInfo(FileName).Length;
                buffSize = (int)((fileSize >= MaxStringSize) ? MaxStringSize : fileSize);

                var sb = new string('\0', buffSize);
                var copySize = UnsafeNativeMethods.GetPrivateProfileString(section, ident, defaultValue, sb, (uint)buffSize, FileName);
                if (copySize > 0) { buff = sb.Trim('\0').ToString(); }
            }

            return buff;
        }

        /// <summary>
        /// 指定されたキーから整数値を読み出す
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="ident">キー名</param>
        /// <param name="defaultValue">初期値</param>
        /// <returns>整数値</returns>
        /// <exception cref="ArgumentException">
        /// <para/><paramref name="section"/>がnull、空白または空の場合
        /// <para/><paramref name="ident"/>がnull、空白または空の場合
        /// </exception>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 1.00.00 2022/04/03  k.konzo             新規作成
        /// </history>
        public virtual int ReadInteger(string section, string ident, int defaultValue = 0) {

            var buff = ReadString(section, ident);
            if (!int.TryParse(buff, out int value)) { value = defaultValue; }

            return value;
        }
    }
}
