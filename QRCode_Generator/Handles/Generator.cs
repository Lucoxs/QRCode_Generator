using Microsoft.AspNetCore.Components.Forms;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QRCode_Generator.Handles
{
    public class Generator
    {
        public static string GenerateQRCode(string input)
        {
            QRCodeGenerator qRCodeGenerator = new();
            QRCodeData qrCodeData = qRCodeGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.H);

            var pngQr = new PngByteQRCode(qrCodeData);
            byte[] pngBytes = pngQr.GetGraphic(5);
            string b64 = Convert.ToBase64String(pngBytes);

            return $"data:image/png;base64,{b64}";
        }

        public static Uri GenerateNewUri(string domainUri)
        {
            var baseUri = new Uri(domainUri);
            Uri newUri = new(new Uri($"{baseUri.Scheme}://{baseUri.Host}:{baseUri.Port}"), "redirectUri");

            var randomNumber = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            string hash = Convert.ToBase64String(randomNumber);

            return new Uri(newUri, hash);
        }
    }
}
