using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using QRCode_Generator.Interfaces;

namespace QRCode_Generator.Components.Pages
{
    public class RedirectionBase : ComponentBase
    {
        [Parameter]
        public string? RedirectionCode { get; set; }

        [Inject]
        private IMappingService mappingService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        [Inject] 
        protected PreloadService PreloadService { get; set; } = default!;

        protected string Message { get; set; } = "Vous allez être redirigé...";

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {

            PreloadService.Show(SpinnerColor.Dark);

            if (string.IsNullOrEmpty(RedirectionCode))
            {
                Message = "Le code de redirection est manquant.";
                PreloadService.Hide();
                await base.OnInitializedAsync();
                return;
            }

            var mapping = mappingService.GetMappingByRedirectionCode(RedirectionCode);
            if (mapping == null)
            {
                Message = "Le code de redirection est invalide.";
                PreloadService.Hide();
                await base.OnInitializedAsync();
                return;
            }

            if (!mapping.IsActivate)
            {
                Message = "Le code est désactiver";
                PreloadService.Hide();
                await base.OnInitializedAsync();
                return;
            }

            navigationManager.NavigateTo(mapping.RedirectionUrl, true);

            await base.OnInitializedAsync();
        }
    }
}
