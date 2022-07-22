// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

using (var cryptoProvider = new RNGCryptoServiceProvider())
{
    var APPID = Guid.NewGuid();
    byte[] secretKeyByteArray = new byte[32]; //256 bit
    cryptoProvider.GetBytes(secretKeyByteArray);
    var APIKey = Convert.ToBase64String(secretKeyByteArray);
}
Console.ReadLine();