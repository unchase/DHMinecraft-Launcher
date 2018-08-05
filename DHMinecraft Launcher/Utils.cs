using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.Serialization.Json;
using ZBobb;
using System.Runtime.InteropServices;

namespace DHMinecraft_Launcher
{
    public static class Utils
    {
        #region Set Placeholders (cueBanner)
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        /// <summary>
        /// Размещает на задний фон текстбокса с прозрачным фоном надпись.
        /// </summary>
        /// <param name="alphaBlendTextBox">Текстбокс <see cref="System.ZBob.AlphaBlendTextBox"/> с прозрачным фоном.</param>
        /// <param name="cueBanner">Надпись, которая будет отображаться на фоне при пустом поле ввода.</param>
        public static bool SetPlaceHolderToAlphaBlendTextBox(AlphaBlendTextBox alphaBlendTextBox, string cueBanner)
        {
            try
            {
                SendMessage(alphaBlendTextBox.Handle, EM_SETCUEBANNER, 0, cueBanner);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region JSON Utils
        /// <summary>
        /// Сериализует класс в строку в формате json.
        /// </summary>
        /// <returns>Возвращает сериализованную json-строку.</returns>
        /// <param name="classObj">Объект класса, который необходимо сериализовать в json-строку.</param>
        public static string Serialize<T>(T classObj)
        {
            var streamJson = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(streamJson, classObj);
            streamJson.Position = 0;
            var srJson = new StreamReader(streamJson);
            return srJson.ReadToEnd();
        }

        /// <summary>
        /// Десериализует строку в формате json в объект заданного класса, используя выбранную кодировку <seealso cref="System.Text.Encoding"/>.
        /// </summary>
        /// <returns>Возвращает десериализованный из строки в формате json объект класса.</returns>
        /// <param name="jsonUri">Uri, указывающий на расположение json-файла.</param>
        /// <param name="encodingJson">Кодировка <seealso cref="System.Text.Encoding"/>, которая будет использована при десериализации.</param>
        public static T Deserialize<T>(string jsonUri, Encoding encodingJson)
        {
            var wc = new WebClient
            {
                Proxy = new WebProxy(),
                UseDefaultCredentials = true
            };
            var data = wc.DownloadString(jsonUri);
            var json = new DataContractJsonSerializer(typeof(T));
            return (T)json.ReadObject(new MemoryStream(encodingJson.GetBytes(data)));
        }

        /// <summary>
        /// Метод сохрняет выбранный объект класса в json-файл по выбранному пути с использованием выбранной кодировки <seealso cref="System.Text.Encoding"/>.
        /// </summary>
        /// <returns>Возвращает результат сохранения объекта выбранного класса в json-файл.</returns>
        /// <param name="classObj">Объект класса, который необходимо сохранить в json-файл.</param>
        /// <param name="fullPathJsonFile">Полный путь к json-файлу, куда будет сохранен результат.</param>
        /// <param name="encodingJson">Кодировка <seealso cref="System.Text.Encoding"/>, которая будет использована при сериализации.</param>
        public static bool SaveClassObjectToJsonFile<T>(T classObj, string fullPathJsonFile, Encoding encodingJson)
        {
            var json = Serialize<T>(classObj);

            if (!Directory.Exists(Path.GetDirectoryName(fullPathJsonFile)))
                Directory.CreateDirectory(Path.GetDirectoryName(fullPathJsonFile));

            using (var fsJson = new FileStream(fullPathJsonFile, FileMode.Create))
            {
                try
                {
                    var dataJson = encodingJson.GetBytes(json);
                    fsJson.Write(dataJson, 0, dataJson.Length); 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return true;
        }
        #endregion

        #region MD5 And Checksum
        /// <summary>
        /// Класс реализует методы для работы с хэшем MD5.
        /// </summary>
        public static class MD5Hash
        {
            //формирует хэш в виде 32-символьной строки в шестнадцатеричном формате
            public static string GetMd5Hash(MD5 md5Hash, string input)
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }

            /// <summary>
            /// Метод сравнивает MD5 хэш, задданный строкой, с хэшем заданной строки.
            /// </summary>
            /// <returns>Возвращает результат сравнения.</returns>
            /// <param name="md5Hash"><seealso cref="System.Security.Criptografy.MD5"/>.</param>
            /// <param name="input">Строка, для которой вычисляется ее MD5 хэш, который потом сранивается с заданным MD5 хэшем.</param>
            /// <param name="hash">MD5 хэш в виде строки.</param>
            public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
            {
                var hashOfInput = GetMd5Hash(md5Hash, input);
                var comparer = StringComparer.OrdinalIgnoreCase;

                return 0 == comparer.Compare(hashOfInput, hash);
            }

            // получает checksum файла в выбранном алгоритме хэширования
            // Пример:
            // a3ccfd0aa0b17fd23aa9fd0d84b86c05
            // string MD5checksum = GetFileChecksum("c:\\myfile.exe", new MD5CryptoServiceProvider());
            private static string GetFileChecksum(string file, HashAlgorithm algorithm)
            {
                var result = string.Empty;

                using (var fs = File.OpenRead(file))
                {
                    result = BitConverter.ToString(algorithm.ComputeHash(fs)).ToLower().Replace("-", "");
                }

                return result;
            }
        }
        #endregion

        #region ServerReqeusts and work with server
        /// <summary>
        /// Метод авторизует на сервере minecraft пользователя, с заданными данными. Возвращает ответ сервера.
        /// </summary>
        /// <returns>Возвращает строку ответа сервера при попытке авторизации.</returns>
        /// <param name="authUri">Uri к скрипту авторизации на сервере.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="passwordmd5">Пароль пользователя в виде MD5 хэш строки.</param>
        /// <param name="version">Версия minecraft.</param>
        public static string AuthOnServer(string authUri, string login, string passwordmd5, string version)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.Proxy = new WebProxy();
                    var urlDataPost = new System.Collections.Specialized.NameValueCollection
                    {
                        {"user", login},
                        {"password", passwordmd5},
                        {"version", version}
                    };
                    var responsebytes = client.UploadValues(authUri, "POST", urlDataPost);
                    return Encoding.UTF8.GetString(responsebytes);
                }
                catch (Exception ex)
                {
                    if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        return "Сетевое подключение недоступно.";
                    else
                        return "Не могу соединиться с " + authUri + "\nТекст ошибки: " + ex.Message;
                }
            }
        }
        #endregion
    }
}
