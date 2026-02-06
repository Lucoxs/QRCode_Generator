using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using QRCode_Generator.Handles;
using QRCode_Generator.Interfaces;
using QRCode_Generator.Models;
using QRCode_Generator.Services;
using QRCoder;
using System.Buffers.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace QRCode_Generator.Components.Pages
{
    public class Generator_QRCodeBase : ComponentBase
    {
        [Inject]
        private IMappingService mappingService { get; set; }
        protected List<Mapping> Mappings = new();

        protected string InputText { get; set; } = string.Empty;
        protected string? Image { get; set; } = null;

        [Inject]
        public NavigationManager Navigation { get; set; } = default!;

        protected void GenerateQRCode()
        {
            var newUri = Generator.GenerateNewUri(Navigation.BaseUri);

            Image = Generator.GenerateQRCode(InputText);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Mappings = mappingService.GetMappings();
        }

        protected void OnRowClick(GridRowEventArgs<Mapping> args)
        {
            if (!string.IsNullOrEmpty(args.Item.ImageBase64))
                return;

            args.Item.DomainUrl = Generator.GenerateNewUri(Navigation.BaseUri).ToString();
            args.Item.ImageBase64 = Generator.GenerateQRCode(args.Item.DomainUrl);
        }
    }
}
